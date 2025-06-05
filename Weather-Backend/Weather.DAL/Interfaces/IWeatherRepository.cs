using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.DAL.Models;

namespace Weather.DAL.Interfaces
{
    public interface IWeatherRepository
    {
        Task<bool> AddData(CurrentWeather weatherData);
        Task<List<CurrentWeather>> GetAllData(WeatherQuery weatherQuery);
    }
}
