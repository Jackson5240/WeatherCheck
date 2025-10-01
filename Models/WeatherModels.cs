using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherForecastDotnet5WithPayload.Models
{
    public class LabelLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class AreaMetadata
    {
        public string Name { get; set; }
        public LabelLocation Label_Location { get; set; }
    }

    public class Forecast
    {
        public string Area { get; set; }

        [JsonPropertyName("forecast")]
        public string ForecastText { get; set; }
    }

    public class Item
    {
        public List<Forecast> Forecasts { get; set; }
    }

    public class Data
    {
        public List<AreaMetadata> Area_Metadata { get; set; }
        public List<Item> Items { get; set; }
    }

    public class ApiResponse
    {
        public int Code { get; set; }
        public Data Data { get; set; }
        public string ErrorMsg { get; set; }
    }
}
