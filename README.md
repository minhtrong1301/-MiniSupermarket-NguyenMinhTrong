🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

Môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)

Buổi thực hành: Buổi 3 - Kết nối CSDL SQL Server với Entity Framework Core, Data Seeding và quản lý Khách hàng (Customers)

🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)

Dự án tiếp tục được phát triển theo mô hình Client - Server, kết nối cơ sở dữ liệu SQL Server thông qua Entity Framework Core (EF Core) cùng cơ chế JWT Authentication để xác thực và phân quyền API.

MiniSupermarket.API (Backend): Dự án ASP.NET Core Web API xử lý xác thực JWT, kết nối SQL Server qua Entity Framework Core, thực hiện Data Seeding và cung cấp các RESTful API quản lý hệ thống.

MiniSupermarket.WinForms (Frontend Client): Ứng dụng Windows Forms sử dụng HttpClient gửi nhận dữ liệu JSON và đính kèm JWT Bearer Token trong Header.

Luồng hoạt động của hệ thống:

┌─────────────────────────────┐
│   MiniSupermarket.WinForms  │
│        (Client)             │
└──────────────┬──────────────┘
               │
               │ API Request (HTTP/JSON)
               │ Authorization: Bearer <JWT>
               ▼
┌─────────────────────────────┐
│     MiniSupermarket.API     │
│        (Backend)            │
├─────────────────────────────┤
│ JWT Authentication & Role   │
│ Controllers / API           │
│ Entity Framework Core (ORM) │
└──────────────┬──────────────┘
               │
               │ DbContext / Migrations
               ▼
┌─────────────────────────────┐
│      SQL Server Database    │
│    (MiniSupermarketDb)      │
└─────────────────────────────┘


🛠️ 2. Công nghệ Sử dụng

Ngôn ngữ: C# (.NET 8.0)

Backend: ASP.NET Core Web API

ORM & Database Access: Entity Framework Core 8.0 (Code-First Migration & Data Seeding)

Database: Microsoft SQL Server (SupermarketDbContext)

Authentication & Authorization: JWT Bearer Authentication, Role-based Authorization

Frontend: Windows Forms (.NET 8.0)

HTTP Client: HttpClient, System.Net.Http.Json

Kiểm thử API: Swagger UI

Quản lý phiên bản: Git & GitHub

📂 3. Cấu trúc Solution

MiniSupermarketSystem/
│
├── MiniSupermarket.API/                  # Dự án Web API (Backend)
│   ├── Controllers/
│   │   ├── AuthController.cs             # Đăng nhập và cấp JWT Token
│   │   ├── CategoriesController.cs       # CRUD Danh mục sản phẩm
│   │   └── CustomersController.cs        # CRUD Khách hàng (Customers)
│   │
│   ├── Data/
│   │   └── SupermarketDbContext.cs       # EF Core DbContext, Cấu hình Entity & Data Seeding
│   │
│   ├── Migrations/                       # Thư mục chứa các bản EF Core Migration
│   │
│   ├── Models/
│   │   ├── Category.cs                   # Model danh mục
│   │   ├── Customer.cs                   # Model khách hàng (CustomerId, CustomerName, PhoneNumber, Address, MembershipRank, RewardPoints)
│   │   └── User.cs                       # Model người dùng & tài khoản
│   │
│   ├── Services/
│   │   └── JwtService.cs                 # Service khởi tạo JWT Token
│   │
│   ├── Program.cs                        # Register DbContext, JWT & Dependency Injection
│   └── appsettings.json                  # Cấu hình ConnectionString & JWT Settings
│
└── MiniSupermarket.WinForms/             # Dự án Windows Forms (Frontend)
    ├── FormLogin.cs                      # Giao diện đăng nhập
    ├── FormCategoryManagement.cs         # Quản lý danh mục
    ├── FormCustomerManagement.cs         # Quản lý khách hàng
    └── ApiClientService.cs               # Service gọi API và quản lý JWT Token


🗄️ 4. Cơ sở dữ liệu & Data Seeding (Customers)

Hệ thống đã chuyển sang lưu trữ dữ liệu tập trung trên SQL Server. Entity Customer được cấu hình Data Seeding gồm 15 khách hàng mẫu sẵn có trong cơ sở dữ liệu:

Danh sách 15 Khách hàng Seeding mẫu:

Nguyễn Văn An - SĐT: 0912345678 - Hạng: Bạc - Điểm: 350

Trần Thị Bình - SĐT: 0987654321 - Hạng: Kim Cương - Điểm: 1200

Lê Hoàng Cường - SĐT: 0903112233 - Hạng: Chuẩn - Điểm: 50

Phạm Minh Dung - SĐT: 0938889900 - Hạng: Vàng - Điểm: 750

Hoàng Quốc Dung - SĐT: 0977123456 - Hạng: Chuẩn - Điểm: 0

Đỗ Thị Giang - SĐT: 0966554433 - Hạng: Chuẩn - Điểm: 150

Vũ Hải Đăng - SĐT: 0944118899 - Hạng: Bạc - Điểm: 520

Ngô Bích Hằng - SĐT: 0918273645 - Hạng: Kim Cương - Điểm: 2100

Bùi Anh Tuấn - SĐT: 0922334455 - Hạng: Vàng - Điểm: 890

Đặng Thu Thảo - SĐT: 0955667788 - Hạng: Bạc - Điểm: 410

Trịnh Quốc Bảo - SĐT: 0909090909 - Hạng: Chuẩn - Điểm: 30

Lý Mỹ Nhân - SĐT: 0933221100 - Hạng: Vàng - Điểm: 1050

Dương Văn Khoa - SĐT: 0978990011 - Hạng: Bạc - Điểm: 620

Mai Phương Thúy - SĐT: 0911223344 - Hạng: Kim Cương - Điểm: 1850

Cao Thái Sơn - SĐT: 0945678901 - Hạng: Chuẩn - Điểm: 95

⚙️ 5. Hướng dẫn Khởi tạo & Cập nhật Database (EF Core Migrations)

Khi làm mới database hoặc cập nhật Data Seeding trong SupermarketDbContext.cs, thực hiện các bước sau trong Package Manager Console (PMC):

# 1. Xóa CSDL cũ (nếu muốn reset sạch)
Drop-Database

# 2. Tạo bản Migration mới
Add-Migration InitialCreate

# 3. Cập nhật schema và nạp 15 dữ liệu Seeding vào SQL Server
Update-Database


🔐 6. Xử lý Quản lý Version với Git

Quy trình commit và đồng bộ code lên GitHub branch Buoi3:

# 1. Kiểm tra trạng thái thay đổi
git status

# 2. Thêm tất cả thay đổi vào Staging
git add .

# 3. Commit thay đổi
git commit -m "Update customer seed data to 15 records and reset migrations"

# 4. Push lên GitHub (Dùng --force nếu cần đè lại lịch sử Migration mới)
git push origin Buoi3 --force


🧪 7. Kiểm thử API bằng Swagger UI

Sau khi khởi chạy MiniSupermarket.API:

Đăng nhập: Gọi POST /api/auth/login với tài khoản admin (admin / 123456) để lấy JWT Token.

Xác thực: Bấm nút Authorize trên góc Swagger UI và dán Token vào dạng Bearer <JWT_TOKEN>.

Thao tác Khách hàng (CustomersController):

GET /api/customers: Lấy danh sách 15 khách hàng seeding.

GET /api/customers/{id}: Xem thông tin chi tiết một khách hàng.

POST /api/customers: Thêm mới khách hàng.

PUT /api/customers/{id}: Cập nhật thông tin khách hàng.

DELETE /api/customers/{id}: Xóa khách hàng.

📌 8. Kết quả Đạt được (Buổi 3)

Kết nối thành công ASP.NET Core Web API với cơ sở dữ liệu SQL Server thông qua Entity Framework Core.

Xây dựng Entity Customer và cấu hình Data Seeding đầy đủ 15 khách hàng đa dạng các hạng thành viên (Chuẩn, Bạc, Vàng, Kim Cương).

Quản lý sạch sẽ lịch sử Migration và cập nhật cơ sở dữ liệu nhất quán.

Xây dựng đầy đủ RESTful API hỗ trợ các thao tác CRUD Khách hàng kết hợp phân quyền JWT Authentication.

Đồng bộ và đẩy mã nguồn hoàn chỉnh lên Git / GitHub branch Buoi3.

👨‍💻 9. Tác giả

Họ tên sinh viên: Nguyễn Minh Trọng

Mã sinh viên: 2124110253

Lớp học phần: CCQ2411D
