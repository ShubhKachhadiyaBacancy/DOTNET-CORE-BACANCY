using Microsoft.AspNetCore.Mvc;

namespace DAY1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OpenWeatherController:ControllerBase
    {
        [HttpGet("OpenWeather/{latitude}/{longitude}")]
        public IActionResult Get(float longitude, float latitude)
        {
            if (!OpenWeather.StationDictionary.TryGetClosestStation(latitude,longitude, out var stationInfo))
            {
                return BadRequest("Could not find a station.");
            }
            string text = $"STATION NAME : {stationInfo.Name}\nCOUNTRY : {stationInfo.Country}\n";

            var obj = new OpenWeatherClass 
            {
                Station = stationInfo.Name,
                Country = stationInfo.Country
            };
            return Ok(obj);
        }
    }
}
