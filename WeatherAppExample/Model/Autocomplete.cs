using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAppExample.Model
{
    public class Autocomplete
    {
        public Autocomplete()
        {
        }

        public static async Task<List<Location>> GetLocations(string query)
        {
            List<Location> locations = new List<Location>();

            string url = $"https://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey=yhYbLiMkceMbawRZiFm1Qmq5egGbbubH&q={query}";

            using (HttpClient client = new HttpClient())
            {
                var responseMessage = await client.GetAsync(url);
                var json = await responseMessage.Content.ReadAsStringAsync();

                locations = JsonConvert.DeserializeObject<List<Location>>(json);
            }

            return locations;
        }
    }

    public class Area
    {
        public string LocalizedName { get; set; }
    }

    public class Location
    {
        public string Key { get; set; }
        public string LocalizedName { get; set; }
        public Area Country { get; set; }
        public Area AdministrativeArea { get; set; }
    }
}
