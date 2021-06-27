using Pantry.Core.Pantries;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Pantry.Core.E2ETests.Pantry
{
    public class PantryClientTests
    {
        private readonly PantryTestSettings _testSettings;
        private readonly ApiClient _apiclient;

        public PantryClientTests()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json", false)
                .Build();

            _testSettings = config.GetSection("Pantry").Get<PantryTestSettings>();
            _apiclient = new ApiClient(new PantrySettings());
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
