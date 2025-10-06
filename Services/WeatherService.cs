using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherForecastProj.Models;

namespace WeatherForecastProj.Services
{
    /// Service responsible for retrieving and caching weather forecasts
    /// from the Singapore Government’s open data API.
    /// 
    /// This class uses HttpClient to make REST calls and applies a simple
    /// in-memory cache to reduce repeated API requests.
    public class WeatherService
    {
        // Reusable HttpClient instance (injected from DI container)
        private readonly HttpClient _http;

        // Simple in-memory cache for forecast results
        private static List<Forecast> _cachedForecasts;

        // Last time the API was fetched (used for cache expiry)
        private static DateTime _lastFetched = DateTime.MinValue;

        // Cached timestamp string (from API response)
        private static string _cachedTimestamp;

        public WeatherService(HttpClient http)
        {
            // Reusable HttpClient instance (injected from DI container)
            _http = http;
        }

         /// Fetches forecasts from API (cached for 5 mins).
        public async Task<List<Forecast>> GetWeatherAsync()
        {
            if (_cachedForecasts != null && (DateTime.Now - _lastFetched).TotalMinutes < 5)
            {
                return _cachedForecasts;
            }

            // Otherwise, call the external weather API
            var response = await _http.GetFromJsonAsync<ApiResponse>(
                "https://api-open.data.gov.sg/v2/real-time/api/two-hr-forecast");
            
            // Validate response structure before processing
            if (response?.Data?.Items == null || response.Data.Items.Count == 0)
                return new List<Forecast>();

            // Get the first forecast item (latest data)
            var item = response.Data.Items.First();

            // Convert API model to local Forecast model
            _cachedForecasts = item.Forecasts
                .Select(f => new Forecast
                {
                    Area = f.Area,
                    ForecastText = f.ForecastText
                })
                .ToList();

            // Store update timestamp and cache time
            _cachedTimestamp = item.Update_Timestamp;
            _lastFetched = DateTime.Now;

            return _cachedForecasts;
        }

        /// Returns the last updated timestamp from the API (cached).
        public async Task<string> GetLastUpdatedAsync()
        {
            // Return cached timestamp if cache is still fresh
            if (!string.IsNullOrEmpty(_cachedTimestamp) && (DateTime.Now - _lastFetched).TotalMinutes < 5)
            {
                return _cachedTimestamp;
            }

            // Otherwise, fetch a fresh timestamp from the API
            var response = await _http.GetFromJsonAsync<ApiResponse>(
                "https://api-open.data.gov.sg/v2/real-time/api/two-hr-forecast");

            if (response?.Data?.Items == null || response.Data.Items.Count == 0)
                return string.Empty;

            // Extract and cache the timestamp
            var item = response.Data.Items.First();
            _cachedTimestamp = item.Update_Timestamp;
            _lastFetched = DateTime.Now;

            return _cachedTimestamp;
        }
    }
}
