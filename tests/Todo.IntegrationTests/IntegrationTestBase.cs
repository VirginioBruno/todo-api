using Microsoft.AspNetCore.Mvc.Testing;

namespace Todo.IntegrationTests;

public abstract class IntegrationTestBase : IClassFixture<TestWebApplicationFactory>
{
    protected readonly HttpClient Client;
    protected readonly TestWebApplicationFactory Factory;

    protected IntegrationTestBase(TestWebApplicationFactory factory)
    {
        Factory = factory;
        Client = factory.CreateClient();
    }
}