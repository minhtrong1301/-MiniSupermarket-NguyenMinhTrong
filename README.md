# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

**Môn học:** Lập trình Ứng dụng .NET Core  
**Mã môn học:** 229162  
**Buổi thực hành:** Buổi 3 – Kết nối CSDL SQL Server với Entity Framework Core, Data Seeding và quản lý Khách hàng (Customers)

---

## 🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)

Dự án tiếp tục được phát triển theo mô hình **Client - Server**, sử dụng SQL Server làm cơ sở dữ liệu tập trung, Entity Framework Core (EF Core) để truy xuất dữ liệu và JWT Authentication để xác thực, phân quyền API.

### 🔹 Các thành phần chính

| Thành phần | Mô tả |
|---|---|
| **MiniSupermarket.API (Backend)** | ASP.NET Core Web API xử lý xác thực JWT, kết nối SQL Server qua EF Core, thực hiện Data Seeding và cung cấp các RESTful API quản lý hệ thống. |
| **MiniSupermarket.WinForms (Frontend Client)** | Ứng dụng Windows Forms sử dụng `HttpClient` để gửi và nhận dữ liệu JSON, đồng thời đính kèm JWT Bearer Token trong Header khi gọi API cần xác thực. |
| **SQL Server Database** | Lưu trữ dữ liệu tập trung của hệ thống, bao gồm tài khoản, danh mục và khách hàng. |

### 🔄 Luồng hoạt động của hệ thống

```text
┌─────────────────────────────────┐
│     MiniSupermarket.WinForms    │
│             (Client)            │
└────────────────┬────────────────┘
                 │
                 │ API Request (HTTP/JSON)
                 │ Authorization: Bearer <JWT>
                 ▼
┌─────────────────────────────────┐
│        MiniSupermarket.API      │
│            (Backend)            │
├─────────────────────────────────┤
│ JWT Authentication & Role       │
│ Controllers / RESTful API       │
│ Entity Framework Core (ORM)     │
└────────────────┬────────────────┘
                 │
                 │ DbContext / Migrations
                 ▼
┌─────────────────────────────────┐
│       SQL Server Database       │
│       (MiniSupermarketDb)       │
└─────────────────────────────────┘
```

---

## 🛠️ 2. Công nghệ Sử dụng

Hệ thống sử dụng các công nghệ và công cụ sau:

| Công nghệ | Phiên bản / Thành phần | Vai trò |
|---|---|---|
| **Ngôn ngữ lập trình** | C# | Phát triển ứng dụng |
| **Nền tảng** | .NET 8.0 | Chạy Backend và Frontend |
| **Backend** | ASP.NET Core Web API | Xây dựng RESTful API |
| **ORM** | Entity Framework Core 8.0 | Truy xuất và quản lý dữ liệu |
| **Database** | Microsoft SQL Server | Lưu trữ dữ liệu tập trung |
| **Database Context** | `SupermarketDbContext` | Quản lý kết nối và ánh xạ dữ liệu |
| **Database Migration** | EF Core Code-First Migration | Quản lý thay đổi cấu trúc CSDL |
| **Data Seeding** | EF Core | Khởi tạo dữ liệu mẫu |
| **Authentication** | JWT Bearer Authentication | Xác thực người dùng |
| **Authorization** | Role-based Authorization | Phân quyền theo vai trò |
| **Frontend** | Windows Forms (.NET 8.0) | Xây dựng giao diện Desktop |
| **HTTP Client** | `HttpClient`, `System.Net.Http.Json` | Giao tiếp giữa Client và API |
| **Kiểm thử API** | Swagger UI | Kiểm tra các Endpoint |
| **Quản lý phiên bản** | Git & GitHub | Theo dõi và đồng bộ mã nguồn |

---

## 📂 3. Cấu trúc Solution

Cấu trúc thư mục chính của dự án được tổ chức như sau:

```text
MiniSupermarketSystem/
│
├── MiniSupermarket.API/                  # Dự án Web API (Backend)
│   ├── Controllers/
│   │   ├── AuthController.cs             # Đăng nhập và cấp JWT Token
│   │   ├── CategoriesController.cs       # CRUD danh mục sản phẩm
│   │   └── CustomersController.cs        # CRUD khách hàng
│   │
│   ├── Data/
│   │   └── SupermarketDbContext.cs       # EF Core DbContext, cấu hình Entity và Seeding
│   │
│   ├── Migrations/                       # Các bản EF Core Migration
│   │
│   ├── Models/
│   │   ├── Category.cs                   # Model danh mục
│   │   ├── Customer.cs                   # Model khách hàng
│   │   └── User.cs                       # Model người dùng và tài khoản
│   │
│   ├── Services/
│   │   └── JwtService.cs                 # Service khởi tạo JWT Token
│   │
│   ├── Program.cs                        # Đăng ký DbContext, JWT và Dependency Injection
│   └── appsettings.json                  # Cấu hình ConnectionString và JWT Settings
│
└── MiniSupermarket.WinForms/             # Dự án Windows Forms (Frontend)
    ├── FormLogin.cs                      # Giao diện đăng nhập
    ├── FormCategoryManagement.cs         # Quản lý danh mục
    ├── FormCustomerManagement.cs         # Quản lý khách hàng
    └── ApiClientService.cs               # Service gọi API và quản lý JWT Token
```

### 📌 Mô tả Entity Customer

Entity `Customer` quản lý thông tin khách hàng với các thuộc tính chính:

- `CustomerId`: Mã khách hàng.
- `CustomerName`: Họ và tên khách hàng.
- `PhoneNumber`: Số điện thoại.
- `Address`: Địa chỉ.
- `MembershipRank`: Hạng thành viên.
- `RewardPoints`: Điểm tích lũy.

---

## 🗄️ 4. Cơ sở dữ liệu & Data Seeding (Customers)

Hệ thống sử dụng **SQL Server** làm cơ sở dữ liệu tập trung. Entity `Customer` được cấu hình Data Seeding trong `SupermarketDbContext.cs` với **15 khách hàng mẫu** thuộc nhiều hạng thành viên khác nhau.

### 📋 Danh sách 15 khách hàng Seeding mẫu

| STT | Họ và tên | Số điện thoại | Hạng thành viên | Điểm tích lũy |
|:---:|---|:---:|:---:|---:|
| 1 | Nguyễn Văn An | `0912345678` | Bạc | 350 |
| 2 | Trần Thị Bình | `0987654321` | Kim Cương | 1200 |
| 3 | Lê Hoàng Cường | `0903112233` | Chuẩn | 50 |
| 4 | Phạm Minh Dung | `0938889900` | Vàng | 750 |
| 5 | Hoàng Quốc Dung | `0977123456` | Chuẩn | 0 |
| 6 | Đỗ Thị Giang | `0966554433` | Chuẩn | 150 |
| 7 | Vũ Hải Đăng | `0944118899` | Bạc | 520 |
| 8 | Ngô Bích Hằng | `0918273645` | Kim Cương | 2100 |
| 9 | Bùi Anh Tuấn | `0922334455` | Vàng | 890 |
| 10 | Đặng Thu Thảo | `0955667788` | Bạc | 410 |
| 11 | Trịnh Quốc Bảo | `0909090909` | Chuẩn | 30 |
| 12 | Lý Mỹ Nhân | `0933221100` | Vàng | 1050 |
| 13 | Dương Văn Khoa | `0978990011` | Bạc | 620 |
| 14 | Mai Phương Thúy | `0911223344` | Kim Cương | 1850 |
| 15 | Cao Thái Sơn | `0945678901` | Chuẩn | 95 |

### 🎯 Mục tiêu của Data Seeding

- Khởi tạo dữ liệu khách hàng mẫu khi tạo cơ sở dữ liệu.
- Hỗ trợ kiểm thử các API quản lý khách hàng.
- Minh họa cách cấu hình dữ liệu ban đầu bằng Entity Framework Core.
- Tạo dữ liệu phục vụ phát triển và kiểm thử giao diện quản lý khách hàng trên WinForms.

---

## ⚙️ 5. Hướng dẫn Khởi tạo & Cập nhật Database (EF Core Migrations)

Khi làm mới database hoặc thay đổi cấu hình Data Seeding trong `SupermarketDbContext.cs`, thực hiện các bước sau trong **Package Manager Console (PMC)** của Visual Studio.

### Bước 1: Xóa cơ sở dữ liệu cũ (nếu muốn reset sạch)

```powershell
Drop-Database
```

> ⚠️ **Lưu ý:** Lệnh này có thể xóa dữ liệu hiện có trong database. Hãy sao lưu dữ liệu quan trọng trước khi thực hiện.

### Bước 2: Tạo Migration mới

```powershell
Add-Migration InitialCreate
```

### Bước 3: Cập nhật cơ sở dữ liệu

```powershell
Update-Database
```

Sau khi hoàn tất, EF Core sẽ cập nhật cấu trúc bảng trong SQL Server theo Migration và áp dụng dữ liệu Seeding được cấu hình trong model.

> **Lưu ý kỹ thuật:** Nếu dự án đã có Migration trước đó, không nên tạo lại `InitialCreate` với cùng tên. Hãy kiểm tra thư mục `Migrations` và trạng thái database trước khi quyết định tạo Migration mới hay reset lịch sử Migration.

---

## 🔐 6. Xử lý Quản lý Version với Git

Dự án sử dụng Git và GitHub để quản lý mã nguồn, theo dõi thay đổi và đồng bộ quá trình thực hiện bài thực hành trên nhánh `Buoi3`.

### Bước 1: Kiểm tra trạng thái thay đổi

```bash
git status
```

### Bước 2: Đưa các thay đổi vào Staging

```bash
git add .
```

### Bước 3: Commit thay đổi

```bash
git commit -m "Update customer seed data to 15 records and reset migrations"
```

### Bước 4: Đẩy mã nguồn lên GitHub

```bash
git push origin Buoi3
```

Nếu thực sự cần ghi đè lịch sử trên nhánh từ xa, có thể sử dụng:

```bash
git push origin Buoi3 --force-with-lease
```

> ⚠️ **Lưu ý:** Chỉ sử dụng `--force-with-lease` khi bạn hiểu rõ lịch sử Git cần thay thế và đã kiểm tra các thay đổi của cộng tác viên. Không nên force push chỉ để xử lý lỗi push thông thường.

---

## 🧪 7. Kiểm thử API bằng Swagger UI

Sau khi khởi chạy dự án `MiniSupermarket.API`, truy cập Swagger UI để kiểm thử các Endpoint.

### 🔑 Bước 1: Đăng nhập và lấy JWT Token

Gửi request:

```http
POST /api/auth/login
```

Sử dụng tài khoản kiểm thử được cấu hình trong hệ thống:

| Thông tin | Giá trị |
|---|---|
| Tài khoản | `admin` |
| Mật khẩu | `123456` |

> Tài khoản trên chỉ sử dụng được nếu đã được cấu hình trong dữ liệu hoặc cơ chế khởi tạo tài khoản của dự án.

### 🔒 Bước 2: Xác thực trên Swagger

1. Gọi API đăng nhập để nhận JWT Token.
2. Nhấn nút **Authorize** trên giao diện Swagger UI.
3. Nhập Token theo định dạng mà Swagger được cấu hình hỗ trợ. Nếu yêu cầu Bearer Token, sử dụng:

```text
Bearer <JWT_TOKEN>
```

4. Nhấn **Authorize**, sau đó đóng cửa sổ xác thực.
5. Thực hiện các API cần quyền truy cập.

### 👥 Bước 3: Kiểm thử CustomersController

| HTTP Method | Endpoint | Chức năng |
|:---:|---|---|
| `GET` | `/api/customers` | Lấy danh sách khách hàng |
| `GET` | `/api/customers/{id}` | Xem chi tiết một khách hàng |
| `POST` | `/api/customers` | Thêm khách hàng mới |
| `PUT` | `/api/customers/{id}` | Cập nhật thông tin khách hàng |
| `DELETE` | `/api/customers/{id}` | Xóa khách hàng |

### 📝 Kết quả mong đợi

- API `GET /api/customers` trả về danh sách 15 khách hàng nếu database đã được khởi tạo đúng và chưa có thao tác thêm hoặc xóa dữ liệu.
- API `GET /api/customers/{id}` trả về thông tin khách hàng tương ứng khi ID tồn tại.
- Các API `POST`, `PUT` và `DELETE` thực hiện thao tác tương ứng khi request hợp lệ và người dùng có đủ quyền.
- Các Endpoint được bảo vệ yêu cầu JWT Token hợp lệ theo cấu hình xác thực và phân quyền của hệ thống.

---

## 📌 8. Kết quả Đạt được (Buổi 3)

Sau khi hoàn thành buổi thực hành, dự án hướng đến các kết quả sau:

- ✅ Kết nối ASP.NET Core Web API với SQL Server thông qua Entity Framework Core.
- ✅ Xây dựng Entity `Customer` để quản lý thông tin khách hàng.
- ✅ Cấu hình Data Seeding với 15 khách hàng mẫu thuộc các hạng Chuẩn, Bạc, Vàng và Kim Cương.
- ✅ Sử dụng EF Core Migrations để quản lý và cập nhật cấu trúc cơ sở dữ liệu.
- ✅ Xây dựng RESTful API hỗ trợ các thao tác CRUD khách hàng.
- ✅ Tích hợp JWT Authentication và cơ chế phân quyền theo vai trò.
- ✅ Sử dụng Swagger UI để kiểm thử các Endpoint.
- ✅ Quản lý và đồng bộ mã nguồn bằng Git/GitHub trên nhánh `Buoi3`.

---

## 👨‍💻 9. Tác giả

| Thông tin | Nội dung |
|---|---|
| **Họ tên sinh viên** | Nguyễn Minh Trọng |
| **Mã sinh viên** | `2124110253` |
| **Lớp học phần** | `CCQ2411D` |
| **Môn học** | Lập trình Ứng dụng .NET Core |
| **Buổi thực hành** | Buổi 3 – EF Core, Data Seeding và quản lý Khách hàng |

---

<p align="center">
  <b>🛒 MINISUPERMARKET SYSTEM</b><br>
  <i>Ứng dụng .NET Core • Entity Framework Core • SQL Server</i>
</p>
