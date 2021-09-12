using System.Threading;
using System.Threading.Tasks;

namespace Pantry.Core.Baskets
{
    /// <summary>
    /// Defines the operations available on the Pantry Baskets API.
    /// </summary>
    public interface IBasketsClient
    {
        /// <summary>
        /// Request a Basket by name.
        /// </summary>
        /// <param name="pantryId">The Pantry containing the Basket.</param>
        /// <param name="basketName">The Basket name.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the underlying HTTP request.</param>
        /// <typeparam name="T">The expected response type to be deserialized.</typeparam>
        /// <returns>A task that upon completion contains the Basket's data.</returns>
        Task<T> Get<T>(string pantryId, string basketName, CancellationToken cancellationToken) where T : class;

        /// <summary>
        /// Set the Basket's content.
        /// </summary>
        /// <param name="pantryId">The Pantry containing the Basket.</param>
        /// <param name="basketName">The Basket name.</param>
        /// <param name="basketContent">The content to be put in the Basket.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the underlying HTTP request.</param>
        Task Create(string pantryId, string basketName, object basketContent, CancellationToken cancellationToken);

        /// <summary>
        /// Update the Basket's content.
        /// </summary>
        /// <param name="pantryId">The Pantry containing the Basket.</param>
        /// <param name="basketName">The Basket name.</param>
        /// <param name="basketContent">The content which will be merge with the actual Basket.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the underlying HTTP request.</param>
        /// <typeparam name="T">The expected response type to be deserialized.</typeparam>
        /// <returns>A task that upon completion contains the Basket's data.</returns>
        Task<T> Update<T>(string pantryId, string basketName, T basketContent, CancellationToken cancellationToken) where T : class;

        /// <summary>
        /// Deletes the Basket.
        /// </summary>
        /// <param name="pantryId">The Pantry containing the Basket.</param>
        /// <param name="basketName">The Basket name.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the underlying HTTP request.</param>
        Task Delete(string pantryId, string basketName, CancellationToken cancellationToken);
    }
}
