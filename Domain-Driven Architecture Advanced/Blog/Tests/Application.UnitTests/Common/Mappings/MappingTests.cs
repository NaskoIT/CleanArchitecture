using AutoMapper;
using System;
using Blog.Application.Articles.Queries.Details;
using Blog.Domain.Entities;
using Xunit;

namespace Blog.Application.UnitTests.Common.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider configuration;
        private readonly IMapper mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            this.configuration = fixture.ConfigurationProvider;
            this.mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldSupportMappingFromSourceToDestination()
        {
            //Arrange
            Article article = new Article("title", "content", "user_id");
            
            //Act
            ArticleDetailsViewModel model = this.mapper.Map<Article, ArticleDetailsViewModel>(article);

            //Assert
            Assert.Equal(article.Content, model.Content);
            Assert.Equal(article.Title, model.Title);
            Assert.Equal(article.CreatedBy, model.CreatedBy);
        }
    }
}
