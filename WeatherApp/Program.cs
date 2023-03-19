// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherApp.Models;
using WeatherApp.Services;

//Console.WriteLine("Hello, World!");



internal class Program
{
    private static async Task Main(string[] args)
    {
       
        Console.WriteLine("Enter city name: ");
        string? city = Console.ReadLine();
        Console.WriteLine("+---------------------Result---------------------+");
        CityData cityData = CityInfoService.getCityLatLong(city);
        if (cityData != null)
        {
            WeatherData weatherData = await WeatherService.getCityWeatherInfoAsync(cityData.lat, cityData.lng);
            if (!weatherData.error)
            {
               
                Console.WriteLine("temperature: " + weatherData.current_weather.temperature);
                Console.WriteLine("winddirection: " + weatherData.current_weather.winddirection);
                Console.WriteLine("temperature: " + weatherData.current_weather.temperature);
            }
            else
            {
                Console.WriteLine("Failed: " + weatherData.reason);
            }
        }
        else
        {
            Console.WriteLine("Invalid city name !");
        }
    }
}