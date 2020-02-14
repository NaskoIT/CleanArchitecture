using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Persistance.Models;

namespace TaskManager.Infrastructure.Persistance.Configuration
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder
               .HasKey(t => t.Id);

            builder
                .Property(t => t.Title)
                .IsRequired();

            builder
                .Property(t => t.Content)
                .IsRequired();

            builder
                .HasOne(typeof(ApplicationUser))
                .WithMany(nameof(ApplicationUser.Todos))
                .HasForeignKey(nameof(Todo.UserId))
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
