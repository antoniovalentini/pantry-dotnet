using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pantry.Core.E2ETests.Baskets
{
    public class BasketsClientCreateTests : IClassFixture<TestContext>, IAsyncLifetime
    {
        private readonly TestContext _testContext;

        public BasketsClientCreateTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public async Task CreateBasket_ShouldSucceed()
        {
            var ex = await Record.ExceptionAsync(
                    async () => await _testContext.Client.Create(_testContext.TestSettings.Id, TestContext.CreateBasketName, TestObject.CreateDefault(), CancellationToken.None)
                );
            Assert.Null(ex);
        }

        public Task InitializeAsync() => Task.CompletedTask;

        public async Task DisposeAsync()
        {
            // delete the already-created one
            await _testContext.Client.Delete(_testContext.TestSettings.Id, TestContext.CreateBasketName, CancellationToken.None);
        }
    }
}
