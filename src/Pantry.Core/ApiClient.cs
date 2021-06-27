using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pantry.Core
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;

        /// <summary>
        /// Creates a new <see cref="ApiClient"/> instance with the provided configuration.
        /// </summary>
        public ApiClient()
        {
            _serializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            _httpClient = new HttpClient { BaseAddress = new Uri(PantrySettings.ApiBaseUrl) };
        }

        public async Task<TResult> GetAsync<TResult>(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

            var response = await _httpClient.GetAsync(path);
            if (!response.IsSuccessStatusCode) throw new Exception($"Error getting the pantry: {response.StatusCode}");

            var json = await response.Content.ReadAsStringAsync();
            return !string.IsNullOrWhiteSpace(json)
                ? JsonSerializer.Deserialize<TResult>(json, _serializerOptions)
                : default;
        }

        public async Task<string> PostAsync(string path, HttpContent httpContent)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

            var response = await _httpClient.PostAsync(path, httpContent);
            if (!response.IsSuccessStatusCode) throw new Exception($"Error creating the pantry: {response.StatusCode}");

            return await response.Content.ReadAsStringAsync();
        }

        public async Task DeleteAsync(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

            var response = await _httpClient.DeleteAsync(path);
            if (!response.IsSuccessStatusCode) throw new Exception($"Error creating the pantry: {response.StatusCode}");

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
