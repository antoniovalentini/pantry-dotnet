using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pantry.Core.E2ETests.Baskets
{
    public class BasketsClientUpdateTests : IClassFixture<TestContext>, IAsyncLifetime
    {
        private readonly TestContext _testContext;

        public BasketsClientUpdateTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public async Task UpdateBasket_ShouldSucceed()
        {
            // Arrange
            var content = TestObject.CreateDefault();
            content.TestProp1 = "not-foo";

            // Act
            var response = await _testContext.Client.Update(
                _testContext.TestSettings.Id,
                TestContext.UpdateBasketName,
                content,
                CancellationToken.None);

            // Assert
            Assert.Equal("not-foo", response.TestProp1);
            Assert.Equal("bar", response.TestProp2);
        }

        public async Task InitializeAsync()
        {
            // create the to-be-updated one
            await _testContext.Client.Create(_testContext.TestSettings.Id, TestContext.UpdateBasketName, TestObject.CreateDefault(), CancellationToken.None);
        }

        public async Task DisposeAsync()
        {
            // delete the already-updated one
            await _testContext.Client.Delete(_testContext.TestSettings.Id, TestContext.UpdateBasketName, CancellationToken.None);
        }
    }
}
