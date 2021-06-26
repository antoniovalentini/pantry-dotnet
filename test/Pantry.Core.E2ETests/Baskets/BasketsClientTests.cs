using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Pantry.Core.Baskets;
using Xunit;

namespace Pantry.Core.E2ETests.Baskets
{
    public class BasketsClientTests
    {
        private readonly PantrySettings _pantrySettings;
        private readonly ApiClient _apiclient;

        public BasketsClientTests()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json", false)
                .Build();

            var testSettings = config.GetSection("Pantry").Get<PantryTestSettings>();
            _pantrySettings = new PantrySettings {PantryId = testSettings.Id};
            _apiclient = new ApiClient(_pantrySettings);
        }

        [Fact]
        public async Task CreateBasket_ShouldSucceed()
        {
            var client = new BasketsClient(_apiclient, _pantrySettings);
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
