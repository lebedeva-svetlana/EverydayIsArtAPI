using EverydayIsArtAPI.Models;
using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EverydayIsArtAPI.Controllers
{
    public class ArtController : ControllerBase
    {
        private readonly ILogger<ArtController> _logger;
        private IArtService _artService;

        public ArtController(IArtService artService, ILogger<ArtController> logger)
        {
            _artService = artService;
            _logger = logger;
        }

        [HttpGet]
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