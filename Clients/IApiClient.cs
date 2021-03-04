using System.Collections.Generic;
using System.Threading.Tasks;
using SpringFestivalBFF.Models;

namespace SpringFestivalBFF.Clients
{
    public interface IApiClient
    {
        Task<List<Show>> GetShowsAsync();
        Task<Show> CreateShowAsync(Show show);
    }
}