using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Pantry.Core;

namespace Microsoft.Extensions.Configuration
{
    public static class PantryServiceCollectionExtensions
    {
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
