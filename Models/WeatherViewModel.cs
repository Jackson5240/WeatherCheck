using System.Collections.Generic;

namespace WeatherForecastProj.Models
{
    /// Represents the view model used by the weather forecast UI.
    /// 
    /// This class acts as a data container that passes information
    /// between the controller/service layer and the Razor View.
    public class WeatherViewModel
    {
        public List<string> Areas { get; set; } = new List<string>();
        public string SelectedArea { get; set; }
        public string SelectedForecast { get; set; }
        public string LastUpdated { get; set; }
    }
}
