using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Todos.Handlers;

namespace TaskManager.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddTransient<ITodoDetailsInputPort, TodoDetailsHandler>();

            return services;
        }
    }
}
