namespace TaskManager.Domain.Todos.Models
{
    public class TodoInputModel
    {
        public TodoInputModel(string content)
        {
            Content = content;
        }

        public string Content { get; }
    }
}
