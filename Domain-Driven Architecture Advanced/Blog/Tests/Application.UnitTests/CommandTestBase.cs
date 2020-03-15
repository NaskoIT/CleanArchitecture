using System;
using Blog.Application.Common.Interfaces;
using Blog.Infrastructure.Persistence;
using Moq;

namespace Blog.Application.UnitTests
{
    public class CommandTestBase : IDisposable
    {
        protected const string TestUserId = "Test User Id";

        public CommandTestBase()
        {
            this.Context = ApplicationDbContextFactory.Create();

            var currentUserMock = new Mock<ICurrentUser>();

            currentUserMock
                .SetupGet(u => u.UserId)
                .Returns(TestUserId);

            this.CurrentUser = currentUserMock.Object;
        }

        public BlogDbContext Context { get; }

        public ICurrentUser CurrentUser { get; }

        public void Dispose() => ApplicationDbContextFactory.Destroy(this.Context);
    }
}