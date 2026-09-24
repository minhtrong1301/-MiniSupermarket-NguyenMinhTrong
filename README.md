# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

> **Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)
> **Buổi thực hành:** Buổi 2 - Xây dựng hệ thống xác thực JWT Authentication và phân quyền API

---

## 🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)

Dự án tiếp tục được xây dựng theo mô hình **Client - Server**, trong đó Backend cung cấp các API và Frontend WinForms đóng vai trò ứng dụng máy trạm.

Hệ thống được bổ sung cơ chế **JWT Authentication (JSON Web Token)** nhằm xác thực người dùng khi truy cập các API có yêu cầu đăng nhập.

* **`MiniSupermarket.API` (Backend):** Dự án ASP.NET Core Web API chịu trách nhiệm xử lý xác thực người dùng, cấp JWT Token, kiểm tra quyền truy cập và cung cấp các RESTful API.
* **`MiniSupermarket.WinForms` (Frontend Client):** Ứng dụng Windows Forms sử dụng `HttpClient` để đăng nhập, nhận JWT Token và gửi Token trong Header khi gọi các API được bảo vệ.

Luồng hoạt động của hệ thống:

```text
┌─────────────────────────────┐
│   MiniSupermarket.WinForms  │
│       (Client)              │
└──────────────┬──────────────┘
               │
               │ Login / API Request
               │ Authorization: Bearer <JWT>
               ▼
┌─────────────────────────────┐
│     MiniSupermarket.API     │
│        (Backend)            │
├─────────────────────────────┤
│ Authentication / JWT        │
│ Authorization / Role        │
│ Controllers / API           │
└──────────────┬──────────────┘
               │
               ▼
        Dữ liệu hệ thống
```

---

## 🛠️ 2. Công nghệ Sử dụng

* **Ngôn ngữ:** C# (.NET 8.0)
* **Backend:** ASP.NET Core Web API
* **Authentication:** JWT Bearer Authentication
* **Authorization:** Role-based Authorization
* **API:** RESTful API, Controllers
* **Dữ liệu:** In-Memory Data
* **Xử lý dữ liệu:** LINQ
* **Frontend:** Windows Forms (.NET 8.0)
* **HTTP Client:** `HttpClient`, `System.Net.Http.Json`
* **Kiểm thử API:** Swagger UI
* **IDE:** Visual Studio 2022

---

## 📂 3. Cấu trúc Solution

```text
MiniSupermarketSystem/
│
├── MiniSupermarket.API/                  # Dự án Web API (Backend)
│   ├── Controllers/
│   │   ├── AuthController.cs             # Đăng nhập và cấp JWT Token
│   │   └── CategoriesController.cs       # CRUD danh mục
│   │
│   ├── Models/
│   │   ├── Category.cs                    # Model danh mục
│   │   └── User.cs                        # Model người dùng
│   │
│   ├── Services/
│   │   └── JwtService.cs                  # Xử lý tạo JWT Token
│   │
│   ├── Program.cs                         # Cấu hình JWT Authentication
│   └── appsettings.json                   # Cấu hình JWT
│
└── MiniSupermarket.WinForms/              # Dự án Windows Forms (Frontend)
    ├── FormLogin.cs                       # Giao diện đăng nhập
    ├── FormCategoryManagement.cs          # Quản lý danh mục
    └── ApiClientService.cs                # Gọi API và quản lý JWT Token
```

---

# 🔐 4. Chức năng Authentication

Buổi 2 bổ sung chức năng đăng nhập cho hệ thống.

Người dùng gửi tài khoản và mật khẩu đến API:

```http
POST /api/auth/login
```

Ví dụ dữ liệu gửi lên:

```json
{
  "username": "admin",
  "password": "123456"
}
```

Nếu thông tin đăng nhập hợp lệ, API trả về JWT Token:

```json
{
  "token": "eyJhbGciOiJIUzI1NiIs..."
}
```

Token này được phía WinForms lưu lại để sử dụng cho những lần gọi API tiếp theo.

---

# 🎫 5. JWT Authentication

JWT được sử dụng để xác thực người dùng khi truy cập các API được bảo vệ.

Khi gọi API, WinForms gửi Token thông qua HTTP Header:

```http
Authorization: Bearer <JWT_TOKEN>
```

Ví dụ:

```http
GET /api/categories
Authorization: Bearer eyJhbGciOiJIUzI1NiIs...
```

Backend sẽ kiểm tra Token trước khi cho phép request tiếp tục xử lý.

Nếu Token hợp lệ:

```text
Client
   │
   │ Bearer Token
   ▼
JWT Authentication
   │
   ├── Hợp lệ ──► Cho phép truy cập API
   │
   └── Không hợp lệ ──► HTTP 401 Unauthorized
```

---

# 👮 6. Phân quyền người dùng

Hệ thống hỗ trợ phân quyền dựa trên **Role**.

Ví dụ:

| Role  | Quyền                                  |
| ----- | -------------------------------------- |
| Admin | Quản lý toàn bộ hệ thống               |
| Staff | Thực hiện các chức năng được cấp quyền |

Các API có thể được bảo vệ bằng:

```csharp
[Authorize]
```

Hoặc giới hạn theo Role:

```csharp
[Authorize(Roles = "Admin")]
```

Ví dụ:

```text
Admin
 ├── Xem danh mục
 ├── Thêm danh mục
 ├── Sửa danh mục
 └── Xóa danh mục

Staff
 └── Chỉ được truy cập các chức năng được cấp phép
```

---

# 🧪 7. Kiểm thử API bằng Swagger

Sau khi chạy `MiniSupermarket.API`, mở giao diện Swagger UI.

Thực hiện kiểm thử theo thứ tự:

### Bước 1: Đăng nhập

Gọi:

```http
POST /api/auth/login
```

Nhập:

```json
{
  "username": "admin",
  "password": "123456"
}
```

Lấy giá trị `token` trong response.

### Bước 2: Authorize

Nhấn nút **Authorize** trên Swagger.

Nhập:

```text
Bearer <JWT_TOKEN>
```

Sau đó nhấn **Authorize**.

### Bước 3: Gọi API được bảo vệ

Thử các API:

```http
GET
POST
PUT
DELETE
```

Nếu Token hợp lệ, API sẽ xử lý request bình thường.

Nếu chưa đăng nhập hoặc Token không hợp lệ, API sẽ trả về:

```http
401 Unauthorized
```

Nếu đã đăng nhập nhưng không có đủ quyền:

```http
403 Forbidden
```

---

# 🖥️ 8. Kết nối WinForms với API

Phía `MiniSupermarket.WinForms` được bổ sung giao diện đăng nhập.

Quy trình sử dụng:

```text
Mở ứng dụng
     │
     ▼
Form Login
     │
     │ Username + Password
     ▼
POST /api/auth/login
     │
     ▼
Nhận JWT Token
     │
     ▼
Lưu Token
     │
     ▼
Mở Form quản lý
     │
     ▼
Gọi API kèm Bearer Token
```

Ví dụ khi gọi API:

```csharp
client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", token);
```

Sau đó WinForms có thể thực hiện các thao tác CRUD đối với danh mục.

---

# 🚀 9. Hướng dẫn Chạy và Kiểm thử Dự án

## Bước 1: Chạy Backend

Mở Solution bằng **Visual Studio 2022**.

Nhấp chuột phải vào:

```text
MiniSupermarket.API
```

Chọn:

```text
Set as Startup Project
```

Nhấn:

```text
F5
```

Swagger UI sẽ được mở trên trình duyệt.

---

## Bước 2: Kiểm tra Authentication

Trên Swagger:

1. Mở API Login.
2. Nhập Username và Password.
3. Gửi request.
4. Copy JWT Token được trả về.
5. Nhấn **Authorize**.
6. Nhập:

```text
Bearer <JWT_TOKEN>
```

7. Thực hiện gọi các API yêu cầu xác thực.

---

## Bước 3: Chạy WinForms Client

Nhấp chuột phải vào:

```text
MiniSupermarket.WinForms
```

Chọn:

```text
Debug → Start new instance
```

Form Login sẽ được hiển thị.

Nhập tài khoản:

```text
Username: admin
Password: 123456
```

Sau khi đăng nhập thành công, hệ thống chuyển đến màn hình quản lý danh mục.

---

## Bước 4: Kiểm thử CRUD

Thực hiện các chức năng:

* Đăng nhập hệ thống.
* Tải danh sách danh mục.
* Thêm danh mục.
* Tìm kiếm danh mục.
* Cập nhật danh mục.
* Xóa danh mục.
* Kiểm tra quyền truy cập API.
* Kiểm tra trường hợp Token không hợp lệ hoặc hết hạn.

---

# 🔒 10. Kiểm thử các trường hợp Authentication

| Trường hợp                       | Kết quả mong đợi      |
| -------------------------------- | --------------------- |
| Username + Password đúng         | Đăng nhập thành công  |
| Username sai                     | Đăng nhập thất bại    |
| Password sai                     | Đăng nhập thất bại    |
| Không có JWT Token               | `401 Unauthorized`    |
| JWT Token không hợp lệ           | `401 Unauthorized`    |
| Token hợp lệ nhưng không đủ Role | `403 Forbidden`       |
| Token hợp lệ và đúng Role        | Cho phép truy cập API |

---

# 📌 11. Kết quả đạt được

Sau khi hoàn thành Buổi 2, hệ thống có các chức năng chính:

* Xây dựng Web API bằng ASP.NET Core .NET 8.
* Xây dựng chức năng đăng nhập.
* Sử dụng JWT để xác thực người dùng.
* Bảo vệ API bằng `[Authorize]`.
* Phân quyền người dùng bằng Role.
* Kết nối WinForms Client với Web API.
* Gửi JWT Token từ WinForms đến Backend.
* Thực hiện CRUD danh mục thông qua API.
* Kiểm thử Authentication và Authorization bằng Swagger.

---

## 👨‍💻 12. Tác giả

**Họ tên sinh viên:** Nguyễn Minh Trọng

**Mã sinh viên:** 2124110253

**Lớp học phần:** CCQ2411D
