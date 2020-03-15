using Blog.Application.Common.Interfaces;
using Moq;
using MyTested.AspNetCore.Mvc;

namespace Blog.Web.IntegrationTests
{
    public class Mocks
    {
        public static ICurrentUser CurrentUser
        {
            get
            {
                var currentUserMock = new Mock<ICurrentUser>();

                currentUserMock
                    .SetupGet(u => u.UserId)
                    .Returns(TestUser.Identifier);

                return currentUserMock.Object;
            }
        }

        public static IDateTime DateTime
        {
            get
            {
                var currentUserMock = new Mock<IDateTime>();

                currentUserMock
                    .SetupGet(u => u.Now)
                    .Returns(TestData.TestNow);

                return currentUserMock.Object;
            }
        }
    }
}
