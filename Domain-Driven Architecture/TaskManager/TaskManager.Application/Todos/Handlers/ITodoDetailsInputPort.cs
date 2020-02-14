using TaskManager.Application.Ports;
using TaskManager.Application.Todos.Models;

namespace TaskManager.Application.Todos.Handlers
{
    public interface ITodoDetailsInputPort : IInputPort<int, TodoDetailsOutputModel>
    {
    }
}
