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
            if (string.IsNullOrWhiteSpace(basketName))
                throw new ArgumentNullException(nameof(basketName));

            var httpContent = new StringContent(
                JsonSerializer.Serialize(basketContent),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);

            await _apiClient.PostAsync($"{pantryId}/basket/{basketName}", httpContent);
        }

        public async Task DeleteBasket(string pantryId, string basketName)
        {
            if (string.IsNullOrWhiteSpace(basketName))
                throw new ArgumentNullException(nameof(basketName));

            await _apiClient.DeleteAsync($"{pantryId}/basket/{basketName}");
        }
    }
}
