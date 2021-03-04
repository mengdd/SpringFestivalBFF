using System.Collections.Generic;
using System.Threading.Tasks;
using SpringFestivalBFF.Models;

namespace SpringFestivalBFF.Services
{
    public interface IShowService
    {
        Task<List<Show>> GetShowsAsync();

        Task<Show> CreateShowAsync(Show show);
    }
}