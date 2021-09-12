using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Pantry.Core;

namespace Microsoft.Extensions.Configuration
{
    /// <summary>
    /// This class adds extension methods to IServiceCollection making it easier to add the Checkout client
    /// to the NET Core dependency injection framework.
    /// </summary>
    public static class PantryServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the default Pantry Client services to the provided <paramref name="services"/>.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        /// <param name="configureHandler">Additional http handlers configuration.</param>
        /// <returns>The service collection with registered Pantry Client services.</returns>
        public static IServiceCollection AddPantryLibrary(this IServiceCollection services, Func<HttpMessageHandler> configureHandler = null)
        {
            var clientBuilder = services.AddHttpClient<IApiClient, ApiClient>(c =>
            {
                c.BaseAddress = new Uri(PantrySettings.ApiBaseUrl);
            });

            if (configureHandler is { })
                clientBuilder.ConfigurePrimaryHttpMessageHandler(configureHandler);

            services.AddScoped<IPantryClient, PantryClient>();

            return services;
        }
    }
}
