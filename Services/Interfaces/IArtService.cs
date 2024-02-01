using EverydayIsArtAPI.Models;

namespace EverydayIsArtAPI.Services
{
    /// <summary>
    ///     A common service that can be used to work with exhibits.
    /// </summary>
    public interface IArtService
    {
        /// <summary>
        ///     Returns a random exhibit.
        /// </summary>
        /// <returns>
        ///     The random exhibit.
        /// </returns>
        public Task<Art> GetArt();
    }
}