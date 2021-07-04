using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pantry.Core;
using Xunit;

namespace Pantry.Extensions.Microsoft.UnitTests
{
    public class PantryServiceCollectionExtensionsTests
    {
        [Fact]
        public void IApiClient_ShouldHavePantryUrlAsBaseUrl()
        {
            var provider = new ServiceCollection().AddPantryLibrary().BuildServiceProvider();
            var apiClient = provider.GetRequiredService<IApiClient>();
            Assert.Equal(PantrySettings.ApiBaseUrl, apiClient.GetHttpClientBaseAddress());
        }
    }
}
