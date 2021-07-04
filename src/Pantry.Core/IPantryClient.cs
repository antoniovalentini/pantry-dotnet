using Pantry.Core.Baskets;
using Pantry.Core.Pantries;

namespace Pantry.Core
{
    public interface IPantryClient
    {
        IPantriesClient Pantries { get; }
        IBasketsClient Baskets { get; }
    }
}
