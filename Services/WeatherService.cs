using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Linq;
using WeatherForecastDotnet5WithPayload.Models;

namespace WeatherForecastDotnet5WithPayload.Services
{
    public class WeatherService
    {
        private readonly HttpClient _http;

        public WeatherService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Forecast>> GetWeatherAsync()
        {
            // Replace with actual API endpoint
            var response = await _http.GetFromJsonAsync<ApiResponse>("https://api-open.data.gov.sg/v2/real-time/api/two-hr-forecast");

            if (response?.Data?.Items == null || response.Data.Items.Count == 0)
                return new List<Forecast>();

            return response.Data.Items.First().Forecasts
                .Select(f => new Forecast { Area = f.Area, ForecastText = f.ForecastText })
                //.Select(f => new Forecast { Area = f.Area, ForecastText = f.forecast })
                .ToList();
        }
    }
}
