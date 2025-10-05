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
        private readonly WeatherService _service;

        public WeatherController(WeatherService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(string selectedArea)
        {
            var forecasts = await _service.GetWeatherAsync();
            var lastUpdated = await _service.GetLastUpdatedAsync();

            var model = new WeatherViewModel
            {
                Areas = forecasts.Select(f => f.Area).ToList(),
                SelectedArea = selectedArea,
                SelectedForecast = forecasts
                    .FirstOrDefault(f => f.Area.Equals(selectedArea ?? "", StringComparison.OrdinalIgnoreCase))
                    ?.ForecastText,
                LastUpdated = lastUpdated
            };

            return View(model);
        }
    }
}
