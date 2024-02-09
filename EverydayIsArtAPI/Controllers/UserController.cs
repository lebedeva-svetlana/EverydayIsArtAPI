using EverydayIsArtAPI.Exceptions;
using EverydayIsArtAPI.Models;
using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EverydayIsArtAPI.Controllers
{
    /// <summary>
    ///     A controller that provides access to authentication.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IOptions<ApiBehaviorOptions> _apiBehaviorOptions;

        public UserController(IAuthenticationService authenticationService, IOptions<ApiBehaviorOptions> apiBehaviorOptions)
        {
            _authenticationService = authenticationService;
            _apiBehaviorOptions = apiBehaviorOptions;
        }

        /// <summary>
        ///     Authorizes a user.
        /// </summary>
        /// <param name="request">
        ///     A login data.
        /// </param>
        /// <returns>
        ///     An authentication token with 200 status code or error with status code 400 or 500.
        /// </returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authenticationService.Login(request);

            if (result.Exception is null)
            {
                return Ok(result.Token);
            }

            string key = "";

            if (result.Exception is UserDoesntExists)
            {
                key = "user";
            }
            else if (result.Exception is WrongPasswordException)
            {
                key = "password";
            }

            ModelState.AddModelError(key, result.Exception.Message);
            return _apiBehaviorOptions.Value.InvalidModelStateResponseFactory(ControllerContext);
        }

        /// <summary>
        ///     Registers a new user.
        /// </summary>
        /// <param name="request">
        ///     A registration data.
        /// </param>
        /// <returns>
        ///     An authentication token with 200 status code or error with status code 400 or 500.
        /// </returns>
        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authenticationService.Register(request);
            if (result.Exception is null)
            {
                return Ok(result.Token);
            }

            if (result.Exception is not IBadRequestException)
            {
                return StatusCode(500, result.Exception.Message);
            }

            string key = "";

            if (result.Exception is UserExistsException)
            {
                key = "user";
            }

            ModelState.AddModelError(key, result.Exception.Message);
            return _apiBehaviorOptions.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}