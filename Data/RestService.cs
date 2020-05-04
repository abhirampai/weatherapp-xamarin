using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using weatherapp.Models;
using Newtonsoft.Json;

namespace weatherapp.Data
{
    public class RestService
    {
        HttpClient client;
        public RestService() {
            client = new HttpClient();
        }
        public async Task<weather> GetWeather(string Location) {
            var url = string.Format(Constants.Weatherurl, Location);
            var json = await client.GetStringAsync(url);
            if (string.IsNullOrWhiteSpace(json))
                return null;
            var result= JsonConvert.DeserializeObject<weather>(json);
            return result;
        }




    }
}
