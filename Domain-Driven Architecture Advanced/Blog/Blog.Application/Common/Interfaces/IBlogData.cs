using System.Threading;
using System.Threading.Tasks;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Common.Interfaces
{
    public interface IBlogData
    {
        DbSet<Article> Articles { get; set; }

        DbSet<Comment> Comments { get; set; }

        Task<int> SaveChanges(CancellationToken cancellationToken);
    }
}
