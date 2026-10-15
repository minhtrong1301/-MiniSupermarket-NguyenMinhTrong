using System.ComponentModel.DataAnnotations;

namespace MiniSupermarket.API.Models
{
    // Đại diện cho một tài khoản người dùng trong hệ thống siêu thị.
    public class User
    {
        // Mã định danh của người dùng, thường được SQL Server tự tăng.
        public int Id { get; set; }

        // Tên đăng nhập của người dùng, tối đa 50 ký tự.
        [Required] // Bắt buộc phải có tên đăng nhập.
        [MaxLength(50)] // Giới hạn độ dài tối đa 50 ký tự.
        public string Username { get; set; } = string.Empty;

        // Lưu mật khẩu đã được băm (hash), không lưu mật khẩu gốc.
        [Required] // Bắt buộc phải có mật khẩu đã băm.
        public string PasswordHash { get; set; } = string.Empty;

        // Họ và tên đầy đủ của nhân viên.
        [Required] // Bắt buộc phải có họ tên.
        [MaxLength(100)] // Giới hạn độ dài tối đa 100 ký tự.
        public string FullName { get; set; } = string.Empty;

        // Vai trò của tài khoản, dùng để phân quyền chức năng.
        // Ví dụ: Admin (quản trị), Cashier (thu ngân), Warehouse (quản lý kho).
        [Required] // Bắt buộc phải có vai trò.
        [MaxLength(20)] // Giới hạn độ dài tối đa 20 ký tự.
        public string Role { get; set; } = string.Empty;

        // Trạng thái hoạt động của tài khoản.
        // true: được phép hoạt động; false: tài khoản bị khóa hoặc vô hiệu hóa.
        public bool IsActive { get; set; } = true;
    }
}