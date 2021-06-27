using Pantry.Core.Pantries.Models;
using System.Threading.Tasks;

namespace Pantry.Core.Pantries
{
    public interface IPantriesClient
    {
        Task<GetPantryResponse> GetPantry(string pantryId);
    }
}
