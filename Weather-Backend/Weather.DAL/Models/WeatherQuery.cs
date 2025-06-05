using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.DAL.Models
{
    public class WeatherQuery
    {
        public string? Location { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
