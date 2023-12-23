using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EverydayIsArtAPI.Controllers
{
    [ApiController]
    [Route("random/[controller]")]
    public class AllController(IAllService artService, ILogger<ArtController> logger) : ArtController(artService, logger)
    {
    }
}