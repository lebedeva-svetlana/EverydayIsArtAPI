using EverydayIsArtAPI.Models;
using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EverydayIsArtAPI.Controllers
{
    /// <summary>
    ///     A controller that provides access to exhibits.
    /// </summary>
    public class ArtController : ControllerBase
    {
        private readonly ILogger<ArtController> _logger;
        private IArtService _artService;

        public ArtController(IArtService artService, ILogger<ArtController> logger)
        {
            _artService = artService;
            _logger = logger;
        }

        /// <summary>
        ///     Gets a random exhibit.
        /// </summary>
        /// <returns>
        ///     A JSON that contains <see cref="Art"/> with 200 status code or 500 status code.
        /// </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Art>> GetArt()
        {
            var art = await _artService.GetArt();
            if (art is null)
            {
                return StatusCode(500, "Internal server error.");
            }
            return new JsonResult(art);
        }
    }
}