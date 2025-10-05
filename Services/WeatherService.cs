using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WeatherForecastProj.Models;

namespace WeatherForecastProj.Services
{
    public class WeatherService
    {
        private readonly HttpClient _http;

        // simple cache to avoid spamming the API
        private static List<Forecast> _cachedForecasts;
        private static DateTime _lastFetched = DateTime.MinValue;
        private static string _cachedTimestamp;

        public WeatherService(HttpClient http)
        {
            _http = http;
        }

        /// <summary>
        /// Fetches forecasts from API (cached for 5 mins).
        /// </summary>
        public async Task<List<Forecast>> GetWeatherAsync()
        {
            if (_cachedForecasts != null && (DateTime.Now - _lastFetched).TotalMinutes < 5)
            {
                return _cachedForecasts;
            }

            var response = await _http.GetFromJsonAsync<ApiResponse>(
                "https://api-open.data.gov.sg/v2/real-time/api/two-hr-forecast");

            if (response?.Data?.Items == null || response.Data.Items.Count == 0)
                return new List<Forecast>();

            var item = response.Data.Items.First();

            _cachedForecasts = item.Forecasts
                .Select(f => new Forecast
                {
                    Area = f.Area,
                    ForecastText = f.ForecastText
                })
                .ToList();

            _cachedTimestamp = item.Update_Timestamp;
            _lastFetched = DateTime.Now;

            return _cachedForecasts;
        }

        /// <summary>
        /// Returns the last updated timestamp from the API (cached).
        /// </summary>
        public async Task<string> GetLastUpdatedAsync()
        {
            if (!string.IsNullOrEmpty(_cachedTimestamp) && (DateTime.Now - _lastFetched).TotalMinutes < 5)
            {
                return _cachedTimestamp;
            }

            var response = await _http.GetFromJsonAsync<ApiResponse>(
                "https://api-open.data.gov.sg/v2/real-time/api/two-hr-forecast");

            if (response?.Data?.Items == null || response.Data.Items.Count == 0)
                return string.Empty;

            var item = response.Data.Items.First();
            _cachedTimestamp = item.Update_Timestamp;
            _lastFetched = DateTime.Now;

            return _cachedTimestamp;
        }
    }
}
