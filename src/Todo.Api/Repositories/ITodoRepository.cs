namespace Todo.Api.Repositories;

public interface ITodoRepository
{
    void Store(Models.Todo todo);
    Models.Todo? GetById(Guid id);
    IEnumerable<Models.Todo> GetAll();
    void Remove(Models.Todo todo);
}