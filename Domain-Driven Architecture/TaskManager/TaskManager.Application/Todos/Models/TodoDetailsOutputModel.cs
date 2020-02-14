namespace TaskManager.Application.Todos.Models
{
    public class TodoDetailsOutputModel
    {
        public TodoDetailsOutputModel(string title, string content, string username)
        {
            Title = title;
            Content = content;
            Username = username;
        }

        public string Title { get; }

        public string Content { get; }

        public string Username { get; }
    }
}
