using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pantry.Core
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Creates a new <see cref="ApiClient"/> instance with the provided configuration.
        /// </summary>
        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TResult> GetAsync<TResult>(string path, JsonSerializerOptions serializerOptions = null)
        {
            path.ThrowIfNullOrWhiteSpace();

            var response = await _httpClient.GetAsync(path);
            if (!response.IsSuccessStatusCode) throw new Exception($"Error getting the pantry: {response.StatusCode}");

            var json = await response.Content.ReadAsStringAsync();
            return DeserializeAsync<TResult>(json, serializerOptions);
        }

        public async Task PostAsync(string path, HttpContent httpContent)
        {
            path.ThrowIfNullOrWhiteSpace();

            var response = await _httpClient.PostAsync(path, httpContent);
            if (!response.IsSuccessStatusCode) throw new Exception($"Error creating the pantry: {response.StatusCode}");
        }

        public async Task DeleteAsync(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

            var response = await _httpClient.DeleteAsync(path);
            if (!response.IsSuccessStatusCode) throw new Exception($"Error deleting the pantry: {response.StatusCode}");
        }

        public async Task<TResult> PutAsync<TResult>(string path, HttpContent httpContent)
        {
            path.ThrowIfNullOrWhiteSpace();
            var response = await _httpClient.PutAsync(path, httpContent);
            if (!response.IsSuccessStatusCode) throw new Exception($"Error updating the pantry: {response.StatusCode}");

            var json = await response.Content.ReadAsStringAsync();
            return DeserializeAsync<TResult>(json);

        }

        private static T DeserializeAsync<T>(string json, JsonSerializerOptions serializerOptions = null)
        {
            json.ThrowIfNullOrWhiteSpace();

            var result = serializerOptions is null
                ? JsonSerializer.Deserialize<T>(json)
                : JsonSerializer.Deserialize<T>(json, serializerOptions);

            return result ?? default;
        }
    }
}
