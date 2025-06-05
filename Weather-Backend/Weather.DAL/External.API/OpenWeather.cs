using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;
using Weather.DAL.Interfaces;
using Weather.DAL.Models;

namespace Weather.DAL.External.API
{
    public class OpenWeather(HttpClient httpClient, IOptions<WeatherSettings> settings) : IOpenWeather
    {
        private readonly string _apiKey = settings.Value.ApiKey;
        public async Task<OpenWeatherCurrentResponse> OpenWeatherApi(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric";
            var response = await httpClient.GetStringAsync(url);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JsonSerializer.Deserialize<OpenWeatherCurrentResponse>(response,options);
            return result;
        }
        public async Task<List<ForecastItem>> GetNext10HoursFromForecast(string city)
        {
            var url = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={_apiKey}&units=metric";
            var result = await httpClient.GetFromJsonAsync<OpenWeatherForecastResponse>(url);

            var now = DateTime.UtcNow;
            return result.List
                         .Take(10)
                         .ToList();
        }
    }
}
