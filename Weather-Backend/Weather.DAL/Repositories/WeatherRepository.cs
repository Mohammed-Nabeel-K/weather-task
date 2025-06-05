using Microsoft.EntityFrameworkCore;
using Weather.DAL.Data;
using Weather.DAL.Interfaces;
using Weather.DAL.Models;

namespace Weather.DAL.Repositories
{
    public class WeatherRepository(AppDbContext dbContext) : IWeatherRepository
    {
        public async Task<bool> AddData(CurrentWeather weatherData)
        {       
            dbContext.Weather.Add(weatherData);
            await dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<CurrentWeather>> GetAllData(WeatherQuery weatherQuery)
        {
            return await dbContext.Weather
                .Where(d => weatherQuery.Location == null || d.Name.ToLower().Contains(weatherQuery.Location))
                .Where(d => weatherQuery.From == null || d.Datetime >= weatherQuery.From)
                .Where(d => weatherQuery.To == null || d.Datetime <= weatherQuery.To)
                .ToListAsync();
        }
    }
}
