using EverydayIsArtAPI.Models;

namespace EverydayIsArtAPI.Services
{
    public interface IFavouritesService
    {
        public Task<bool> AddArt(Art art, int favouritesGroupId);

        public Task<bool> CreateFavouritesGroup(string userId, string title);
    }
}