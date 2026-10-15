using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;
using MiniSupermarket.API.Services;

namespace MiniSupermarket.API.Controllers
{
    // Chỉ tài khoản Admin mới được quản lý tài khoản nhân viên.
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;
        private readonly PasswordService _passwordService;

        // Nhận database và dịch vụ mật khẩu từ hệ thống.
        public UsersController(
            SupermarketDbContext context,
            PasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        // 1. Lấy danh sách tài khoản, không trả PasswordHash về client.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.Id,
                    u.Username,
                    u.FullName,
                    u.Role,
                    u.IsActive
                })
                .ToListAsync();

            return Ok(users);
        }

        // 2. Tạo tài khoản mới.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            // Kiểm tra dữ liệu bắt buộc.
            if (string.IsNullOrWhiteSpace(dto.Username) ||
                string.IsNullOrWhiteSpace(dto.Password) ||
                string.IsNullOrWhiteSpace(dto.FullName) ||
                string.IsNullOrWhiteSpace(dto.Role))
            {
                return BadRequest(new
                {
                    message = "Vui lòng nhập đầy đủ thông tin tài khoản!"
                });
            }

            // Chỉ chấp nhận ba vai trò đã quy định trong hệ thống.
            if (dto.Role != "Admin" &&
                dto.Role != "Cashier" &&
                dto.Role != "Warehouse")
            {
                return BadRequest(new
                {
                    message = "Vai trò không hợp lệ!"
                });
            }

            // Không cho tạo hai tài khoản trùng tên đăng nhập.
            if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
            {
                return BadRequest(new
                {
                    message = "Tên đăng nhập đã tồn tại!"
                });
            }

            var user = new User
            {
                Username = dto.Username.Trim(),
                // Băm mật khẩu trước khi lưu vào database.
                PasswordHash = _passwordService.HashPassword(
                    dto.Username.Trim(), dto.Password),
                FullName = dto.FullName.Trim(),
                Role = dto.Role,
                IsActive = true
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Tạo tài khoản thành công!" });
        }

        // 3. Đặt lại mật khẩu tài khoản theo ID.
        [HttpPut("{id}/reset-password")]
        public async Task<IActionResult> ResetPassword(
            int id,
            [FromBody] ResetPasswordDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NewPassword))
            {
                return BadRequest(new
                {
                    message = "Mật khẩu mới không được để trống!"
                });
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy người dùng!"
                });
            }

            // Băm mật khẩu mới trước khi cập nhật.
            user.PasswordHash = _passwordService.HashPassword(
                user.Username, dto.NewPassword);

            await _context.SaveChangesAsync();

            return Ok(new { message = "Đặt lại mật khẩu thành công!" });
        }

        // 4. Khóa hoặc mở khóa tài khoản.
        [HttpPut("{id}/toggle-lock")]
        public async Task<IActionResult> ToggleLock(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy người dùng!"
                });
            }

            // Đảo trạng thái hoạt động của tài khoản.
            user.IsActive = !user.IsActive;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Đã cập nhật trạng thái tài khoản!",
                isActive = user.IsActive
            });
        }

        // 6. Cập nhật họ tên và vai trò của tài khoản.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
        {
            // Kiểm tra dữ liệu đầu vào.
            if (string.IsNullOrWhiteSpace(dto.FullName) ||
                string.IsNullOrWhiteSpace(dto.Role))
            {
                return BadRequest(new
                {
                    message = "Vui lòng nhập đầy đủ họ tên và vai trò!"
                });
            }

            // Chỉ chấp nhận các vai trò đã quy định.
            if (dto.Role != "Admin" &&
                dto.Role != "Cashier" &&
                dto.Role != "Warehouse")
            {
                return BadRequest(new
                {
                    message = "Vai trò không hợp lệ!"
                });
            }

            // Tìm tài khoản cần cập nhật.
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy tài khoản!"
                });
            }

            // Chỉ cập nhật hai trường được phép chỉnh sửa.
            user.FullName = dto.FullName.Trim();
            user.Role = dto.Role;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Cập nhật tài khoản thành công!"
            });
        }

    }

    // Dữ liệu nhận khi tạo tài khoản.
    public class CreateUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }

    // Dữ liệu nhận khi đặt lại mật khẩu.
    public class ResetPasswordDto
    {
        public string NewPassword { get; set; } = string.Empty;
    }

    // Dữ liệu nhận khi cập nhật tài khoản.
    public class UpdateUserDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
