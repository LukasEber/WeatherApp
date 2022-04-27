using System;
using Newtonsoft.Json;
using WeatherApp;

namespace WeatherApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter city: ");
            Weather.City = Console.ReadLine();
            try
            {
                Weather.GetNewWeatherData();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unhandled error has occured. Please check your inputs." + ex.Message);
            }
            Console.ReadKey();
        }
    }
}