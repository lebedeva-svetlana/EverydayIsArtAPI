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

        public async Task<Art?> GetArt()
        {
            try
            {
                int index = new Random().Next(0, _services.Count);
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