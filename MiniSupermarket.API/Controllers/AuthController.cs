using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Endpoint Đăng nhập: POST /api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            // 1. Kiểm tra tài khoản Quản trị viên (Admin)
            if ((request.Username == "admin" || request.Username == "admin01") && request.Password == "123456")
            {
                var token = GenerateJwtToken(request.Username, "Admin");
                return Ok(new { success = true, token = token, role = "Admin" });
            }
            // 2. Kiểm tra tài khoản Thu ngân (Cashier)
            else if ((request.Username == "cashier" || request.Username == "cashier01") && request.Password == "123456")
            {
                var token = GenerateJwtToken(request.Username, "Cashier");
                return Ok(new { success = true, token = token, role = "Cashier" });
            }
            // 3. Kiểm tra tài khoản Thủ kho (Warehouse) - BỔ SUNG THÊM
            else if ((request.Username == "warehouse" || request.Username == "ware01") && request.Password == "123456")
            {
                var token = GenerateJwtToken(request.Username, "Warehouse");
                return Ok(new { success = true, token = token, role = "Warehouse" });
            }

            return Unauthorized(new { success = false, message = "Sai tài khoản hoặc mật khẩu!" });
        }

        private string GenerateJwtToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Lấy khóa bí mật từ appsettings.json
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"] ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(2), // Thời hạn token là 2 tiếng
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginRequestDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}