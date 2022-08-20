namespace Todo.Api.Contracts 
{
    public class CreateTodoContract
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
