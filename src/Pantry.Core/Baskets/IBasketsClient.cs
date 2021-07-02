using System.Threading.Tasks;

namespace Pantry.Core.Baskets
{
    public interface IBasketsClient
    {
        Task CreateBasket(string pantryId, string basketName, object basketContent);
        Task DeleteBasket(string pantryId, string basketName);
        Task<TResult> Update<TRequest, TResult>(string pantryId, string basketName, TRequest basketContent);
        Task<T> Get<T>(string pantryId, string basketName);
    }
}
