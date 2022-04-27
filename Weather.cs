using System;
using Newtonsoft.Json;

namespace WeatherApp
{
   public static class Weather
    {
        private static string? _weatherResponse;
        private static string? _coordinatesResponse;
        private static double _lat;
        private static double _lon;
        private static HttpClient _client = new HttpClient();
        public static string? City { get; set; }
        public static void GetNewWeatherData()
        {
            GetCoordinatesFromApi(City, "6173a3869eca91eae69d58f23a75a2a8");
            ExtractCoordinatesFromJson();
            GetWeatherDataFromApi(_lat, _lon, "6173a3869eca91eae69d58f23a75a2a8");
            ExtractWeatherDataFromJson();
        }

        static void GetCoordinatesFromApi(string city, string key)
        {
            string requestUrl = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit=1&appid={key}&units=metric";
            HttpResponseMessage httpResponse = _client.GetAsync(requestUrl).Result;
            _coordinatesResponse = httpResponse.Content.ReadAsStringAsync().Result;
        }

        static void ExtractCoordinatesFromJson()
        {
            var coordinatesresponses = JsonConvert.DeserializeObject<List<CoordinatesResponse>>(_coordinatesResponse);
            foreach (var coordinatesresponse in coordinatesresponses)
            {
                _lat = coordinatesresponse.Lat;
                _lon = coordinatesresponse.Lon;
            }
        }

        static void GetWeatherDataFromApi(double lat, double lon, string key)
        {
            string requestUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={key}&units=metric";
            HttpResponseMessage httpResponse = _client.GetAsync(requestUrl).Result;
            _weatherResponse = httpResponse.Content.ReadAsStringAsync().Result;
        }

        static void ExtractWeatherDataFromJson()
        {
            WeatherMapResponse weatherMapResponse = JsonConvert.DeserializeObject<WeatherMapResponse>(_weatherResponse);
            Console.WriteLine($"In {City} are {weatherMapResponse.Main.Temp} degrees.");
        }
    }
}