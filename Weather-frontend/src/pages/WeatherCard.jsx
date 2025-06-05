import { useState, useEffect } from 'react';
import { Cloud } from 'lucide-react';
import React from 'react';

function WeatherCard() {
  const [selectedCity, setSelectedCity] = useState('Delhi');
  const [weatherData, setWeatherData] = useState(null);
  const [loading, setLoading] = useState(true);

  const cities = ['Delhi', 'Moscow', 'Paris', 'New York', 'Sydney', 'Riyadh'];

  useEffect(() => {
    const fetchWeather = async () => {
      try {
        setLoading(true);
        const res = await fetch(`https://localhost:7216/api/Weather?city=${selectedCity}`);
        const data = await res.json();
        setWeatherData(data);
      } catch (error) {
        console.error('Error fetching weather:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchWeather();
  }, [selectedCity]);

  const formatDate = (dateStr) => {
    const date = new Date(dateStr);
    return date.toLocaleDateString(undefined, { day: '2-digit', month: 'short', year: 'numeric' });
  };

  const formatTime = (unix) => {
    return new Date(unix * 1000).toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' });
  };

  const hourlyTemps =
    weatherData?.forecastResponse.map((item, index) => ({
      time: index === 0 ? 'Now' : `${2 + index} AM`,
      temp: `${Math.round(item.temp)}°`,
      icon: (
        <img
          src={`https://openweathermap.org/img/wn/${item.icon[0]}@2x.png`}
          alt=""
          className="w-6 h-6"
        />
      ),
    })) || [];

  return (
    <div className="min-h-screen bg-gradient-to-br from-sky-200 to-indigo-200 flex items-center justify-center p-4">
      <div className="max-w-5xl w-full rounded-3xl shadow-2xl backdrop-blur-md bg-white/20 p-6 flex flex-col md:flex-row gap-6">
        {/* Left Card */}
        <div className="bg-white/60 rounded-3xl p-6 flex-1 flex flex-col justify-between text-gray-800">
          {loading || !weatherData ? (
            <p className="text-lg">Loading...</p>
          ) : (
            <>
              <div>
                <p className="text-lg font-medium">Today</p>

                {/* Centered Temperature with Icon */}
                <div className="flex flex-col items-center mt-4">
                  <img
                    src={`https://openweathermap.org/img/wn/${weatherData.currentResponse.icon}@2x.png`}
                    alt="Weather Icon"
                    className="w-20 h-20"
                  />
                  <h1 className="text-6xl font-bold mt-2">
                    {Math.round(weatherData.currentResponse.temp)}°
                  </h1>
                </div>

                <p className="text-xl mt-2">Sunny</p>

                {/* City Dropdown */}
                <div className="mt-4">
                  <label htmlFor="city" className="text-sm block mb-1">
                    Select City
                  </label>
                  <select
                    id="city"
                    value={selectedCity}
                    onChange={(e) => setSelectedCity(e.target.value)}
                    className="p-2 rounded-md bg-white text-sm border border-gray-300"
                  >
                    {cities.map((city) => (
                      <option key={city} value={city}>
                        {city}
                      </option>
                    ))}
                  </select>
                </div>

                <p className="text-sm mt-3 font-semibold">{weatherData.currentResponse.name}</p>
                <p className="text-sm text-gray-600">
                  {formatDate(weatherData.currentResponse.datetime)}
                </p>
              </div>

              <p className="text-sm mt-4">
                Feels like {Math.round(weatherData.currentResponse.feels_Like)}° | Sunset{' '}
                {formatTime(weatherData.currentResponse.sunset)}
              </p>
            </>
          )}
        </div>

        {/* Right Content */}
        <div className="flex-1 flex flex-col justify-between">
          {/* Hourly Forecast */}
          <div className="bg-blue-100 p-4 rounded-xl grid grid-cols-5 gap-y-4 text-gray-800 text-sm shadow">
            {(loading ? Array(10).fill(null) : hourlyTemps).map((hour, idx) => (
              <div key={idx} className="flex flex-col items-center">
                <span className="text-xs font-medium">{hour?.time || '--'}</span>
                <div className="my-1 text-xl">{hour?.icon || <Cloud />}</div>
                <span className="font-semibold">{hour?.temp || '--'}</span>
              </div>
            ))}
          </div>

          {/* Text Section */}
          <div className="mt-6 text-gray-700">
            <h2 className="text-lg font-semibold mb-2">Weather Insights</h2>
            <p className="text-sm text-gray-600 leading-relaxed">
              Plan your day better with updated weather data. From sunrise to sunset, we've got you
              covered. Keep checking for real-time updates and trends in your city.
            </p>
          </div>
        </div>
      </div>
    </div>
  );
}

export default WeatherCard;
