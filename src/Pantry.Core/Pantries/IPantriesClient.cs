using System.Threading;
using Pantry.Core.Pantries.Models;
using System.Threading.Tasks;

namespace Pantry.Core.Pantries
{
    /// <summary>
    /// Defines the operations available on the Pantry Pantries API.
    /// </summary>
    public interface IPantriesClient
    {
        /// <summary>
        /// Request a Pantry by id.
        /// </summary>
        /// <param name="pantryId">The pantry id.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the underlying HTTP request.</param>
        /// <returns>A task that upon completion contains the pantry's data.</returns>
        Task<GetPantryResponse> GetPantry(string pantryId, CancellationToken cancellationToken);
    }
}
