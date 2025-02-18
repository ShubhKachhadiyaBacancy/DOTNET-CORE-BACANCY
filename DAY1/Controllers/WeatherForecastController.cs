using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenWeather;
using System.IO;
namespace DAY1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(WeatherForecast forecast)
        {
            if(forecast == null)
            {
                return BadRequest("OBJECT IS NULL");
            }
            
            try
            {
                //string text = $"DATE : {forecast.Date}\nTEMPERATURE(C) : {forecast.TemperatureC}\nTEMPERATURE(F) : {forecast.TemperatureF}"
                //+ $"\nSUMMARY : {forecast.Summary}";
                string text = JsonConvert.SerializeObject(forecast, Formatting.Indented);
                if (System.IO.File.Exists("WeatherData.txt"))
                {
                    System.IO.File.AppendAllText("WeatherData.txt", text + Environment.NewLine + Environment.NewLine);
                    return Ok("TEXT ADDED IN FILE");
                }
                else
                {
                    System.IO.File.WriteAllText("WeatherData.txt", text + Environment.NewLine + Environment.NewLine);
                    return Ok("TEXT FILE CREATED");
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!System.IO.File.Exists("WeatherData.txt"))
            {
                return BadRequest("FILE NOT FOUND");
            }

            try
            {
                string text = System.IO.File.ReadAllText("WeatherData.txt");
                if (text == "" || text == null)
                {
                    return BadRequest("FILE IS EMPTY");
                }
                return Ok(text);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
