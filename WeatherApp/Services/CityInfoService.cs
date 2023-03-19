using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Reflection;

namespace WeatherApp.Services
{
    public class CityInfoService
    {
        private static CityData _cityData;
        
           
        public static CityData getCityLatLong(string city)
        {
            List<CityData> cityList = new List<CityData>();
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resource\in.json");
            using (StreamReader file = new StreamReader(path))
            {
                try
                {
                    string json = file.ReadToEnd();

                    var serializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    };

                    cityList = JsonConvert.DeserializeObject<List<CityData>>(json, serializerSettings);
                    _cityData= cityList.Find(x => x.city.Equals(city, StringComparison.OrdinalIgnoreCase));
                    return _cityData;
                }
                catch (Exception)
                {
                    Console.WriteLine("Problem reading file");

                    return null;
                }
            }
        }
    }
}
