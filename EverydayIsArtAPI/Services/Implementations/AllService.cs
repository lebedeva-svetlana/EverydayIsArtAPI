using EverydayIsArtAPI.Models;

namespace EverydayIsArtAPI.Services
{
    /// <inheritdoc cref="IAllService"/>
    public class AllService : IAllService
    {
        private readonly ILogger<VamService> _logger;
        private List<IArtService> _services = new();

        public AllService(ITretyakovService tretyakovService, IVamService vamService, IMetmuseumService metmuseumService, ILogger<VamService> logger)
        {
            _services.Add(tretyakovService);
            _services.Add(vamService);
            _services.Add(metmuseumService);
            _logger = logger;
        }

        public async Task<Art?> GetArt(string url)
        {
            return await GetBaseArt(url);
        }

        public async Task<Art?> GetArt()
        {
            return await GetBaseArt();
        }

        private async Task<Art?> GetBaseArt(string url = null)
        {
            try
            {
                int index = new Random().Next(0, _services.Count);
                if (url is not null)
                {
                    throw new NotImplementedException();
                }
                return await _services[index].GetArt();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred on all art receiving.");
                return null;
            }
        }
    }
}