using Blog.Application.Common.Models;
using Blog.Application.Common.Services;
using System.Threading.Tasks;

namespace Blog.Application.Common.Interfaces
{
    public interface IIdentity : ITransientService
    {
        Task<string> GetUserName(string userId);

        Task<(Result Result, string UserId)> CreateUser(string userName, string password);

        Task<Result> DeleteUser(string userId);
    }
}
