using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EverydayIsArtAPI.Controllers
{
    [ApiController]
    [Route("random/[controller]")]
    public class MetmuseumController(IMetmuseumService artService, ILogger<ArtController> logger) : ArtController(artService, logger)
    {
    }
}