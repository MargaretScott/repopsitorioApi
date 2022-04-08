using CursoDotNet.Application.BusinessModels.Requests;
using CursoDotNet.CrossCutting.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursoDotNet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateRequest request)
        {
            var user = _userService.Authenticate(request.Username, request.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}