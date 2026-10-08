//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MiniSupermarket.API.Data;
//using MiniSupermarket.API.Models;

//namespace MiniSupermarket.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [Authorize(Roles = "Admin")] // Chỉ Admin mới có quyền quản lý tài khoản
//    public class UsersController : ControllerBase
//    {
//        private readonly SupermarketDbContext _context;

//        public UsersController(SupermarketDbContext context)
//        {
//            _context = context;
//        }

//        // 1. Lấy danh sách tất cả người dùng
//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var users = await _context.Users
//                .Select(u => new
//                {
//                    u.Id,
//                    u.Username,
//                    u.FullName,
//                    u.Role,
//                    u.IsActive
//                })
//                .ToListAsync();

//            return Ok(users);
//        }

//        // 2. Thêm mới tài khoản
//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
//        {
//            if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
//            {
//                return BadRequest(new { message = "Tên đăng nhập đã tồn tại!" });
//            }

//            var user = new User
//            {
//                Username = dto.Username,
//                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password), // Băm mật khẩu
//                FullName = dto.FullName,
//                Role = dto.Role,
//                IsActive = true
//            };

//            _context.Users.Add(user);
//            await _context.SaveChangesAsync();

//            return Ok(new { message = "Tạo tài khoản thành công!" });
//        }

//        // 3. Reset mật khẩu tài khoản
//        [HttpPut("{id}/reset-password")]
//        public async Task<IActionResult> ResetPassword(int id, [FromBody] ResetPasswordDto dto)
//        {
//            var user = await _context.Users.FindAsync(id);
//            if (user == null) return NotFound(new { message = "Không tìm thấy người dùng!" });

//            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
//            await _context.SaveChangesAsync();

//            return Ok(new { message = "Reset mật khẩu thành công!" });
//        }

//        // 4. Khóa / Mở khóa tài khoản
//        [HttpPut("{id}/toggle-lock")]
//        public async Task<IActionResult> ToggleLock(int id)
//        {
//            var user = await _context.Users.FindAsync(id);
//            if (user == null) return NotFound(new { message = "Không tìm thấy người dùng!" });

//            user.IsActive = !user.IsActive; // Đảo ngược trạng thái Active
//            await _context.SaveChangesAsync();

//            return Ok(new { message = "Đã cập nhật trạng thái tài khoản!", isActive = user.IsActive });
//        }
//    }

//    public class CreateUserDto
//    {
//        public string Username { get; set; } = string.Empty;
//        public string Password { get; set; } = string.Empty;
//        public string FullName { get; set; } = string.Empty;
//        public string Role { get; set; } = string.Empty;
//    }

//    public class ResetPasswordDto
//    {
//        public string NewPassword { get; set; } = string.Empty;
//    }
//}