using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.DAL.Models
{
    public class ForcastResponseItem
    {
        public double Temp { get; set; }
        public List<string> Icon { get; set; }
    }
    public class OpenWeatherForecastResponse
    {
        public List<ForecastItem> List { get; set; }
    }

    public class ForecastItem
    {
        public long Dt { get; set; }
        public MainForecast Main { get; set; }
        public List<Weather> Weather { get; set; }
    }

    public class MainForecast
    {
        public double Temp { get; set; }
    }


}
