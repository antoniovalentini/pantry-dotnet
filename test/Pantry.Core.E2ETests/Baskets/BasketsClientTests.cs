using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Pantry.Core.Baskets;
using Xunit;

namespace Pantry.Core.E2ETests.Baskets
{
    public class BasketsClientTests
    {
        private readonly PantryTestSettings _testSettings;
        private readonly ApiClient _apiclient;

        public BasketsClientTests()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json", false)
                .Build();

            _testSettings = config.GetSection("Pantry").Get<PantryTestSettings>();
            _apiclient = new ApiClient(new PantrySettings());
        }

        [Fact]
        public async Task CreateBasket_ShouldSucceed()
        {
            var client = new BasketsClient(_apiclient);
            var ex = await Record.ExceptionAsync(
                    async () => await client.CreateBasket(_testSettings.Id, "test3-basket", new TestObject())
                );
            Assert.Null(ex);
        }
    }

    public class TestObject
    {
        public string TestProp1 { get; set; } = "foo";
        public string TestProp2 { get; set; } = "bar";
    }
}
