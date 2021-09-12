using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pantry.Core
{
    /// <summary>
    /// Defines the basic methods used for communicating with Pantry's APIs.
    /// </summary>
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string path, JsonSerializerOptions serializerOptions = null);
        Task PostAsync(string path, HttpContent httpContent);
        Task DeleteAsync(string path);
        Task<T> PutAsync<T>(string path, HttpContent httpContent);
        public string GetHttpClientBaseAddress();
    }
}
