using Weather.BLL.Interfaces;
using Weather.DAL.Interfaces;
using Weather.DAL.Models;

namespace Weather.BLL.Services
{
    public class WeatherService(IOpenWeather openWeather, IWeatherRepository weatherRepository) : IWeatherService
    {
        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            var result = await openWeather.OpenWeatherApi(city);
            var resTen = await openWeather.GetNext10HoursFromForecast(city);

            var currentResponse = new CurrentWeather
            {
                Temp = result.Main.Temp,
                Feels_Like = result.Main.Feels_Like,
                Sunrise = result.Sys.Sunrise,
                Sunset = result.Sys.Sunset,
                Id = new Guid(),
                Name = result.Name,
                Icon = result.Weather[0].Icon
            };
            var res = await weatherRepository.AddData(currentResponse);
            if (!res)
            {
                throw new Exception("Failed to save current weather data to the database.");
            }
            return new WeatherResponse
            {
                currentResponse = currentResponse,
                forecastResponse = [.. resTen.Select(item => new ForcastResponseItem
                    {
                        Temp = item.Main.Temp,
                        Icon = [.. item.Weather.Select(d => d.Icon)],
                    })]
            };
        }
        public async Task<List<CurrentWeather>> GetAllWeatherAsync(WeatherQuery weatherQuery)
        {
            return await weatherRepository.GetAllData(weatherQuery);
        }
    }
}
