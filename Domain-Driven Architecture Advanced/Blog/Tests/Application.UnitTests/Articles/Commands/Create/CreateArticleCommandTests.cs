using System.Threading;
using System.Threading.Tasks;
using Blog.Application.Articles.Commands.Create;
using Shouldly;
using Xunit;

namespace Blog.Application.UnitTests.Articles.Commands.Create
{
    public class CreateArticleCommandTests : CommandTestBase
    {
        [Fact]
        public async Task HandleShouldPersistArticle()
        {
            var command = new CreateArticleCommand
            {
                Title = "Test Title Command",
                Content = "Test Content Command"
            };

            var handler = new CreateArticleCommand.CreateArticleCommandHandler(this.Context, this.CurrentUser);

            var result = await handler.Handle(command, CancellationToken.None);

            var article = this.Context.Articles.Find(result);

            article.ShouldNotBeNull();
            article.Title.ShouldBe(command.Title);
            article.CreatedBy.ShouldBe(TestUserId);
        }
    }
}
