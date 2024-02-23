using Microsoft.AspNetCore.Mvc;
using MiTubeModels;
using System.Numerics;

namespace MiTubeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PosterController : ControllerBase
    {
        //TODO
        private readonly ILogger<WeatherForecastController> _logger;

        public PosterController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Poster> Get()
        {
            return new List<Poster>();
        }

        [HttpGet]
        public IEnumerable<Poster> Get(string id)
        {
            return new List<Poster>();
        }

        [HttpPost]
        public void Post(Poster poster)
        {

        }
    }
}
