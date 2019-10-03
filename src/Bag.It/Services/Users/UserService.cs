using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bag.It.Models;
using Bag.It.Interfaces.Services.Users;

namespace Bag.It.Services.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public Task<User> GetAsync(string username)
        {
            return _context.Users
                .FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}