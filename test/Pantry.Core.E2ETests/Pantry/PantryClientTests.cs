using System.IO;
using System.Text.Json;
using Pantry.Core.Pantry;
using System.Threading.Tasks;
using Xunit;

namespace Pantry.Core.E2ETests.Pantry
{
    public class PantryClientTests
    {
        [Fact]
        public async Task GetPantry_ShouldSucceed()
        {
            var rawSettings = await File.ReadAllTextAsync("appsettings.test.json");
            var testSettings = JsonSerializer.Deserialize<PantryTestSettings>(rawSettings);
            Assert.NotNull(testSettings);
            var settings = new PantrySettings {PantryId = testSettings.Id};

            var apiclient = new ApiClient(settings);
            var client = new PantryClient(apiclient, settings);
            var pantry = await client.GetPantry();
            Assert.NotNull(pantry);
            Assert.Equal(testSettings.Name, pantry.Name);
            Assert.Equal(testSettings.Description, pantry.Description);
        }

        [Fact]
        public async Task CreateBasket_ShouldSucceed()
        {
            var settings = new PantrySettings();

            var apiclient = new ApiClient(settings);
            var client = new Baskets.BasketsClient(apiclient, settings);
            var ex = await Record.ExceptionAsync(async () => await client.CreateBasket("test3-basket", new TestObject()));
            Assert.Null(ex);
        }
    }

    public class TestObject
    {
        public string TestProp1 { get; set; } = "foo";
        public string TestProp2 { get; set; } = "bar";
    }
}
