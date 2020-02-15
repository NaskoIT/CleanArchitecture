using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Persistance.Models;

namespace TaskManager.Infrastructure.Persistance
{
    public class TaskManagerDbContext : IdentityDbContext<ApplicationUser>
    {
        public TaskManagerDbContext()
        {
        }

        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            //Seed ApplicationUser
            string userId = "user_id";
            modelBuilder
                .Entity<ApplicationUser>()
                .HasData(new ApplicationUser
                {
                    Id = userId,
                    UserName = "Test user",
                });

            //Seed Todo
            var todo = new Todo(1,
                "Domain-Driven architecture advanced",
                "Now use third-party libraries to improve the architecture and development experience",
                userId);
            modelBuilder
                .Entity<Todo>()
                .HasData(todo);

            base.OnModelCreating(modelBuilder);
        }
    }
}
