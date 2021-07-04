using System;
using Microsoft.Extensions.DependencyInjection;
using Pantry.Core;

namespace Microsoft.Extensions.Configuration
{
    public static class PantryServiceCollectionExtensions
    {
        public static IServiceCollection AddPantryLibrary(this IServiceCollection services)
        {
            services.AddHttpClient(nameof(ApiClient), c => c.BaseAddress = new Uri(PantrySettings.ApiBaseUrl));
            services.AddScoped<IApiClient, ApiClient>();
            services.AddScoped<IPantryClient, PantryClient>();

            return services;
        }
    }
}
