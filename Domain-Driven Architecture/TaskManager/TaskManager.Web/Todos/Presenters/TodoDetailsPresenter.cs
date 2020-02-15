using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Ports;
using TaskManager.Application.Todos.Models;

namespace TaskManager.Web.Todos.Presenters
{
    public class TodoDetailsPresenter : IOutputPort<TodoDetailsOutputModel>
    {
        public IActionResult Result { get; private set; }

        public void Error(string message = null) => Result = new NotFoundObjectResult(message);

        public void Success(TodoDetailsOutputModel output) => Result = new OkObjectResult(output);
    }
}
