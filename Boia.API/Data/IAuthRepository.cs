using Boia.API.Models;
using System.Threading.Tasks;

namespace Boia.API.Data
{
    interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}
