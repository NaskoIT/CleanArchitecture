using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManager.Application.Todos.Handlers;
using TaskManager.Web.Todos.Presenters;

namespace TaskManager.Web.Todos
{
    public class TodoController : ControllerBase
    {
        private readonly ITodoDetailsInputPort todoDetailsInputPort;
        private readonly TodoDetailsPresenter todoDetailsPresenter;

        public TodoController(ITodoDetailsInputPort todoDetailsInputPort, TodoDetailsPresenter todoDetailsPresenter)
        {
            this.todoDetailsInputPort = todoDetailsInputPort;
            this.todoDetailsPresenter = todoDetailsPresenter;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            await todoDetailsInputPort.Handle(id, todoDetailsPresenter);
            return todoDetailsPresenter.Result;
        }
    }
}
