using Todo.Api.Models;

namespace Todo.Api.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _context;
    
    public TodoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Store(Models.Todo todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }
}