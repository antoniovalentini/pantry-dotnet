using System;
using System.Net.Http;
using Pantry.Core.Pantries;
using System.Threading.Tasks;
using Xunit;

namespace Pantry.Core.E2ETests.Pantry
{
    public class PantryClientTests
    {
        private readonly PantryTestSettings _testSettings;
        private readonly ApiClient _apiclient;

        public PantryClientTests()
        {
            _testSettings = TestHelpers.GetTestSettings();
            _apiclient = new ApiClient(new HttpClient {BaseAddress = new Uri(PantrySettings.ApiBaseUrl)});
        }

        [Fact]
        public async Task GetPantry_ShouldSucceed()
        {
            var client = new PantriesClient(_apiclient);
            var pantry = await client.GetPantry(_testSettings.Id);
            Assert.NotNull(pantry);
            Assert.Equal(_testSettings.Name, pantry.Name);
            Assert.Equal(_testSettings.Description, pantry.Description);
        }
    }
}
