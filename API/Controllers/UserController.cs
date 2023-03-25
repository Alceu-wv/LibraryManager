using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.Services;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Token _token;

        public UserController(IUserService userService, Token token)
        {
            _userService = userService;
            _token = token;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            User user = _userService.Login(request.Email, request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(_token.GenerateToken(user));
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            _userService.Create(user);

            return Ok();
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}