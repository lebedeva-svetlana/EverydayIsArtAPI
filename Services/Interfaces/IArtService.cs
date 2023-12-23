using EverydayIsArtAPI.Models;

namespace EverydayIsArtAPI.Services
{
    public interface IArtService
    {
        public Task<Art> GetArt();
    }
}