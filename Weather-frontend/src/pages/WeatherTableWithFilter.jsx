import React, { useEffect, useState } from 'react';

export default function WeatherTableWithFilter() {
  const [data, setData] = useState([]);
  const [location, setLocation] = useState('');
  const [from, setFrom] = useState('');
  const [to, setTo] = useState('');
  const [loading, setLoading] = useState(false);

  const fetchData = async () => {
    setLoading(true);

    const params = new URLSearchParams();
    if (location) params.append('Location', location);
    if (from) params.append('From', new Date(from).toISOString());
    if (to) params.append('To', new Date(to).toISOString());

    try {
      const response = await fetch(`https://localhost:7216/api/Weather/all?${params}`);
      const result = await response.json();
      setData(result);
    } catch (err) {
      console.error('Error fetching weather data:', err);
    }

    setLoading(false);
  };

  useEffect(() => {
    fetchData();
  }, []);

  const handleFilter = () => {
    fetchData();
  };

  return (
    <div className="max-w-6xl mx-auto p-4">
      <h2 className="text-2xl font-bold mb-4">Weather Data</h2>

      {/* Filters */}
      <div className="grid grid-cols-1 md:grid-cols-4 gap-4 mb-6">
        <div>
          <label className="block text-sm mb-1">Location</label>
          <input
            type="text"
            value={location}
            onChange={(e) => setLocation(e.target.value)}
            className="w-full p-2 rounded border border-gray-300"
          />
        </div>
        <div>
          <label className="block text-sm mb-1">From</label>
          <input
            type="datetime-local"
            value={from}
            onChange={(e) => setFrom(e.target.value)}
            className="w-full p-2 rounded border border-gray-300"
          />
        </div>
        <div>
          <label className="block text-sm mb-1">To</label>
          <input
            type="datetime-local"
            value={to}
            onChange={(e) => setTo(e.target.value)}
            className="w-full p-2 rounded border border-gray-300"
          />
        </div>
        <div className="flex items-end">
          <button
            onClick={handleFilter}
            className="w-full bg-blue-600 text-white py-2 rounded hover:bg-blue-700"
          >
            Filter
          </button>
        </div>
      </div>

      {/* Table */}
      {loading ? (
        <div className="text-center py-8">Loading...</div>
      ) : (
        <div className="overflow-x-auto max-h-[400px] overflow-y-auto rounded-lg border border-gray-300 shadow-sm">
          <table className="w-full border-collapse">
            <thead className="bg-gray-100 sticky top-0 z-10">
              <tr>
                <th className="border px-4 py-2 text-left">City</th>
                <th className="border px-4 py-2 text-left">Temperature</th>
                <th className="border px-4 py-2 text-left">Feels Like</th>
                <th className="border px-4 py-2 text-left">Datetime</th>
              </tr>
            </thead>
            <tbody>
              {data.length === 0 ? (
                <tr>
                  <td colSpan="4" className="text-center p-4">No data found</td>
                </tr>
              ) : (
                data.map((item) => (
                  <tr key={item.id} className="hover:bg-gray-50">
                    <td className="border px-4 py-2">{item.name}</td>
                    <td className="border px-4 py-2">{item.temp}°C</td>
                    <td className="border px-4 py-2">{item.feels_Like}°C</td>
                    <td className="border px-4 py-2">
                      {new Date(item.datetime).toLocaleString()}
                    </td>
                  </tr>
                ))
              )}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}
