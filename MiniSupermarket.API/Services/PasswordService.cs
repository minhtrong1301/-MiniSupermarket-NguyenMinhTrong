
using Microsoft.AspNetCore.Identity;

namespace MiniSupermarket.API.Services
{
    // Dịch vụ băm và kiểm tra mật khẩu, không lưu mật khẩu gốc vào database.
    public class PasswordService
    {
        // Sử dụng bộ băm mật khẩu có sẵn trong ASP.NET Core.
        private readonly PasswordHasher<string> _hasher = new();

        // Băm mật khẩu trước khi lưu vào cột PasswordHash.
        public string HashPassword(string username, string password)
        {
            return _hasher.HashPassword(username, password);
        }

        // Kiểm tra mật khẩu người dùng nhập có khớp với mật khẩu đã băm không.
        public bool VerifyPassword(
            string username,
            string passwordHash,
            string password)
        {
            var result = _hasher.VerifyHashedPassword(
                username,
                passwordHash,
                password);

            return result != PasswordVerificationResult.Failed;
        }
    }
}
