using EverydayIsArtAPI.Models;
using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            string response = await _authenticationService.Login(request);
            return Ok(response);
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            string response = await _authenticationService.Register(request);
            return Ok(response);
        }
    }
}