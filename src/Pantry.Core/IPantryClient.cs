using Pantry.Core.Baskets;
using Pantry.Core.Pantries;

namespace Pantry.Core
{
    /// <summary>
    /// Wrapper interface that provides access to the available Pantry APIs.
    /// </summary>
    public interface IPantryClient
    {
        /// <summary>
        /// Gets the Pantries API.
        /// </summary>
        IPantriesClient Pantries { get; }

        /// <summary>
        /// Gets the Baskets API.
        /// </summary>
        IBasketsClient Baskets { get; }
    }
}
