using System;
using Bag.It.Models;

namespace Bag.It.Interfaces.Services.Auth
{
    public interface IAuthenticationSevice
    {
        string GenerateTokenForUser(User user);
        bool IsUserAuthenticated(User user);
    }
}