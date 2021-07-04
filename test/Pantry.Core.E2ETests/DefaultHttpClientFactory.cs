using System;
using System.Net.Http;

namespace Pantry.Core.E2ETests
{
    public class DefaultHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            return new() {BaseAddress = new Uri(PantrySettings.ApiBaseUrl)};
        }
    }
}
