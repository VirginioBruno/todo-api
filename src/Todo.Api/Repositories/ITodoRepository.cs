namespace Todo.Api.Repositories;

public interface ITodoRepository
{
    void Store(Models.Todo todo);
}