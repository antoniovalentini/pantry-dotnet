using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Pantry.Core.Pantries.Models;

namespace Pantry.Core.Pantries
{
    /// <summary>
    /// Default implementation of <see cref="IPantriesClient"/>.
    /// </summary>
    public class PantriesClient : IPantriesClient
    {
        private readonly IApiClient _apiClient;

        /// <summary>
        /// Creates a new <see cref="PantriesClient"/> instance.
        /// </summary>
        /// <param name="apiClient">The api client instance used to reach Pantry APIs.</param>
        public PantriesClient(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<GetPantryResponse> GetPantry(string pantryId, CancellationToken cancellationToken)
        {
            return await _apiClient.GetAsync<GetPantryResponse>(
                pantryId,
                cancellationToken,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }
    }
}
