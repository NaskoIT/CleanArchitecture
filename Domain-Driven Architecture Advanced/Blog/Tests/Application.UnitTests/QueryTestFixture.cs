using System;
using System.Threading.Tasks;
using Blog.Application.Common.Interfaces;
using Blog.Application.Common.Mappings;
using AutoMapper;
using Blog.Infrastructure.Persistence;
using Moq;
using Xunit;

namespace Blog.Application.UnitTests
{
    public sealed class QueryTestFixture : IDisposable
    {
        public QueryTestFixture()
        {
            this.Context = ApplicationDbContextFactory.Create();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            this.Mapper = configurationProvider.CreateMapper();

            var identityMock = new Mock<IIdentity>();

            identityMock
                .Setup(i => i.GetUserName(It.IsAny<string>()))
                .Returns(Task.FromResult("Test User"));

            this.Identity = identityMock.Object;
        }

        public BlogDbContext Context { get; }

        public IMapper Mapper { get; }

        public IIdentity Identity { get; }

        public void Dispose() => ApplicationDbContextFactory.Destroy(this.Context);
    }

    [CollectionDefinition("QueryTests")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}