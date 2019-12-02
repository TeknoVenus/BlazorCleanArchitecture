using System.Net.Http;

namespace Infrastructure.Data.TypedHttpClient
{
    /// <summary>
    /// Strongly typed instance of HttpClient for connecting to Wonde API that can be injected where needed via HttpClientFactory
    /// </summary>
    public class WondeClient
    {
        public HttpClient Client;

        public WondeClient(HttpClient client)
        {
            Client = client;
        }
    }
}