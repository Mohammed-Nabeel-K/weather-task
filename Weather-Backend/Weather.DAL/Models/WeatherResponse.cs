using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.DAL.Models
{
    public class WeatherResponse
    {
        public CurrentWeather currentResponse { get; set; }
        public List<ForcastResponseItem> forecastResponse { get; set; }
    }
}
