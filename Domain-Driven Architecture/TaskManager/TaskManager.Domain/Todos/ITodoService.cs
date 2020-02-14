using System.Threading.Tasks;
using TaskManager.Domain.Todos.Models;

namespace TaskManager.Domain.Infrastructure
{
    public interface ITodoService
    {
        Task Create(TodoInputModel todo);
    }
}
