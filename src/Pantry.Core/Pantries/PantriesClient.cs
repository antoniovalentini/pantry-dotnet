using System.Text.Json;
using System.Threading.Tasks;
using Pantry.Core.Pantries.Models;

namespace Pantry.Core.Pantries
{
    /// <summary>
    /// Default implementation of <see cref="IPantriesClient"/>.
    /// </summary>
    public class PantriesClient : IPantriesClient
    {
        private readonly IApiClient _apiclient;

        public PantriesClient(IApiClient apiclient)
        {
            _apiclient = apiclient;
        }

        public async Task<GetPantryResponse> GetPantry(string pantryId)
        {
            return await _apiclient.GetAsync<GetPantryResponse>(pantryId, new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }
    }
}
