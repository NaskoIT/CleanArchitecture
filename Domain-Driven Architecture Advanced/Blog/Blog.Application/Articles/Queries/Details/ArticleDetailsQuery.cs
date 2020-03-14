using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blog.Application.Articles.Queries.Details
{
    public class ArticleDetailsQuery : IRequest<ArticleDetailsViewModel>
    {
        public int Id { get; set; }

        public class ArticleDetailsQueryHandler : IRequestHandler<ArticleDetailsQuery, ArticleDetailsViewModel>
        {
            private readonly IBlogData data;
            private readonly IMapper mapper;
            private readonly IIdentity identity;

            public ArticleDetailsQueryHandler(
                IBlogData data,
                IMapper mapper,
                IIdentity identity)
            {
                this.data = data;
                this.mapper = mapper;
                this.identity = identity;
            }

            public async Task<ArticleDetailsViewModel> Handle(ArticleDetailsQuery request, CancellationToken cancellationToken)
            {
                var articleDetails = await this.data.Articles
                    .Where(a => a.Id == request.Id)
                    .ProjectTo<ArticleDetailsViewModel>(this.mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(cancellationToken);

                if (articleDetails == null)
                {
                    return null;
                }

                articleDetails.Author = await this.identity.GetUserName(articleDetails.CreatedBy);
                return articleDetails;
            }
        }
    }
}
