using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private static WeatherData _weatherData;
        
        public static async Task<WeatherData> getCityWeatherInfoAsync(string lat, string longi)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.open-meteo.com/v1/forecast?latitude=" + lat + "&longitude=" + longi + "&current_weather=true"))
                    {
                        HttpResponseMessage response = await httpClient.SendAsync(request);
                        string jsonString = response.Content.ReadAsStringAsync().Result;
                        _weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonString);                        
                    }
                }
            }
            catch (Exception ex)
            {
                _weatherData.reason=ex.Message;
            }
            return _weatherData;
        }
    }
}
