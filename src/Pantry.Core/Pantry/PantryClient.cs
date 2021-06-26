using Pantry.Core.Pantry.Models;
using System.Threading.Tasks;

namespace Pantry.Core.Pantry
{
    /// <summary>
    /// Default implementation of <see cref="IPantryClient"/>.
    /// </summary>
    public class PantryClient : IPantryClient
    {
        private readonly IApiClient _apiclient;
        private readonly PantrySettings _settings;

        public PantryClient(IApiClient apiclient, PantrySettings settings)
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
