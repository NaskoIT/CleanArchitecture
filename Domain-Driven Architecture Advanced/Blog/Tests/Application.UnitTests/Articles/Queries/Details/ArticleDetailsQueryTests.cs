using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Articles.Queries.Details;
using Blog.Application.Common.Interfaces;
using AutoMapper;
using Blog.Infrastructure.Persistence;
using Shouldly;
using Xunit;

namespace Blog.Application.UnitTests.Articles.Queries.Details
{
    [Collection("QueryTests")]
    public class ArticleDetailsQueryTests
    {
        private readonly BlogDbContext context;
        private readonly IMapper mapper;
        private readonly IIdentity identity;

        public ArticleDetailsQueryTests(QueryTestFixture fixture)
        {
            this.context = fixture.Context;
            this.mapper = fixture.Mapper;
            this.identity = fixture.Identity;
        }

        [Fact]
        public async Task HandleReturnsCorrectArticleDetails()
        {
            // Assert
            var query = new ArticleDetailsQuery { Id = 1 };

            var handler = new ArticleDetailsQuery.ArticleDetailsQueryHandler(this.context, this.mapper, this.identity);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Id.ShouldBe(1);
            result.Title.ShouldBe("Test Title 1");
            result.Author.ShouldBe("Test User");
        }
    }
}
