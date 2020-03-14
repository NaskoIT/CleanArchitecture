using Blog.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Application.Articles.Queries.IsByUser
{
    public class ArticleIsByUserQuery : IRequest<bool>
    {
        public int Id { get; set; }

        public class ArticleIsByUserQueryHandler : IRequestHandler<ArticleIsByUserQuery, bool>
        {
            private readonly IBlogData data;
            private readonly ICurrentUser currentUser;

            public ArticleIsByUserQueryHandler(IBlogData data, ICurrentUser currentUser)
            {
                this.data = data;
                this.currentUser = currentUser;
            }

            public async Task<bool> Handle(ArticleIsByUserQuery request, CancellationToken cancellationToken) => 
                await this.data.Articles
                    .AnyAsync(a => a.Id == request.Id && a.CreatedBy == this.currentUser.UserId, cancellationToken);
        }
    }
}
