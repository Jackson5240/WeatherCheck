using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WeatherForecastDotnet5WithPayload.Services;
using WeatherForecastDotnet5WithPayload.Models;

namespace WeatherForecastDotnet5WithPayload.Controllers
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
            Console.WriteLine($"SelectedArea = '{selectedArea}'");
            foreach (var f in forecasts)
            {
                Console.WriteLine($"Forecast.Area = '{f.Area}'");
                Console.WriteLine($"Forecast.ForecastText = '{f.ForecastText}'");
            }

            var model = new WeatherViewModel
            {
                Areas = forecasts.Select(f => f.Area).ToList(),
                SelectedArea = selectedArea,
                //SelectedForecast = forecasts.FirstOrDefault(f => f.Area == selectedArea)?.ForecastText
                //SelectedForecast = forecasts.FirstOrDefault(f => f.Area.Equals(selectedArea, System.StringComparison.OrdinalIgnoreCase))?.ForecastText
                SelectedForecast = forecasts.FirstOrDefault(f => f.Area.Trim().Equals(selectedArea?.Trim(), System.StringComparison.OrdinalIgnoreCase))?.ForecastText
            };

            

            return View(model);
        }
    }
}
