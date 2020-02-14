using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Todos
{
    public interface ITodoGateway
    {
        Task<Todo> Details(int id);
    }
}
