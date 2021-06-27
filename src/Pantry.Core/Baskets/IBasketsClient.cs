using System.Threading.Tasks;

namespace Pantry.Core.Baskets
{
    public interface IBasketsClient
    {
        Task CreateBasket(string pantryId, string basketName, object basketContent);
        Task DeleteBasket(string pantryId, string basketName);
    }
}
