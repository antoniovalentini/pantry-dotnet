using Pantry.Core.Baskets;
using Pantry.Core.Pantries;

namespace Pantry.Core
{
    /// <summary>
    /// Default implementation of <see cref="IPantryClient"/> that defines the available Pantry APIs.
    /// </summary>
    public class PantryClient : IPantryClient
    {
        /// <summary>
        /// Creates a new <see cref="PantryClient"/> instance and initializes each underlying API client.
        /// </summary>
        /// <param name="apiClient">The API client used to send API requests and handle responses.</param>
        public PantryClient(IApiClient apiClient)
        {
            Pantries = new PantriesClient(apiClient);
            Baskets = new BasketsClient(apiClient);
        }

        /// <summary>
        /// Gets the Pantries API.
        /// </summary>
        public IPantriesClient Pantries { get; }

        // Gets the Baskets API.
        public IBasketsClient Baskets { get; }
    }
}
