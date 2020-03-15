using Blog.Domain.Entities;
using Blog.Domain.Exceptions;
using Xunit;

namespace Blog.Domain.UnitTests.Entities
{
    public class ArticleTests
    {
        [Fact]
        public void TitleShouldThrowExceptionWhenNull()
        {
            // Assert
            Assert.Throws<InvalidEntityException>(() => new Article(null, "Test Content", "Test Id"));
        }

        [Fact]
        public void UserIdShouldThrowExceptionWhenNull()
        {
            // Assert
            Assert.Throws<InvalidEntityException>(() => new Article("Test Title", "Test Content", null));
        }
    }
}
