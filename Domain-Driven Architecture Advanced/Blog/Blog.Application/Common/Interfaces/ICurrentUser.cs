using Blog.Application.Common.Services;

namespace Blog.Application.Common.Interfaces
{
    public interface ICurrentUser : IScopedService
    {
        string UserId { get; }
    }
}
