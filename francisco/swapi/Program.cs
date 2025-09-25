using System;
using System.Net.Http;
using System.Text.Json;

namespace Swapi
{

    public partial class Swapi
    {
        private HttpClient client = new HttpClient();

        string HttpGet(HttpClient client, string query)
        {
            var json = HttpGetAsync(client, query).ConfigureAwait(false).GetAwaiter().GetResult();
            return json;
        }
        async Task<string> HttpGetAsync(HttpClient client, string query)
        {
            var response = await client.GetAsync(query.Contains("https") ? query : "https://swapi.dev/api/" + query);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            return json;
        }
    }
}