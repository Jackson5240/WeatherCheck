using System.Collections.Generic;

namespace WeatherForecastDotnet5WithPayload.Models
{
    public class WeatherViewModel
    {
        public List<string> Areas { get; set; } = new List<string>();
        public string SelectedArea { get; set; }
        public string SelectedForecast { get; set; }
    }
}
