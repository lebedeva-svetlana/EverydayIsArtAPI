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
        public Task<Art?> GetArt();

        /// <summary>
        ///     Returns a exhibit from url.
        /// </summary>
        /// <param name="url">
        ///     URL of the exhibit.
        /// </param>
        /// <returns>
        ///     The exhibit.
        /// </returns>
        public Task<Art?> GetArt(string url);
    }
}