using System.Net.Http;
using System.Threading.Tasks;

namespace Pantry.Core
{
    public interface IApiClient
    {
        Task<TResult> GetAsync<TResult>(string path);
        Task PostAsync(string path, HttpContent httpContent);
        Task DeleteAsync(string path);
    }
}
