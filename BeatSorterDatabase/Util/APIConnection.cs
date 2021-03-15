using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;

namespace BeatSorterDatabase.Util
{
    public class APIConnection
    {

        public async Task<T> GetAsync<T>(string uri)
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("PostmanRuntime", "7.26.8"));
            var content = await httpClient.SendAsync(request);
            return await Task.Run(async () => JsonSerializer.Deserialize<T>(await content.Content.ReadAsStringAsync()));
        }

    }
}
