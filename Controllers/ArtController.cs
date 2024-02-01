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
            try
            {
                var art = await _artService.GetArt();
                return new JsonResult(art);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred on art receiving.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}