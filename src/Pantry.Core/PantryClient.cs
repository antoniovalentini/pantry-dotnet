using Pantry.Core.Baskets;
using Pantry.Core.Pantries;

namespace Pantry.Core
{
    public class PantryClient : IPantryClient
    {
        public PantryClient(IApiClient apiClient)
        {
            Pantries = new PantriesClient(apiClient);
            Baskets = new BasketsClient(apiClient);
        }

        public IPantriesClient Pantries { get; }
        public IBasketsClient Baskets { get; }
    }
}
