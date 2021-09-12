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
        /// <typeparam name="T">The expected response type to be deserialized.</typeparam>
        /// <returns>A task that upon completion contains the Basket's data.</returns>
        Task<T> Get<T>(string pantryId, string basketName) where T : class;

        /// <summary>
        /// Set the Basket's content.
        /// </summary>
        /// <param name="pantryId">The Pantry containing the Basket.</param>
        /// <param name="basketName">The Basket name.</param>
        /// <param name="basketContent">The content to be put in the Basket.</param>
        Task Create(string pantryId, string basketName, object basketContent);

        /// <summary>
        /// Update the Basket's content.
        /// </summary>
        /// <param name="pantryId">The Pantry containing the Basket.</param>
        /// <param name="basketName">The Basket name.</param>
        /// <param name="basketContent">The content which will be merge with the actual Basket.</param>
        /// <typeparam name="T">The expected response type to be deserialized.</typeparam>
        /// <returns>A task that upon completion contains the Basket's data.</returns>
        Task<T> Update<T>(string pantryId, string basketName, T basketContent) where T : class;

        /// <summary>
        /// Deletes the Basket.
        /// </summary>
        /// <param name="pantryId">The Pantry containing the Basket.</param>
        /// <param name="basketName">The Basket name.</param>
        Task Delete(string pantryId, string basketName);
    }
}
