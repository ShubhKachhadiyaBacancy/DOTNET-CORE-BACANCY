using DAY3.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DAY1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //OpenWeather controller
    public class OpenWeatherController:ControllerBase
    {
        private readonly IOpenWeather _weather;
        public OpenWeatherController(IOpenWeather _weather)
        {
             this._weather = _weather;
        }
        [HttpGet("OpenWeather/{latitude}/{longitude}")]
        public IActionResult Get(float longitude, float latitude)
        {
            OpenWeatherClass openWeatherClass = _weather.GetWeather(longitude,latitude);

            if(openWeatherClass == null)
            {
                return BadRequest("ENTER VALID COORDINATES");
            }
            return Ok(openWeatherClass);
        }
    }
}
