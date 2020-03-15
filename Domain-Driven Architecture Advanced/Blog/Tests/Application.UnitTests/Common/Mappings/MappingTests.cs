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

        [Theory]
        [InlineData(typeof(Article), typeof(ArticleDetailsViewModel))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = Activator.CreateInstance(source);

            this.mapper.Map(instance, source, destination);
        }
    }
}
