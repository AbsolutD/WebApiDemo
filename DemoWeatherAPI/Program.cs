using DemoWeatherAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DemoWeatherAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsnyc().Wait();
        }

        static HttpClient client = new HttpClient();

        static string CityId = "7284830"; // Budapest XIII. kerulet
        static string WrongCityId = "NAGYON ROSSZ"; // for testing 
        static string ApiKey = "741b94ff3d88b65f07fad5c88f820c9e"; // Saját Api kulcs https://openweathermap.org/api
        static string WrongApiKey = "NAGYON ROSSZ"; // for testing
        static string RequestPath = "?id=" + CityId + "&APPID=" + ApiKey;

        static int MaxReportToShow = 4; // maximum number of wheather reports to show on console

        static async Task RunAsnyc()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/forecast");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            try
            {
                HttpResponseMessage response = await client.GetAsync(RequestPath);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    CurrentWeatherRoot result = await response.Content.ReadAsAsync<CurrentWeatherRoot>();
                    Console.WriteLine(LogCurrentWeather(result));
                }
                else
                {
                    Console.WriteLine("Request failed. Response status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }

        static string LogCurrentWeather(CurrentWeatherRoot wheaterObject)
        {
            string result = "";
            result += "City name: " + wheaterObject.city.name + " \n";
            result += "City id: " + wheaterObject.city.id + " \n";
            result += "Wheather reports: \n";
            if (wheaterObject.list != null)
            {
                for (int i = 0; i < wheaterObject.list.Count && i < MaxReportToShow; i++)
                {
                    result += "\t Date: " + wheaterObject.list[i].dt_txt + " \n";
                    result += "\t Temperature: " + wheaterObject.list[i].main.temp + " \n";
                    result += "\t Humidity: " + wheaterObject.list[i].main.humidity + " \n";
                    if (wheaterObject.list[i].weather != null && wheaterObject.list[i].weather.Count > 0)
                    {
                        result += "\t Wheather: " + wheaterObject.list[i].weather[0].description + " \n";
                    }
                    result += "\t --- \n";
                }
            }
            return result;
        }


    }

    // Useful links:
    // https://openweathermap.org/api Website of the service
    // http://json2csharp.com/ Generate C# classes from json
    // https://www.getpostman.com/ Postman (to try out the get request)
    // https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client 
}
