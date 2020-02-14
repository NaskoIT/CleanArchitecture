using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistance.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Todos = new List<Todo>();
        }

        public ICollection<Todo> Todos { get; set; }
    }
}
