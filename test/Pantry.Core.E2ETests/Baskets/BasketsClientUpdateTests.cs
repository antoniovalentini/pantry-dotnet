using System.Text.Json;
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
            var response = await _testContext.Client.Update<TestObjectSmall, TestObject>(_testContext.TestSettings.Id, TestContext.UpdateBasketName,
                new TestObjectSmall { TestProp1 = "not-foo"});
            Assert.Equal("not-foo", response.TestProp1);
            Assert.Equal("bar", response.TestProp2);
        }

        [Fact]
        public async Task UpdateBasket_PlainText_ShouldSucceed()
        {
            await _testContext.Client.Update(
                _testContext.TestSettings.Id,
                TestContext.UpdateBasketName,
                JsonSerializer.Serialize(new TestObjectSmall { TestProp1 = "not-foo"}) );
            var response =
                await _testContext.Client.Get<TestObjectSmall>(
                    _testContext.TestSettings.Id,
                    TestContext.UpdateBasketName);
            Assert.Equal("not-foo", response.TestProp1);
        }

        public async Task InitializeAsync()
        {
            // create the to-be-updated one
            await _testContext.Client.CreateBasket(_testContext.TestSettings.Id, TestContext.UpdateBasketName, TestObject.CreateDefault());
        }

        public async Task DisposeAsync()
        {
            // delete the already-updated one
            await _testContext.Client.DeleteBasket(_testContext.TestSettings.Id, TestContext.UpdateBasketName);
        }
    }
}
