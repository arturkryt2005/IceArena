using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using IceArena.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using IceArena.Data.Requests;

namespace IceArena.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger; // Добавили логгер

        public AuthController(IUserRepository userRepository, IConfiguration configuration, ILogger<AuthController> logger)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _logger = logger; // Инициализируем логгер
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation("Попытка входа: Email = {Email}", request.Email);

            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                _logger.LogWarning("Не найден пользователь с Email: {Email}", request.Email);
                return Unauthorized();
            }

            _logger.LogInformation("Найден пользователь: {Username}", user.Username);

            if (!VerifyPasswordHash(request.Password, user.PasswordHash))
            {
                _logger.LogWarning("Неверный пароль для пользователя: {Email}", request.Email);
                return Unauthorized();
            }

            _logger.LogInformation("Пароль верный, генерируем токен...");

            var token = GenerateJwtToken(user);

            var response = new LoginResponse
            {
                Token = token,
                UserId = user.Id,
                Username = user.Username,
                Role = user.Role ?? "user",
                Email = user.Email
            };

            _logger.LogInformation("Успешный вход: {Username}, Token = {Token}", user.Username, token);
            return Ok(response);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role ?? "user")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerifyPasswordHash(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
