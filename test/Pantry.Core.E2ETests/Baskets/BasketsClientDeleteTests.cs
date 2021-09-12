using System.Threading.Tasks;
using Xunit;

namespace Pantry.Core.E2ETests.Baskets
{
    public class BasketsClientDeleteTests : IClassFixture<TestContext>, IAsyncLifetime
    {
        private readonly TestContext _testContext;

        public BasketsClientDeleteTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        public async Task InitializeAsync()
        {
            // create the to-be-deleted one
            await _testContext.Client.Create(_testContext.TestSettings.Id, TestContext.DeleteBasketName, TestObject.CreateDefault());
        }

        [Fact]
        public async Task DeleteBasket_ShouldSucceed()
        {
            await _testContext.Client.Create(_testContext.TestSettings.Id, TestContext.DeleteBasketName, TestObject.CreateDefault());
            var ex = await Record.ExceptionAsync(async () => await _testContext.Client.Delete(_testContext.TestSettings.Id, TestContext.DeleteBasketName));
            Assert.Null(ex);
        }

        public Task DisposeAsync() => Task.CompletedTask;
    }
}
