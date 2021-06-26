using Pantry.Core.Pantry;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Pantry.Core.E2ETests.Pantry
{
    public class PantryClientTests
    {
        private readonly PantrySettings _pantrySettings;
        private readonly PantryTestSettings _testSettings;
        private readonly ApiClient _apiclient;

        public PantryClientTests()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json", false)
                .Build();

            _testSettings = config.GetSection("Pantry").Get<PantryTestSettings>();
            _pantrySettings = new PantrySettings {PantryId = _testSettings.Id};
            _apiclient = new ApiClient(_pantrySettings);
        }

        [Fact]
        public async Task GetPantry_ShouldSucceed()
        {
            var client = new PantryClient(_apiclient, _pantrySettings);
            var pantry = await client.GetPantry();
            Assert.NotNull(pantry);
            Assert.Equal(_testSettings.Name, pantry.Name);
            Assert.Equal(_testSettings.Description, pantry.Description);
        }
    }
}
