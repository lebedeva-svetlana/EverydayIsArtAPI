using EverydayIsArtAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EverydayIsArtAPI.Controllers
{
    /// <summary>
    ///     A controller that provides access to the Metropolitan Museum of Art exhibits.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MetmuseumController(IMetmuseumService artService) : ArtController(artService)
    {
    }
}