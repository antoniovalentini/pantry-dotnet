using System.Threading.Tasks;
using Xunit;

namespace Pantry.Core.E2ETests.Baskets
{
    public class BasketsClientGetTests : IClassFixture<TestContext>
    {
        private readonly TestContext _testContext;

        public BasketsClientGetTests(TestContext testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public async Task GetBasket_ShouldSucceed()
        {
            var testObject = await _testContext.Client.Get<TestObject>(_testContext.TestSettings.Id, TestContext.PermanentBasketName);
            Assert.Equal("foo", testObject.TestProp1);
            Assert.Equal("bar", testObject.TestProp2);
        }
    }
}
