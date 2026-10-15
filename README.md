# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

**Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)

**Buổi thực hành:** Buổi 4 - Xác thực JWT, phân quyền người dùng và quản lý tài khoản (Users Management)

---

## 🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)

Dự án tiếp tục được phát triển theo mô hình Client - Server, sử dụng ASP.NET Core Web API kết hợp với Windows Forms. Hệ thống xác thực người dùng bằng JWT (JSON Web Token), phân quyền truy cập theo vai trò và lưu trữ thông tin tài khoản trên SQL Server thông qua Entity Framework Core.

**MiniSupermarket.API (Backend):** Xử lý đăng nhập, tạo JWT Token, xác thực người dùng, phân quyền truy cập API và cung cấp các chức năng quản lý tài khoản.

**MiniSupermarket.WinForms (Frontend Client):** Cung cấp giao diện đăng nhập và quản lý tài khoản. Ứng dụng sử dụng `HttpClient` để gửi yêu cầu đến API, truyền JWT Bearer Token trong Header khi gọi các API cần xác thực.

**Luồng hoạt động của hệ thống:**

```text
┌────────────────────────────────┐
│     MiniSupermarket.WinForms   │
│          (Client)              │
├────────────────────────────────┤
│ FormLogin                      │
│ FormMainShell                  │
│ FormUserManagement             │
│ SessionManager / ApiClient     │
└───────────────┬────────────────┘
                │
                │ HTTP Request / JSON
                │ Authorization: Bearer <JWT>
                ▼
┌────────────────────────────────┐
│       MiniSupermarket.API      │
├────────────────────────────────┤
│ AuthController                 │
│ UsersController                │
│ JWT Authentication             │
│ Role-based Authorization       │
│ Entity Framework Core          │
└───────────────┬────────────────┘
                │
                │ DbContext / SQL Queries
                ▼
┌────────────────────────────────┐
│        SQL Server              │
│  NguyenMinhTrong_MiniSupermarketDb │
├────────────────────────────────┤
│ Users / Customers / Products   │
│ Orders / OrderDetails          │
└────────────────────────────────┘
```

---

## 🛠️ 2. Công nghệ Sử dụng

- **Ngôn ngữ:** C#.
- **Nền tảng:** .NET 8.0.
- **Backend:** ASP.NET Core Web API.
- **ORM:** Entity Framework Core 8.
- **Database:** Microsoft SQL Server Express.
- **Xác thực:** JWT Bearer Authentication.
- **Mã hóa mật khẩu:** `PasswordHasher<string>` của ASP.NET Core Identity.
- **Phân quyền:** Role-based Authorization.
- **Frontend:** Windows Forms (.NET 8.0).
- **Giao tiếp API:** `HttpClient`, `System.Net.Http.Json`.
- **Kiểm thử API:** Swagger UI.
- **Quản lý mã nguồn:** Git và GitHub.

---

## 📂 3. Cấu trúc Solution

```text
MiniSupermarketSystem/
│
├── MiniSupermarket.API/
│   ├── Controllers/
│   │   ├── AuthController.cs
│   │   ├── CustomersController.cs
│   │   ├── ProductsController.cs
│   │   ├── OrdersController.cs
│   │   └── UsersController.cs
│   │
│   ├── Models/
│   │   ├── User.cs
│   │   ├── Customer.cs
│   │   ├── Product.cs
│   │   ├── Order.cs
│   │   └── OrderDetail.cs
│   │
│   ├── Services/
│   │   ├── JwtService.cs
│   │   └── PasswordService.cs
│   │
│   ├── Migrations/
│   ├── SupermarketDbContext.cs
│   ├── Program.cs
│   └── appsettings.json
│
└── MiniSupermarket.WinForms/
    ├── FormLogin.cs
    ├── FormMainShell.cs
    ├── FormUserManagement.cs
    ├── FormUserManagement.Designer.cs
    ├── FormCustomerManagement.cs
    ├── FormProductManagement.cs
    ├── FormPOS.cs
    ├── SessionManager.cs
    └── Program.cs
```

*Lưu ý: Cấu trúc trên mô tả các thành phần chính của dự án. Tên hoặc vị trí một số tệp có thể khác tùy theo phiên bản mã nguồn hiện tại.*

---

## 🗄️ 4. Quản lý tài khoản và Data Seeding

Trong buổi thực hành này, hệ thống được bổ sung chức năng quản lý tài khoản người dùng. Thông tin tài khoản được lưu trong bảng `Users` trên SQL Server.

### 4.1. Cấu trúc tài khoản

Model `User` gồm các thuộc tính chính:

| Thuộc tính | Ý nghĩa |
|---|---|
| `Id` | Mã tài khoản |
| `Username` | Tên đăng nhập |
| `PasswordHash` | Mật khẩu đã được băm |
| `FullName` | Họ và tên người dùng |
| `Role` | Vai trò tài khoản |
| `IsActive` | Trạng thái hoạt động |

Mật khẩu không được lưu trực tiếp dưới dạng văn bản thông thường. Hệ thống sử dụng `PasswordHasher<string>` để băm mật khẩu và kiểm tra mật khẩu khi đăng nhập.

### 4.2. Dữ liệu tài khoản mẫu

Hệ thống đã bổ sung 15 tài khoản mẫu bằng cơ chế Data Seeding trong `SupermarketDbContext.cs`.

| STT | Tên đăng nhập | Vai trò |
|---:|---|---|
| 1 | `admin01` | Admin |
| 2 | `admin02` | Admin |
| 3 | `cashier01` | Cashier |
| 4 | `cashier02` | Cashier |
| 5 | `cashier03` | Cashier |
| 6 | `cashier04` | Cashier |
| 7 | `cashier05` | Cashier |
| 8 | `ware01` | Warehouse |
| 9 | `ware02` | Warehouse |
| 10 | `ware03` | Warehouse |
| 11 | `ware04` | Warehouse |
| 12 | `admin_backup` | Admin |
| 13 | `cashier06` | Cashier |
| 14 | `ware05` | Warehouse |
| 15 | `supervisor` | Admin |

**Tài khoản kiểm thử:** `admin01`

**Mật khẩu ban đầu:** `123456`

Các tài khoản mẫu được sử dụng để kiểm thử chức năng đăng nhập và phân quyền trong môi trường thực hành. Không nên sử dụng mật khẩu mẫu này cho hệ thống thực tế.

### 4.3. Phân quyền người dùng

Hệ thống hiện có ba vai trò:

- **Admin:** Có quyền truy cập chức năng quản lý tài khoản.
- **Cashier:** Dành cho nhân viên thu ngân.
- **Warehouse:** Dành cho nhân viên quản lý kho.

API quản lý tài khoản sử dụng `[Authorize(Roles = "Admin")]` để giới hạn quyền truy cập. Người dùng chưa đăng nhập hoặc không có quyền phù hợp sẽ không được phép thực hiện các thao tác quản trị.

---

## 🔐 5. Chức năng xác thực và quản lý tài khoản

### 5.1. Đăng nhập bằng JWT

API `POST /api/Auth/login` tiếp nhận tên đăng nhập và mật khẩu. Khi thông tin hợp lệ, hệ thống trả về JWT Token cùng thông tin người dùng và vai trò.

WinForms lưu thông tin phiên đăng nhập trong `SessionManager`, sau đó đính kèm Token vào Header của các yêu cầu API cần xác thực:

```http
Authorization: Bearer <JWT_TOKEN>
```

### 5.2. Danh sách API quản lý tài khoản

| Phương thức | Endpoint | Chức năng |
|---|---|---|
| POST | `/api/Auth/login` | Đăng nhập |
| GET | `/api/Users` | Lấy danh sách tài khoản |
| POST | `/api/Users` | Tạo tài khoản mới |
| PUT | `/api/Users/{id}/reset-password` | Đặt lại mật khẩu |
| PUT | `/api/Users/{id}/toggle-lock` | Khóa hoặc mở khóa tài khoản |

Các API quản lý tài khoản yêu cầu quyền Admin.

### 5.3. Giao diện quản lý tài khoản

Giao diện `FormUserManagement` được xây dựng trên Windows Forms, bao gồm:

- Hiển thị danh sách tài khoản bằng `DataGridView`.
- Nhập tên đăng nhập, mật khẩu, họ tên và vai trò.
- Thêm tài khoản mới thông qua API.
- Chọn tài khoản để đặt lại mật khẩu.
- Khóa hoặc mở khóa tài khoản.
- Tải lại danh sách sau khi cập nhật dữ liệu.
- Hiển thị thông báo khi thao tác thành công hoặc thất bại.

### 5.4. Tích hợp vào giao diện chính

`FormMainShell` tích hợp chức năng quản lý tài khoản vào cửa sổ chính của ứng dụng.

Khi người dùng chọn chức năng quản lý tài khoản, hệ thống kiểm tra vai trò hiện tại. Chỉ tài khoản có vai trò `Admin` mới được phép mở giao diện quản lý tài khoản.

---

## ⚙️ 6. Hướng dẫn khởi chạy dự án

### Bước 1. Chuẩn bị môi trường

Cài đặt hoặc kiểm tra các thành phần sau:

- .NET 8 SDK.
- Visual Studio hoặc Visual Studio Code.
- SQL Server Express và SQL Server Management Studio (SSMS), nếu cần giao diện quản lý CSDL.
- Các gói NuGet cần thiết của dự án.

### Bước 2. Kiểm tra cấu hình kết nối CSDL

Mở tệp `appsettings.json` trong dự án API và kiểm tra `ConnectionStrings` cùng cấu hình JWT.

Đảm bảo Connection String trỏ đến đúng SQL Server instance và database đang sử dụng. Không đưa mật khẩu thật hoặc khóa bí mật dùng trong môi trường triển khai lên GitHub.

### Bước 3. Cập nhật Database bằng EF Core

Mở Terminal tại thư mục `MiniSupermarket.API`, sau đó kiểm tra các migration hiện có:

```powershell
dotnet ef migrations list
```

Nếu đã có migration trong dự án, cập nhật database bằng:

```powershell
dotnet ef database update
```

Không tạo lại `InitialCreate` hoặc xóa database đang sử dụng nếu không có yêu cầu reset rõ ràng. Khi cần thêm migration mới, hãy kiểm tra trạng thái schema và migration hiện có trước khi thực hiện.

### Bước 4. Khởi chạy API

Tại thư mục `MiniSupermarket.API`, chạy:

```powershell
dotnet run
```

Kiểm tra URL thực tế được in trong Terminal. Địa chỉ HTTPS có thể khác giữa các máy hoặc cấu hình chạy.

### Bước 5. Khởi chạy WinForms

Mở solution bằng Visual Studio, chọn `MiniSupermarket.WinForms` làm Startup Project và chạy ứng dụng.

Nhập thông tin đăng nhập hợp lệ để kiểm tra giao diện chính và chức năng quản lý tài khoản.

---

## 🧪 7. Kiểm thử API bằng Swagger UI

### 7.1. Kiểm thử đăng nhập

Gửi yêu cầu `POST /api/Auth/login` với dữ liệu JSON:

```json
{
  "username": "admin01",
  "password": "123456"
}
```

Tên thuộc tính và định dạng dữ liệu cần khớp với DTO mà `AuthController` đang sử dụng.

Nếu đăng nhập thành công, kiểm tra phản hồi có JWT Token và thông tin vai trò.

### 7.2. Kiểm thử API quản lý tài khoản

**GET `/api/Users`**

Lấy danh sách tài khoản. Yêu cầu Token hợp lệ và quyền Admin.

**POST `/api/Users`**

Tạo tài khoản mới. Kiểm tra dữ liệu bắt buộc, vai trò và trường hợp tên đăng nhập bị trùng.

Ví dụ dữ liệu gửi lên:

```json
{
  "username": "cashier_test",
  "password": "123456",
  "fullName": "Nhan vien kiem thu",
  "role": "Cashier"
}
```

**PUT `/api/Users/{id}/reset-password`**

Đặt lại mật khẩu cho tài khoản có ID tương ứng.

Ví dụ Body:

```json
{
  "newPassword": "123456"
}
```

**PUT `/api/Users/{id}/toggle-lock`**

Khóa hoặc mở khóa tài khoản được chọn. Kiểm tra trường `IsActive` sau khi thực hiện thao tác.

### 7.3. Các trường hợp cần kiểm thử

- Đăng nhập với tài khoản và mật khẩu đúng.
- Đăng nhập với mật khẩu sai.
- Gọi API quản lý tài khoản khi chưa có Token.
- Gọi API quản lý tài khoản bằng tài khoản không có quyền Admin.
- Thêm tài khoản hợp lệ.
- Thêm tài khoản có tên đăng nhập bị trùng.
- Đặt lại mật khẩu tài khoản.
- Khóa và mở khóa tài khoản.
- Kiểm tra giao diện WinForms cập nhật danh sách sau khi thao tác.

---

## 📌 8. Kết quả đạt được (Buổi 4)

- Xây dựng và tích hợp chức năng đăng nhập bằng JWT.
- Bổ sung cơ chế băm và kiểm tra mật khẩu bằng `PasswordHasher<string>`.
- Bổ sung model tài khoản người dùng và dữ liệu Data Seeding.
- Triển khai API lấy danh sách, thêm tài khoản, đặt lại mật khẩu và khóa/mở khóa tài khoản.
- Áp dụng phân quyền theo vai trò Admin, Cashier và Warehouse.
- Tích hợp giao diện quản lý tài khoản vào ứng dụng Windows Forms.
- Sử dụng `HttpClient` để kết nối WinForms với ASP.NET Core Web API.
- Tiếp tục phát triển và quản lý mã nguồn trên nhánh Git `Buoi4`.

---

## 📌 9. Quản lý phiên bản với Git

Kiểm tra trạng thái mã nguồn:

```powershell
git status
```

Thêm các tệp đã được kiểm tra vào Staging:

```powershell
git add <duong-dan-file>
```

Commit các thay đổi của buổi 4:

```powershell
git commit -m "Hoan thanh buoi 4 quan ly tai khoan"
```

Kiểm tra nhánh hiện tại:

```powershell
git branch --show-current
```

Đồng bộ lên GitHub:

```powershell
git push origin Buoi4
```

Trước khi commit, cần kiểm tra kỹ danh sách file thay đổi để tránh đưa nhầm cấu hình nhạy cảm, file không liên quan hoặc các thay đổi chưa hoàn thiện vào repository.

---

## 👨‍💻 10. Thông tin sinh viên

- **Họ tên sinh viên:** Nguyễn Minh Trọng
- **Mã sinh viên:** 2124110253
- **Lớp học phần:** CCQ2411D
- **Môn học:** Lập trình Ứng dụng .NET Core
- **Buổi thực hành:** Buổi 4
