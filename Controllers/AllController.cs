using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EverydayIsArtAPI.Controllers
{
    /// <summary>
    ///     A controller that provides access to exhibits of all used organizations.
    /// </summary>
    [ApiController]
    [Route("random/[controller]")]
    public class AllController(IAllService artService, ILogger<ArtController> logger) : ArtController(artService, logger)
    {
    }
}