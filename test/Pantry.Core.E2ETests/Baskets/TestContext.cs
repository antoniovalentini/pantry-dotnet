using Pantry.Core.Baskets;

namespace Pantry.Core.E2ETests.Baskets
{
    public class TestContext
    {
        public readonly PantryTestSettings TestSettings;
        public readonly BasketsClient Client;
        public const string DeleteBasketName = "delete-me";
        public const string CreateBasketName = "create-me";
        public const string PermanentBasketName = "permanent-basket";
        public const string UpdateBasketName = "update-basket";

        public TestContext()
        {
            TestSettings = TestHelpers.GetTestSettings();
            Client = new BasketsClient(new ApiClient(new DefaultHttpClientFactory()));
        }
    }

    public class TestObject
    {
        public static TestObject CreateDefault() => new TestObject
        {
            TestProp1 = "foo",
            TestProp2 = "bar",
        };

        public string TestProp1 { get; set; }
        public string TestProp2 { get; set; }
    }

    public class TestObjectSmall
    {
        public string TestProp1 { get; set; }
    }
}
