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
        private readonly PantrySettings _settings;

        public PantriesClient(IApiClient apiclient, PantrySettings settings)
        {
            _apiclient = apiclient;
            _settings = settings;
        }

        public async Task<GetPantryResponse> GetPantry()
        {
            return await _apiclient.GetAsync<GetPantryResponse>(_settings.PantryId);
        }
    }
}
