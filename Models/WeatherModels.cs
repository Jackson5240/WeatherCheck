using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherForecastProj.Models
{
    public class LabelLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class AreaMetadata
    {
        public string Name { get; set; }

        [JsonPropertyName("label_location")]
        public LabelLocation Label_Location { get; set; }
    }

    public class Forecast
    {
        [JsonPropertyName("area")]
        public string Area { get; set; }

        [JsonPropertyName("forecast")]
        public string ForecastText { get; set; }
    }

    public class Item
    {
        [JsonPropertyName("update_timestamp")]
        public string Update_Timestamp { get; set; }

        [JsonPropertyName("forecasts")]
        public List<Forecast> Forecasts { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("area_metadata")]
        public List<AreaMetadata> Area_Metadata { get; set; }

        [JsonPropertyName("items")]
        public List<Item> Items { get; set; }
    }

    public class ApiResponse
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }

        [JsonPropertyName("errorMsg")]
        public string ErrorMsg { get; set; }
    }
}
