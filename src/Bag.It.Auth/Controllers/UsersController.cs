using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bag.It.Auth.Models;
using Bag.It.Models;
using Bag.It.Interfaces.Services.Auth;
using Bag.It.Interfaces.Services.Users;

namespace Bag.It.Auth.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : Controller
    {
        private readonly IAuthenticationSevice _authService;
        private readonly IUserService _userService;

        public UsersController(
            IAuthenticationSevice authService,
            IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] RegisterUserRequest request)
        {
            if (await _userService.GetAsync(request.Username) != null)
            {
                return Conflict("Username is already registered!");
            }

            return Ok(_authService.GenerateTokenForUser(new User { Username = request.Username, Password = request.Password }));
        }
    }
}