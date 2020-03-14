using System.Collections.Generic;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Blog.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        public ICollection<Article> Articles { get; private set; } = new List<Article>();

        public ICollection<Comment> Comments { get; private set; } = new List<Comment>();
    }
}
