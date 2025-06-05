using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.DAL.Models;

namespace Weather.DAL.Interfaces
{
    public interface IOpenWeather
    {
        Task<OpenWeatherCurrentResponse> OpenWeatherApi(string city);
        Task<List<ForecastItem>> GetNext10HoursFromForecast(string city);
    }
}
