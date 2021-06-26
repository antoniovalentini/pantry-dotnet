using Pantry.Core.Pantry.Models;
using System.Threading.Tasks;

namespace Pantry.Core.Pantry
{
    public interface IPantryClient
    {
        Task<GetPantryResponse> GetPantry();
    }
}
