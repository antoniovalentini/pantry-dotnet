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

        public async Task<TResult> Update<TRequest, TResult>(string pantryId, string basketName, TRequest basketContent)
        {
            pantryId.ThrowIfNullOrWhiteSpace();
            basketName.ThrowIfNullOrWhiteSpace();

            var httpContent = new StringContent(
                JsonSerializer.Serialize(basketContent),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);

            return await _apiClient.PutAsync<TResult>($"{pantryId}/basket/{basketName}", httpContent);
        }

        public async Task<T> Get<T>(string pantryId, string basketName)
        {
            pantryId.ThrowIfNullOrWhiteSpace();
            basketName.ThrowIfNullOrWhiteSpace();

            return await _apiClient.GetAsync<T>($"{pantryId}/basket/{basketName}");
        }
    }
}
