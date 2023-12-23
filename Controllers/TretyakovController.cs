using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EverydayIsArtAPI.Controllers
{
    [ApiController]
    [Route("random/[controller]")]
    public class TretyakovController(ITretyakovService artService, ILogger<ArtController> logger) : ArtController(artService, logger)
    {
    }
}