using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EverydayIsArtAPI.Controllers
{
    /// <summary>
    ///     A controller that provides access to the State Tretyakov Gallery exhibits.
    /// </summary>
    [ApiController]
    [Route("random/[controller]")]
    public class TretyakovController(ITretyakovService artService) : ArtController(artService)
    {
    }
}