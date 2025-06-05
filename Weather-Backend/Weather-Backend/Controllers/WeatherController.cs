using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Weather.BLL.Interfaces;
using Weather.DAL.Models;

namespace Weather_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController(IWeatherService weatherService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetWeather(string city)
        {
            var weather = await weatherService.GetWeatherAsync(city);
            return Ok(weather);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllWeatherData([FromQuery]WeatherQuery weatherQuery)
        {
            var result = await weatherService.GetAllWeatherAsync(weatherQuery);
            return Ok(result);
        }
    }
}
