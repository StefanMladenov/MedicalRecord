using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class UserService
    {
        private string _apiBaseURI = "https://localhost:5001/api/";

        public async Task<T> RequestAsync<T>(HttpMethod method, string path, string user = null) where T: class
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseURI);
            if(!string.IsNullOrEmpty(user))
            {
                client.DefaultRequestHeaders.Add("Authorization", user);
            }
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, path);

            var res = await client.SendAsync(httpRequestMessage);

            if (res.IsSuccessStatusCode)
            {
                var data = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }

            return null;
        }
    }
}
