using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace MiniSupermarket.WinForms
{
    public static class SessionManager
    {
        public static string JwtToken { get; set; } = string.Empty;
        public static string CurrentRole { get; set; } = string.Empty;
    }

    public static class ApiClientService
    {
        // ⚠️ Đảm bảo port khớp với cổng Web API của bạn (ví dụ 7195)
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7195/api/")
        };

        // Gắn Bearer Token trước mỗi request
        private static void AttachToken()
        {
            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
        }

        // 1. Đăng nhập
        public static async Task<bool> LoginAsync(string username, string password)
        {
            var loginObj = new { Username = username, Password = password };
            var response = await _client.PostAsJsonAsync("auth/login", loginObj);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonString);

                SessionManager.JwtToken = doc.RootElement.GetProperty("token").GetString() ?? string.Empty;
                SessionManager.CurrentRole = doc.RootElement.GetProperty("role").GetString() ?? string.Empty;
                return true;
            }
            return false;
        }

        // 2. GET dữ liệu có kèm Token
        public static async Task<string> GetDataWithTokenAsync(string endpoint)
        {
            AttachToken();
            var response = await _client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("Phiên làm việc hết hạn hoặc chưa đăng nhập (401)!");
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new Exception("Bạn không có quyền truy cập chức năng này (403)!");

            throw new Exception($"Lỗi kết nối API: {response.StatusCode}");
        }

        // 3. POST dữ liệu có kèm Token
        public static async Task<HttpResponseMessage> PostWithTokenAsync<T>(string endpoint, T data)
        {
            AttachToken();
            return await _client.PostAsJsonAsync(endpoint, data);
        }

        // 4. PUT dữ liệu có kèm Token
        public static async Task<HttpResponseMessage> PutWithTokenAsync<T>(string endpoint, T data)
        {
            AttachToken();
            return await _client.PutAsJsonAsync(endpoint, data);
        }

        // 5. DELETE dữ liệu có kèm Token
        public static async Task<HttpResponseMessage> DeleteWithTokenAsync(string endpoint)
        {
            AttachToken();
            return await _client.DeleteAsync(endpoint);
        }
    }
}