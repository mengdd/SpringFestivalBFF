using System.Collections.Generic;
using System.Threading.Tasks;
using SpringFestivalBFF.Clients;
using SpringFestivalBFF.Models;

namespace SpringFestivalBFF.Services
{
    public class ShowService : IShowService
    {
        private readonly IApiClient _apiClient;

        public ShowService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<List<Show>> GetShowsAsync()
        {
            var result = await _apiClient.GetShowsAsync();
            return result;
        }

        public Task<Show> CreateShowAsync(Show show)
        {
            throw new System.NotImplementedException();
        }
    }
}