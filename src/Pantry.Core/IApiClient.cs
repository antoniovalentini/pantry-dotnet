using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pantry.Core
{
    public interface IApiClient
    {
        Task<TResult> GetAsync<TResult>(string path, JsonSerializerOptions serializerOptions = null);
        Task PostAsync(string path, HttpContent httpContent);
        Task DeleteAsync(string path);
        Task<TResult> PutAsync<TResult>(string path, HttpContent httpContent);
        Task<string> PutAsync(string path, HttpContent httpContent);
        public string GetHttpClientBaseAddress();
    }
}
