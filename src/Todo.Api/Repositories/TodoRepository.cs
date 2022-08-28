using Microsoft.EntityFrameworkCore;
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
    
    public Models.Todo? GetById(Guid id) =>
        _context.Todos.FirstOrDefault(x => x.Id.Equals(id));
    
    public IEnumerable<Models.Todo> GetAll() =>
        _context.Todos.ToList();

    public void Remove(Models.Todo todo)
    {
        _context.Todos.Remove(todo);
        _context.SaveChanges();
    }
}