using System;
using Newtonsoft.Json;
using WeatherApp;

namespace WeatherApp
{
    public class Program
    {
        private static char newCity = 'y';
        static void Main(string[] args)
        {
           
            while(newCity == 'y')
            {
                Console.WriteLine("Enter city: ");
                Weather.City = Console.ReadLine();

                try
                {
                    Weather.GetNewWeatherData();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unhandled error has occured. Please check your inputs.");
                }
                finally
                {
                    NewCity();
                }
            }
            Console.ReadKey();
        }

        static void NewCity()
        {
            Console.WriteLine("New city? y/n:");
            try
            {
                newCity = char.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("invalid input.");
                NewCity();
            }
        }
    }
}