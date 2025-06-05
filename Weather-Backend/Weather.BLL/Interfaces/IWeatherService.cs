using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.DAL.Models;

namespace Weather.BLL.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetWeatherAsync(string city);
        Task<List<CurrentWeather>> GetAllWeatherAsync(WeatherQuery weatherQuery);
    }
}
