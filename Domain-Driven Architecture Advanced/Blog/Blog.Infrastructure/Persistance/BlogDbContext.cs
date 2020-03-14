using Blog.Application.Common.Interfaces;
using Blog.Domain.Common;
using Blog.Domain.Entities;
using Blog.Infrastructure.Identity;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Persistance
{
    public class BlogDbContext : ApiAuthorizationDbContext<User>, IBlogData
    {
        private readonly ICurrentUser currentUserService;
        private readonly IDateTime dateTime;

        public BlogDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUser currentUserService,
            IDateTime dateTime)
            : base(options, operationalStoreOptions)
        {
            this.currentUserService = currentUserService;
            this.dateTime = dateTime;
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public Task<int> SaveChanges(CancellationToken cancellationToken = new CancellationToken())
            => this.SaveChangesAsync(cancellationToken);

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in this.ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy ??= this.currentUserService.UserId;
                        entry.Entity.CreatedOn = this.dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = this.currentUserService.UserId;
                        entry.Entity.ModifiedOn = this.dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
