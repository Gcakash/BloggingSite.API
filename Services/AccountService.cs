using AutoMapper;
using BloggingSite.API.DTOs;
using BloggingSite.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BloggingSite.API.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUser(RegisterModel model);
        Task<string> LoginUser(LoginModel model);
        Task<List<UserModel>> GetAllUsers();
    }

    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IdentityResult> RegisterUser(RegisterModel model)
        {
            var user = _mapper.Map<ApplicationUser>(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            return result;
        }

        public async Task<string> LoginUser(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return GenerateJwtToken(user);
            }

            return null;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = _mapper.Map<List<UserModel>>(users);

            foreach (var userDto in userDtos)
            {
                var user = await _userManager.FindByIdAsync(userDto.Id);
                if(user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if(roles != null)
                    {
                        userDto.UserRole = roles.FirstOrDefault();
                    }
                }
            }
            return userDtos;
        }

        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = _userManager.GetRolesAsync(user).Result;
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
