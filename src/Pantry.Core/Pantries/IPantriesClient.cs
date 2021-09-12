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
        /// <returns>A task that upon completion contains the pantry's data.</returns>
        Task<GetPantryResponse> GetPantry(string pantryId);
    }
}
