using EverydayIsArtAPI.Models;

namespace EverydayIsArtAPI.Services
{
    public class AllService : IAllService
    {
        private List<IArtService> _services = new();

        public AllService(ITretyakovService tretyakovService, IVamService vamService, IMetmuseumService metmuseumService)
        {
            _services.Add(tretyakovService);
            _services.Add(vamService);
            _services.Add(metmuseumService);
        }

        public async Task<Art> GetArt()
        {
            int index = new Random().Next(0, _services.Count);
            return await _services[index].GetArt();
        }
    }
}