using System.Threading.Tasks;
using Pantry.Core.Baskets;
using Xunit;

namespace Pantry.Core.E2ETests.Baskets
{
    public class TestContext : IAsyncLifetime
    {
        public readonly PantryTestSettings TestSettings;
        public readonly BasketsClient Client;
        public const string DeleteBasketName = "delete-me";
        public const string CreateBasketName = "create-me";

        public TestContext()
        {
            TestSettings = TestHelpers.GetTestSettings();
            Client = new BasketsClient(new ApiClient());
        }

        public async Task InitializeAsync()
        {
            // create the to-be-deleted one
            await Client.CreateBasket(TestSettings.Id, DeleteBasketName, new TestObject());
        }

        public async Task DisposeAsync()
        {
            // delete the already-created one
            await Client.DeleteBasket(TestSettings.Id, CreateBasketName);
        }
    }
}
