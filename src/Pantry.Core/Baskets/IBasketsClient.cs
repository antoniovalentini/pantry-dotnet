using System.Threading.Tasks;

namespace Pantry.Core.Baskets
{
    public interface IBasketsClient
    {
        Task CreateBasket(string pantryId, string basketName, object basketContent);
        Task DeleteBasket(string pantryId, string basketName);
        Task<T> Update<T>(string pantryId, string basketName, T basketContent);
        Task<string> Update(string pantryId, string basketName, string basketContent);
        Task<T> Get<T>(string pantryId, string basketName);
    }
}
