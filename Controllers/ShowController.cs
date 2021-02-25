using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpringFestivalBFF.Models;

namespace SpringFestivalBFF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Show> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Show()
                {
                    Id = index,
                    Votes = rng.Next(-20, 55),
                    Name = $"Show: {index}",
                    Order = index
                })
                .ToArray();
        }
    }
}