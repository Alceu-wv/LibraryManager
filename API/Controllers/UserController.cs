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

        public UserController(IUserService userService)
        {
            _userService = userService;
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
            var user = _userService.Login(request.Email, request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            // TODO: Gerar token de autenticação e retornar para o cliente
            return Ok();
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