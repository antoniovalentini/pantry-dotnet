using System.Threading.Tasks;
using Xunit;

namespace Pantry.Core.E2ETests.Baskets
{
    public class BasketsClientTests : IClassFixture<TestContext>
    {
        private readonly TestContext _testContext;

        public BasketsClientTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public async Task CreateBasket_ShouldSucceed()
        {
            var ex = await Record.ExceptionAsync(
                    async () => await _testContext.Client.CreateBasket(_testContext.TestSettings.Id, TestContext.CreateBasketName, new TestObject())
                );
            Assert.Null(ex);
        }

        [Fact]
        public async Task DeleteBasket_ShouldSucceed()
        {
            await _testContext.Client.CreateBasket(_testContext.TestSettings.Id, TestContext.DeleteBasketName, new TestObject());
            var ex = await Record.ExceptionAsync(async () => await _testContext.Client.DeleteBasket(_testContext.TestSettings.Id, TestContext.DeleteBasketName));
            Assert.Null(ex);
        }
    }

    public class TestObject
    {
        public string TestProp1 { get; set; } = "foo";
        public string TestProp2 { get; set; } = "bar";
    }
}
