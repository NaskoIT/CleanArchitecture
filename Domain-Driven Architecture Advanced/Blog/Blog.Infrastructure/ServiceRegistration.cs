using Blog.Application.Common.Interfaces;
using Blog.Infrastructure.Identity;
using Blog.Infrastructure.Persistance;
using Blog.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;

namespace Blog.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                 .AddDbContext<BlogDbContext>(options => options
                     .UseSqlServer(
                         configuration.GetConnectionString("DefaultConnection"),
                         sqlServerOptions => sqlServerOptions.MigrationsAssembly(typeof(BlogDbContext).Assembly.FullName)))
                 .AddScoped<IBlogData>(provider => provider.GetService<BlogDbContext>());

            services
                .AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<BlogDbContext>();

            services
                .AddIdentityServer()
                .AddApiAuthorization<User, BlogDbContext>();

            services
                .AddConventionalServices(typeof(ServiceRegistration).Assembly);

            services
                .AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
