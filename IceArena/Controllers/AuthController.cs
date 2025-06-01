using Microsoft.AspNetCore.Authorization;
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
using IceArena.Data.Models;
using IceArena.Data.Repositories.Interfaces;
using IceArena.Data.Requests;

namespace IceArena.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserRepository userRepository, IConfiguration configuration, ILogger<AuthController> logger)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (await _userRepository.GetUserByEmailAsync(request.Email) != null)
            {
                return BadRequest("Email уже используется");
            }

            if (await _userRepository.GetUserByPhoneAsync(request.PhoneNumber) != null) 
            {
                return BadRequest("Телефон уже используется");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            _logger.LogInformation("Хеш пароля при регистрации: {PasswordHash}", passwordHash);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = passwordHash,
                Role = "user",
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var savedUser = await _userRepository.GetUserByEmailAsync(request.Email);
            _logger.LogInformation("Хеш пароля после сохранения в базу данных: {PasswordHash}", savedUser.PasswordHash);

            var token = GenerateJwtToken(user);

            return Ok(new AuthResponse
            {
                Token = token,
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                PhoneNumber = user.PhoneNumber,
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation("Попытка входа: Email = {Email}", request.Email);

            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                _logger.LogWarning("Не найден пользователь с Email: {Email}", request.Email);
                return Unauthorized("Пользователь не найден");
            }

            _logger.LogInformation("Найден пользователь: {Username}", user.Username);
            _logger.LogInformation("Хеш пароля из базы данных: {PasswordHash}", user.PasswordHash);

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            _logger.LogInformation("Результат проверки пароля: {IsPasswordValid}", isPasswordValid);

            if (!isPasswordValid)
            {
                _logger.LogWarning("Неверный пароль для пользователя: {Email}", request.Email);
                return Unauthorized("Неверный пароль");
            }

            _logger.LogInformation("Пароль верный, генерируем токен...");

            var token = GenerateJwtToken(user);

            var response = new LoginResponse
            {
                Token = token,
                UserId = user.Id,
                Username = user.Username,
                Role = user.Role ?? "user",
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            _logger.LogInformation("Успешный вход: {Username}, Token = {Token}", user.Username, token);
            return Ok(response);
        }

        //[Authorize(Roles = "admin")] 
        [HttpPost("register-admin")] 
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterRequest request) 
        {
            if (await _userRepository.GetUserByEmailAsync(request.Email) != null)
            {
                return BadRequest("Email уже используется");
            }

            if (await _userRepository.GetUserByPhoneAsync(request.PhoneNumber) != null)
            {
                return BadRequest("Телефон уже используется");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            _logger.LogInformation("Хеш пароля при регистрации админа: {PasswordHash}", passwordHash);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash,
                PhoneNumber = request.PhoneNumber,
                Role = "admin", 
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var token = GenerateJwtToken(user);

            return Ok(new AuthResponse
            {
                Token = token,
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role
            });
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role ?? "user"),
                new Claim("Phone", user.PhoneNumber)
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
    }
}