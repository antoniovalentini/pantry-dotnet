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
        private readonly PantrySettings _settings;

        public BasketsClient(IApiClient apiClient, PantrySettings settings)
        {
            _apiClient = apiClient;
            _settings = settings;
        }

        public async Task CreateBasket(string basketName, object basketContent)
        {
            if (string.IsNullOrWhiteSpace(basketName))
                throw new ArgumentNullException(nameof(basketName));

            var httpContent = new StringContent(
                JsonSerializer.Serialize(basketContent),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);

            await _apiClient.PostAsync($"{_settings.PantryId}/basket/{basketName}", httpContent);
        }
    }
}
