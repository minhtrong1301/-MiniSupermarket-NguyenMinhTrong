using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SupermarketDbContext _context;
        private readonly PasswordService _passwordService;

        // Nhận các dịch vụ cần thiết thông qua Dependency Injection.
        public AuthController(
            IConfiguration configuration,
            SupermarketDbContext context,
            PasswordService passwordService)
        {
            _configuration = configuration;
            _context = context;
            _passwordService = passwordService;
        }

        // POST: /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            // Kiểm tra dữ liệu đăng nhập đầu vào.
            if (string.IsNullOrWhiteSpace(request.Username) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Vui lòng nhập tên đăng nhập và mật khẩu!"
                });
            }

            // Tìm tài khoản trong database, không dùng tài khoản viết cứng.
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username);

            // Từ chối nếu tài khoản không tồn tại hoặc đã bị khóa.
            if (user == null || !user.IsActive)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Tài khoản không tồn tại hoặc đã bị khóa!"
                });
            }

            // Xác minh mật khẩu nhập vào với mật khẩu đã băm trong database.
            bool passwordCorrect = _passwordService.VerifyPassword(
                user.Username,
                user.PasswordHash,
                request.Password);

            if (!passwordCorrect)
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Sai tài khoản hoặc mật khẩu!"
                });
            }

            // Tạo JWT dựa trên tài khoản và vai trò thực tế trong database.
            var token = GenerateJwtToken(user.Username, user.Role);

            return Ok(new
            {
                success = true,
                token,
                username = user.Username,
                fullName = user.FullName,
                role = user.Role
            });
        }

        // Tạo JWT có thời hạn 2 tiếng.
        private string GenerateJwtToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var secret = _configuration["JwtSettings:Secret"]
                ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!";

            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }

    // Dữ liệu WinForms gửi lên khi đăng nhập.
    public class LoginRequestDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
