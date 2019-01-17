using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAppExample.Model
{
    public class ForecastAPIHelper
    {
        public static async Task<List<DailyForecast>> GetFiveDayForecast(string locationKey)
        {
            List<DailyForecast> forecast = new List<DailyForecast>();

            string url = $"https://dataservice.accuweather.com/forecasts/v1/daily/5day/{locationKey}?apikey=yhYbLiMkceMbawRZiFm1Qmq5egGbbubH";

            using (HttpClient client = new HttpClient())
            {
                var responseMessage = await client.GetAsync(url);
                string json = await responseMessage.Content.ReadAsStringAsync();

                forecast = (JsonConvert.DeserializeObject<Forecast>(json)).DailyForecasts;
            }

            return forecast;
        }
    }

    public class Limit
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }

    public class Temperature
    {
        public Limit Minimum { get; set; }
        public Limit Maximum { get; set; }
        private string stringInfo;
        public string StringInfo
        {
            get
            {
                return $"{Minimum.Value}{Minimum.Unit} - {Maximum.Value}{Maximum.Unit}";
            }
        }

        public override string ToString()
        {
            return $"{Minimum.Value}{Minimum.Unit} - {Maximum.Value}{Maximum.Unit}";
        }
    }

    public class TimeOfDay
    {
        public string IconPhrase { get; set; }
    }

    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public Temperature Temperature { get; set; }
        public TimeOfDay Day { get; set; }
        public TimeOfDay Night { get; set; }
    }

    public class Forecast
    {
        public List<DailyForecast> DailyForecasts { get; set; }
    }
}
