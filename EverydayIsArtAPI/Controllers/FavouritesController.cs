using EverydayIsArtAPI.Models;
using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EverydayIsArtAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FavouritesController : ControllerBase
    {
        private readonly IFavouritesService _favouritesService;
        private readonly UserManager<User> _userManager;

        public FavouritesController(IFavouritesService favouritesService, UserManager<User> userManager)
        {
            _favouritesService = favouritesService;
            _userManager = userManager;
        }

        private async Task<string> GetUserId()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return user.Id;
        }

        [HttpPost("createfavouritesgroup")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateFavouritesGroup([FromBody] string title)
        {
            string userId = await GetUserId();
            bool isSuccess = await _favouritesService.CreateFavouritesGroup(userId, title);
            if (isSuccess)
            {
                return Created();
            }
            else
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("addart")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddArt([FromBody] Art art, int favGroupId)
        {
            var userId = GetUserId();
            bool isSuccess = await _favouritesService.AddArt(art, favGroupId);

            if (isSuccess)
            {
                return Created();
            }
            else
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}