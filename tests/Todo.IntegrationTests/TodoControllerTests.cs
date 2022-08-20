using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todo.Api.Contracts;
using Todo.Api.Controllers;
using Todo.Api.Repositories;

namespace Todo.IntegrationTests;

public class TodoControllerTests
{
    private readonly TodoController _controller;
    public TodoControllerTests()
    {
        _controller = new TodoController(new Mock<ILogger<TodoController>>().Object, new Mock<ITodoRepository>().Object);
    }
    
    [Fact]
    public void Create_Should_CreateSuccessfully()
    {
        //Arrange
        var request = new CreateTodoContract()
        {
            Description = "Test",
            Title = "Test"
        };

        //Act
        var result = _controller.Create(request);

        //Assert
        result.Result.As<ObjectResult>().StatusCode.Should().Be(StatusCodes.Status201Created);
    }
}