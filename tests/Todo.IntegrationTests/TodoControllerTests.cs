using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Todo.Api.Contracts;
using Todo.Api.Repositories;

namespace Todo.IntegrationTests;

public class TodoControllerTests : IntegrationTestBase
{
    public TodoControllerTests(TestWebApplicationFactory factory) : base(factory)
    {
    }
    
    [Fact]
    public async Task Create_Should_CreateSuccessfully()
    {
        //Arrange
        using var scope = Factory.Services.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<ITodoRepository>();
        
        var request = new CreateTodoContract()
        {
            Description = "Test",
            Title = "Test"
        };

        //Act
        var response = await Client.PostAsJsonAsync("/Todo", request);

        //Assert
        response.EnsureSuccessStatusCode();
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var todo = await response.Content.ReadFromJsonAsync<Api.Models.Todo>();
        var storedTodo = repository.GetById(todo.Id);

        storedTodo.Should().NotBeNull();
        storedTodo.Description.Should().Be(request.Description);
        storedTodo.Title.Should().Be(request.Title);
    }
}