using Bag.It.Models;

namespace Bag.It.Interfaces.Services.Users
{
    public interface IUserService
    {
        User GetAsync(string username);
    }
}