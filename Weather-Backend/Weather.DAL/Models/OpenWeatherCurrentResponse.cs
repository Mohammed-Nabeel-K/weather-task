namespace Weather.DAL.Models
{
    public class CurrentWeather
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public DateTime Datetime { get; set; } = DateTime.UtcNow;
    }
    public class OpenWeatherCurrentResponse
    {
        public Coord Coord { get; set; }
        public Weather[] Weather { get; set; }
        public Main Main { get; set; }
        public Sys Sys { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }

    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }

    }


    public class Sys
    {
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}
