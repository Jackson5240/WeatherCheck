using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastProj.Models;
using WeatherForecastProj.Services;

namespace WeatherForecastProj.Controllers
{
    public class WeatherController : Controller
    {
        /// Reference to the WeatherService that retrieves and caches
        /// forecast data from the external weather API.
        private readonly WeatherService _service;

        public WeatherController(WeatherService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string selectedArea)
        {
            // ------------------------------------------------------------
            // Retrieve data from the weather service
            // ------------------------------------------------------------
            var forecasts = await _service.GetWeatherAsync();
            var lastUpdated = await _service.GetLastUpdatedAsync();

            var model = new WeatherViewModel
            {
                // Populate list of all forecast area names
                Areas = forecasts.Select(f => f.Area).ToList(),
                // Store the area currently selected by the user
                SelectedArea = selectedArea,
                // Find the forecast text for the selected area (case-insensitive)
                SelectedForecast = forecasts
                    .FirstOrDefault(f => f.Area.Equals(selectedArea ?? "", StringComparison.OrdinalIgnoreCase))
                    ?.ForecastText,
                // Display when the data was last updated by the API
                LastUpdated = lastUpdated
            };

            // ------------------------------------------------------------
            // Render the Razor view using the populated model
            // ------------------------------------------------------------
            return View(model);
        }
    }
}
