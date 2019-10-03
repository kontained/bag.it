using System.Threading.Tasks;
using Bag.It.Models;

namespace Bag.It.Interfaces.Services.Users
{
    public interface IUserService
    {
        Task<User> GetAsync(string username);
    }
}