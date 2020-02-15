using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Infrastructure;
using TaskManager.Application.Todos;
using TaskManager.Infrastructure.Gateways;
using TaskManager.Infrastructure.Persistance;
using TaskManager.Infrastructure.Services;

namespace TaskManager.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<TaskManagerDbContext>(options => options.UseInMemoryDatabase("TaskManagerDatabase"));

            services.AddTransient<IUserService, UserService>();

            services.AddTransient<ITodoGateway, TodoGateway>();

            return services;
        }
    }
}
