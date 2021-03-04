using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpringFestivalBFF.Models;
using SpringFestivalBFF.Services;

namespace SpringFestivalBFF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly ILogger<ShowController> _logger;
        private readonly IShowService _service;

        public ShowController(IShowService service, ILogger<ShowController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Show>>> GetShowsList()
        {
            // TODO: 这个地方Task<ActionResult<IEnumerable<Show>>> 就不行了, 为什么
            return await _service.GetShowsAsync();
        }

    }
}