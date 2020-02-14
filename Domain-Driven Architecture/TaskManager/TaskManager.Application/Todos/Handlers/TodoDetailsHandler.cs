using System.Threading.Tasks;
using TaskManager.Application.Infrastructure;
using TaskManager.Application.Ports;
using TaskManager.Application.Todos.Models;

namespace TaskManager.Application.Todos.Handlers
{
    public class TodoDetailsHandler : ITodoDetailsInputPort
    {
        private readonly ITodoGateway todoGateway;
        private readonly IUserService userService;

        public TodoDetailsHandler(ITodoGateway todoGateway, IUserService userService)
        {
            this.todoGateway = todoGateway;
            this.userService = userService;
        }

        public async Task Handle(int input, IOutputPort<TodoDetailsOutputModel> output)
        {
            var todo = await todoGateway.Details(input);
            if (todo == null)
            {
                output.Error($"Todo with id: {input} does not exist in our database!");
            }
            else
            {
                var username = userService.GetUserName(todo.UserId);
                var outputModel = new TodoDetailsOutputModel(todo.Title, todo.Content, username);
                output.Success(outputModel);
            }
        }
    }
}
