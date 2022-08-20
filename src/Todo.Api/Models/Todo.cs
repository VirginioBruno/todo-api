namespace Todo.Api.Models;

public class Todo 
{
    public Guid Id { get; set; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public bool Done { get; set; }
}