using Microsoft.AspNetCore.Mvc;
using Todo.Api.Models;

namespace Todo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> logger;
    private readonly ApplicationDbContext context;

    public TodoController(ILogger<TodoController> logger, ApplicationDbContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Models.Todo> Create(CreateTodoContract request)
    {
        try
        {
            var todo = new Models.Todo()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description
            };

            context.Todos.Add(todo);
            context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, todo);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, "It was not possible to create the task");
        }
    }
}