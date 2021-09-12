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
        /// <summary>
        /// Executes a GET request to the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The API resource path.</param>
        /// <param name="serializerOptions">The serializer options used to properly deserialize the response.</param>
        /// <typeparam name="T">The expected response type to be deserialized.</typeparam>
        /// <returns>A task that upon completion contains the specified API response data.</returns>
        Task<T> GetAsync<T>(string path, JsonSerializerOptions serializerOptions = null);

        /// <summary>
        /// Executes a POST request to the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The API resource path.</param>
        /// <param name="httpContent">The http content to be sent.</param>
        Task PostAsync(string path, HttpContent httpContent);

        /// <summary>
        /// Executes a DELETE request to the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The API resource path.</param>
        Task DeleteAsync(string path);

        /// <summary>
        /// Executes a PUT request to the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The API resource path.</param>
        /// <param name="httpContent">The http content to be sent.</param>
        /// <typeparam name="T">The expected response type to be deserialized.</typeparam>
        /// <returns>A task that upon completion contains the specified API response data.</returns>
        Task<T> PutAsync<T>(string path, HttpContent httpContent);

        /// <summary>
        /// Helper method to access the current HttpClient Uri.
        /// </summary>
        /// <returns>The HttpClient Uri.</returns>
        public string GetHttpClientBaseAddress();
    }
}
