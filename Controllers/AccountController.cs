using BloggingSite.API.DTOs;
using BloggingSite.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloggingSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _accountService.RegisterUser(model);
            if (result.Succeeded)
            {
                return Ok("User registered successfully");
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var token = await _accountService.LoginUser(model);
            if (token != null)
            {
                return Ok(new { Token = token });
            }
            return Unauthorized("Invalid username or password");
        }

       // [Authorize(Roles = "Admin")]
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _accountService.GetAllUsers();
            return Ok(users);
        }
    }
}
