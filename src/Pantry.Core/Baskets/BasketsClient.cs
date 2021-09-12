using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Mime;

namespace Pantry.Core.Baskets
{
    /// <summary>
    /// Default implementation of <see cref="IBasketsClient"/>.
    /// </summary>
    public class BasketsClient : IBasketsClient
    {
        private readonly IApiClient _apiClient;

        public BasketsClient(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task CreateBasket(string pantryId, string basketName, object basketContent)
        {
            pantryId.ThrowIfNullOrWhiteSpace();
            basketName.ThrowIfNullOrWhiteSpace();

            var httpContent = new StringContent(
                JsonSerializer.Serialize(basketContent),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);

            await _apiClient.PostAsync($"{pantryId}/basket/{basketName}", httpContent);
        }

        public async Task DeleteBasket(string pantryId, string basketName)
        {
            pantryId.ThrowIfNullOrWhiteSpace();
            basketName.ThrowIfNullOrWhiteSpace();

            await _apiClient.DeleteAsync($"{pantryId}/basket/{basketName}");
        }

        public async Task<string> Update(string pantryId, string basketName, string basketContent)
        {
            JsonDocument.Parse(basketContent);
            var httpContent = new StringContent(basketContent, Encoding.UTF8, MediaTypeNames.Application.Json);
            return await _apiClient.PutAsync($"{pantryId}/basket/{basketName}", httpContent);
        }

        public async Task<T> Update<T>(string pantryId, string basketName, T basketContent)
        {
            pantryId.ThrowIfNullOrWhiteSpace();
            basketName.ThrowIfNullOrWhiteSpace();

            if (basketContent is string)
            {
                throw new NotSupportedException("string content is not supported by this method.");
            }

            var httpContent = new StringContent(
                JsonSerializer.Serialize(basketContent),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);

            return await _apiClient.PutAsync<T>($"{pantryId}/basket/{basketName}", httpContent);
        }

        public async Task<T> Get<T>(string pantryId, string basketName)
        {
            pantryId.ThrowIfNullOrWhiteSpace();
            basketName.ThrowIfNullOrWhiteSpace();

            return await _apiClient.GetAsync<T>($"{pantryId}/basket/{basketName}");
        }
    }
}
