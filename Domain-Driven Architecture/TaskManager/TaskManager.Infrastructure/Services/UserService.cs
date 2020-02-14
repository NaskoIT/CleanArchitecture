using TaskManager.Application.Infrastructure;
using TaskManager.Infrastructure.Persistance;

namespace TaskManager.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly TaskManagerDbContext context;

        public UserService(TaskManagerDbContext context)
        {
            this.context = context;
        }

        public string GetUserName(string userId) => context.Users.Find(userId)?.UserName;
    }
}
