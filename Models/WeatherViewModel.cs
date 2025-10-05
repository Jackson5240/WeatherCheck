using System.Collections.Generic;

namespace WeatherForecastProj.Models
{
    public class WeatherViewModel
    {
        public List<string> Areas { get; set; } = new List<string>();
        public string SelectedArea { get; set; }
        public string SelectedForecast { get; set; }
        public string LastUpdated { get; set; }
    }
}
