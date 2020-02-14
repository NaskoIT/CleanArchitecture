using System.Threading.Tasks;
using TaskManager.Application.Todos;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Persistance;

namespace TaskManager.Infrastructure.Gateways
{
    public class TodoGateway : ITodoGateway
    {
        private readonly TaskManagerDbContext context;

        public TodoGateway(TaskManagerDbContext context)
        {
            this.context = context;
        }

        public Task<Todo> Details(int id) => context.Todos.FindAsync(id);
    }
}
