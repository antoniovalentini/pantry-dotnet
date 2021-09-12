using System.Threading.Tasks;

namespace Pantry.Core.Baskets
{
    public interface IBasketsClient
    {
        Task<T> Get<T>(string pantryId, string basketName) where T : class;
        Task Create(string pantryId, string basketName, object basketContent);
        Task<T> Update<T>(string pantryId, string basketName, T basketContent) where T : class;
        Task Delete(string pantryId, string basketName);
    }
}
