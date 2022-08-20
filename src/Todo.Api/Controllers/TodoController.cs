using Microsoft.AspNetCore.Mvc;
using Todo.Api.Contracts;
using Todo.Api.Models;
using Todo.Api.Repositories;

namespace Todo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> _logger;
    private readonly ITodoRepository _repository;

    public TodoController(ILogger<TodoController> logger, ITodoRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Models.Todo> Create(CreateTodoContract request)
    {
        try
        {
            var todo = new Models.Todo
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description
            };
            
            _repository.Store(todo);
            return StatusCode(StatusCodes.Status201Created, todo);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "It was not possible to create the task");
            return StatusCode(StatusCodes.Status500InternalServerError, "It was not possible to create the task");
        }
    }
}