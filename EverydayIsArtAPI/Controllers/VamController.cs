using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EverydayIsArtAPI.Controllers
{
    /// <summary>
    ///     A controller that provides access to the Victoria and Albert Museum exhibits.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class VamController(IVamService artService) : ArtController(artService)
    {
    }
}