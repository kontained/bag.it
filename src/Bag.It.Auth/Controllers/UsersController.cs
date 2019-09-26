using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bag.It.Auth.Models;
using Bag.It.Interfaces.Services.Auth;

namespace Bag.It.Auth.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : Controller
    {
        private readonly IAuthenticationSevice _authService;

        public UsersController(IAuthenticationSevice authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public ActionResult Register([FromBody] RegisterUserRequest request)
        {
            return Ok();
        }
    }
}