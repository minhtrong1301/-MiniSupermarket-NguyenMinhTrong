# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

**Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)

**Buổi thực hành:** Buổi 6 – Quản lý sản phẩm, tìm kiếm và phân trang dữ liệu

---

## 🏗️ 1. Mô hình kiến trúc hệ thống (Client - Server)

Dự án MiniSupermarket System tiếp tục được phát triển theo mô hình Client - Server, sử dụng ASP.NET Core Web API kết hợp với Windows Forms. Hệ thống sử dụng Entity Framework Core để thao tác với SQL Server và `HttpClient` để trao đổi dữ liệu giữa giao diện WinForms và Backend API.

Trong Buổi 6, nội dung tập trung vào việc phát triển chức năng quản lý sản phẩm, kết hợp truy vấn LINQ, tìm kiếm dữ liệu, phân trang và hiển thị thông tin sản phẩm trên giao diện Windows Forms.

**MiniSupermarket.API (Backend):** Xử lý các yêu cầu lấy danh sách sản phẩm, tìm kiếm, truy vấn theo mã vạch, thêm, cập nhật và xóa sản phẩm. Entity Framework Core được sử dụng để truy xuất dữ liệu từ SQL Server.

**MiniSupermarket.WinForms (Frontend Client):** Cung cấp giao diện quản lý sản phẩm thông qua `FormProductManagement`, hiển thị dữ liệu bằng `DataGridView`, hỗ trợ nhập thông tin, tìm kiếm, chuyển trang và thực hiện các thao tác CRUD thông qua API.

**SQL Server:** Lưu trữ dữ liệu sản phẩm và danh mục sản phẩm cùng các thông tin liên quan.

### Luồng hoạt động của hệ thống

```text
┌──────────────────────────────────┐
│     MiniSupermarket.WinForms     │
│             Client               │
├──────────────────────────────────┤
│ FormMainShell                    │
│ FormProductManagement            │
│ DataGridView                     │
│ TextBox / ComboBox               │
│ ApiClientService                 │
│ SessionManager                   │
└────────────────┬─────────────────┘
                 │
                 │ HTTP Request / JSON
                 │ Authorization: Bearer <JWT>
                 ▼
┌──────────────────────────────────┐
│        MiniSupermarket.API       │
├──────────────────────────────────┤
│ ProductsController               │
│ Entity Framework Core            │
│ LINQ / Include / Skip / Take      │
│ Tìm kiếm và phân trang           │
│ CRUD sản phẩm                    │
└────────────────┬─────────────────┘
                 │
                 │ DbContext / SQL Queries
                 ▼
┌──────────────────────────────────┐
│            SQL Server            │
├──────────────────────────────────┤
│ Products                         │
│ Categories                       │
│ Users                            │
│ Customers                        │
│ Orders / OrderDetails             │
└──────────────────────────────────┘
```

---

## 🛠️ 2. Công nghệ sử dụng

- **Ngôn ngữ lập trình:** C#.
- **Nền tảng:** .NET 8.0.
- **Backend:** ASP.NET Core Web API.
- **Frontend:** Windows Forms (.NET 8.0).
- **ORM:** Entity Framework Core 8.
- **Cơ sở dữ liệu:** Microsoft SQL Server Express.
- **Truy vấn dữ liệu:** LINQ.
- **Phân trang:** `Skip()` và `Take()`.
- **Truy vấn dữ liệu liên quan:** `Include()`.
- **Giao tiếp API:** `HttpClient`, JSON.
- **Xác thực:** JWT Bearer Authentication theo cấu hình hiện có của hệ thống.
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
│   │   ├── UsersController.cs
│   │   ├── CustomersController.cs
│   │   ├── ProductsController.cs
│   │   └── OrdersController.cs
│   │
│   ├── Models/
│   │   ├── User.cs
│   │   ├── Customer.cs
│   │   ├── Product.cs
│   │   └── Category.cs
│   │
│   ├── DTOs/
│   ├── Services/
│   ├── Migrations/
│   ├── SupermarketDbContext.cs
│   ├── Program.cs
│   └── appsettings.json
│
└── MiniSupermarket.WinForms/
    ├── FormLogin.cs
    ├── FormMainShell.cs
    ├── FormUserManagement.cs
    ├── FormCustomerManagement.cs
    ├── FormProductManagement.cs
    ├── FormProductManagement.Designer.cs
    ├── FormPOS.cs
    ├── ApiClientService.cs
    ├── SessionManager.cs
    └── Program.cs
```

*Lưu ý: Cấu trúc trên mô tả các thành phần liên quan đến dự án. Cần đối chiếu với Solution thực tế để xác nhận đầy đủ tên và vị trí các tệp.*

---

## 🗄️ 4. Quản lý sản phẩm và truy vấn dữ liệu

### 4.1. Thông tin sản phẩm

Chức năng quản lý sản phẩm sử dụng model `Product` để biểu diễn dữ liệu sản phẩm được lưu trữ trong SQL Server.

Thông tin sản phẩm có thể bao gồm:

| Thuộc tính | Ý nghĩa |
|---|---|
| `ProductId` | Mã định danh sản phẩm |
| `ProductName` | Tên sản phẩm |
| `CategoryId` | Mã danh mục sản phẩm |
| `Barcode` | Mã vạch sản phẩm |
| `Price` | Giá sản phẩm |
| `StockQuantity` | Số lượng tồn kho |

*Lưu ý: Các tên thuộc tính trong bảng trên mang tính mô tả. Cần đối chiếu với `Product.cs` hiện tại để xác nhận tên thuộc tính thực tế.*

### 4.2. Truy vấn sản phẩm bằng Entity Framework Core

`ProductsController` sử dụng Entity Framework Core để truy vấn dữ liệu từ `SupermarketDbContext`.

Thay vì truy vấn trực tiếp bằng câu lệnh SQL trong từng chức năng, hệ thống sử dụng LINQ để xây dựng các truy vấn trên tập dữ liệu sản phẩm.

Các nội dung được áp dụng gồm:

- Truy vấn danh sách sản phẩm.
- Truy vấn sản phẩm theo mã định danh.
- Truy vấn sản phẩm theo mã vạch.
- Kết hợp dữ liệu sản phẩm với danh mục liên quan bằng `Include()`.
- Tìm kiếm và phân trang danh sách sản phẩm.

Ví dụ truy vấn sản phẩm kèm danh mục:

```csharp
var products = await _context.Products
    .Include(p => p.Category)
    .ToListAsync();
```

Trong đó:

- `Include(p => p.Category)` giúp truy xuất thêm thông tin danh mục liên quan.
- `ToListAsync()` thực thi truy vấn bất đồng bộ và trả về danh sách kết quả.

Đoạn code trên là ví dụ minh họa cho kỹ thuật truy vấn; cần bảo đảm tên navigation property phù hợp với model thực tế của dự án.

### 4.3. Phân trang dữ liệu sản phẩm

Khi số lượng sản phẩm tăng lên, việc tải toàn bộ dữ liệu cùng lúc có thể khiến giao diện khó theo dõi và làm tăng lượng dữ liệu trao đổi giữa Client và Server.

Chức năng phân trang cho phép chia danh sách sản phẩm thành nhiều trang. Mỗi yêu cầu chỉ lấy dữ liệu thuộc trang được chọn.

Các tham số phân trang gồm:

- `pageNumber`: Số trang cần hiển thị.
- `pageSize`: Số sản phẩm trên mỗi trang.
- `keyword`: Từ khóa tìm kiếm nếu có.

Công thức xác định số bản ghi cần bỏ qua:

\[
\text{SkipCount}=(\text{pageNumber}-1)\times\text{pageSize}
\]

Ví dụ, khi chọn trang 2 và mỗi trang có 5 sản phẩm:

\[
\text{SkipCount}=(2-1)\times5=5
\]

Hệ thống bỏ qua 5 sản phẩm đầu tiên và lấy các sản phẩm tiếp theo theo thứ tự truy vấn.

Ví dụ triển khai bằng LINQ:

```csharp
var products = await query
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize)
    .ToListAsync();
```

Trong đó:

- `Skip()` bỏ qua số bản ghi đã xác định.
- `Take()` giới hạn số bản ghi trả về.
- `ToListAsync()` thực thi truy vấn bất đồng bộ.

Phân trang giúp giới hạn lượng dữ liệu trả về và hỗ trợ người dùng theo dõi danh sách sản phẩm thuận tiện hơn.

### 4.4. Tìm kiếm sản phẩm

Chức năng tìm kiếm cho phép người dùng nhập từ khóa để thu hẹp danh sách sản phẩm cần xem.

Khi người dùng thực hiện tìm kiếm:

1. WinForms nhận từ khóa từ ô nhập liệu.
2. Ứng dụng gửi từ khóa đến API.
3. API xây dựng truy vấn LINQ dựa trên điều kiện tìm kiếm.
4. API kết hợp điều kiện tìm kiếm với phân trang.
5. Kết quả được trả về dưới dạng JSON và hiển thị trên `DataGridView`.

Khi thay đổi từ khóa, trang hiện tại cần được đưa về trang đầu tiên để tránh trường hợp số trang cũ không còn hợp lệ với kết quả tìm kiếm mới.

### 4.5. Truy vấn sản phẩm theo mã vạch

Hệ thống có endpoint truy vấn sản phẩm theo mã vạch:

`GET /api/Products/barcode/{barcode}`

Chức năng này hỗ trợ tìm kiếm sản phẩm bằng mã vạch, có thể được sử dụng trong các nghiệp vụ liên quan đến quản lý hàng hóa và bán hàng.

Kết quả trả về phụ thuộc vào dữ liệu sản phẩm được lưu trong SQL Server và cách xử lý trong `ProductsController`.

---

## 🔌 5. Xây dựng API quản lý sản phẩm

### 5.1. Danh sách API

Các endpoint dưới đây mô tả những chức năng được đề cập trong quá trình phát triển `ProductsController`. Endpoint phân trang cần được đối chiếu với route thực tế trong mã nguồn.

| Phương thức | Endpoint | Chức năng |
|---|---|---|
| GET | `/api/Products` | Lấy danh sách sản phẩm |
| GET | `/api/Products/{id}` | Lấy sản phẩm theo ID |
| GET | `/api/Products/barcode/{barcode}` | Tìm sản phẩm theo mã vạch |
| POST | `/api/Products` | Thêm sản phẩm |
| PUT | `/api/Products/{id}` | Cập nhật sản phẩm |
| DELETE | `/api/Products/{id}` | Xóa sản phẩm |
| GET | Endpoint phân trang theo route thực tế | Lấy danh sách sản phẩm theo trang và từ khóa |

### 5.2. Thêm sản phẩm

API `POST /api/Products` tiếp nhận dữ liệu sản phẩm từ WinForms.

Quy trình thực hiện:

1. Người dùng nhập thông tin sản phẩm trên giao diện.
2. WinForms gửi yêu cầu POST đến API.
3. API kiểm tra dữ liệu theo các quy tắc đang được triển khai.
4. Entity Framework Core thực hiện thao tác lưu dữ liệu.
5. API trả về kết quả để giao diện hiển thị thông báo.

### 5.3. Cập nhật sản phẩm

API `PUT /api/Products/{id}` được sử dụng để cập nhật thông tin sản phẩm theo ID.

Nếu API xử lý thành công, giao diện WinForms tải lại danh sách để hiển thị dữ liệu mới nhất.

### 5.4. Xóa sản phẩm

API `DELETE /api/Products/{id}` tiếp nhận ID của sản phẩm cần xóa.

Giao diện cần xác định đúng sản phẩm được chọn trước khi gửi yêu cầu. Sau khi thao tác thành công, danh sách được tải lại để phản ánh dữ liệu mới.

---

## 🖥️ 6. Xây dựng giao diện quản lý sản phẩm trên WinForms

### 6.1. FormProductManagement

`FormProductManagement` là giao diện quản lý sản phẩm trong ứng dụng Windows Forms.

Giao diện sử dụng các thành phần cơ bản:

- `DataGridView`: Hiển thị danh sách sản phẩm.
- `TextBox`: Nhập thông tin sản phẩm và từ khóa tìm kiếm.
- `ComboBox`: Chọn danh mục hoặc giá trị tương ứng với các trường được thiết kế.
- Các nút chức năng: Thêm, cập nhật, xóa, tìm kiếm và chuyển trang.

### 6.2. Kết nối API bằng ApiClientService

Ứng dụng WinForms sử dụng `ApiClientService` để gửi yêu cầu đến Backend API.

Đối với các endpoint cần xác thực, dịch vụ sử dụng JWT Bearer Token theo cơ chế xác thực hiện có của dự án.

Quy trình lấy dữ liệu:

1. Gửi yêu cầu HTTP đến API.
2. Nhận dữ liệu JSON từ Server.
3. Chuyển đổi dữ liệu JSON thành đối tượng C#.
4. Gán danh sách đối tượng vào `DataGridView`.
5. Cập nhật thông tin phân trang và trạng thái các nút điều hướng.

### 6.3. Điều hướng giữa các trang

Giao diện quản lý sản phẩm hỗ trợ chuyển trang bằng các nút trang trước và trang tiếp theo.

- Nút trang trước bị vô hiệu hóa khi đang ở trang đầu.
- Nút trang tiếp theo bị vô hiệu hóa khi đang ở trang cuối.
- Khi tìm kiếm, hệ thống quay về trang đầu.
- Sau khi thêm, cập nhật hoặc xóa sản phẩm, danh sách cần được tải lại.

Cách tổ chức này giúp đồng bộ dữ liệu hiển thị trên WinForms với dữ liệu được lưu trữ trên Server.

---

## ⚙️ 7. Hướng dẫn khởi chạy dự án

### Bước 1. Chuẩn bị môi trường

Kiểm tra các thành phần sau:

- .NET 8 SDK.
- Visual Studio hoặc Visual Studio Code.
- SQL Server Express.
- SQL Server Management Studio (SSMS), nếu cần.
- Các gói NuGet cần thiết của dự án.

### Bước 2. Kiểm tra cấu hình kết nối

Mở `appsettings.json` trong dự án `MiniSupermarket.API`.

Kiểm tra Connection String để bảo đảm API kết nối đúng SQL Server instance và database hiện đang sử dụng.

Không đưa mật khẩu hoặc khóa bí mật thật lên GitHub.

### Bước 3. Kiểm tra và cập nhật Database

Mở Terminal tại thư mục `MiniSupermarket.API`:

```powershell
dotnet ef migrations list
```

Nếu database cần cập nhật và các migration hiện có phù hợp với mã nguồn, thực hiện:

```powershell
dotnet ef database update
```

Không tạo lại migration ban đầu hoặc xóa database hiện tại khi chưa kiểm tra trạng thái schema.

### Bước 4. Khởi chạy Backend API

Tại thư mục `MiniSupermarket.API`, chạy:

```powershell
dotnet run
```

Kiểm tra địa chỉ API được hiển thị trong Terminal. Nếu sử dụng HTTPS, cần bảo đảm WinForms đang gọi đúng URL và cổng đã cấu hình.

### Bước 5. Khởi chạy WinForms

Mở Solution trong Visual Studio.

Chọn `MiniSupermarket.WinForms` làm Startup Project và chạy ứng dụng.

Đăng nhập bằng tài khoản hợp lệ nếu hệ thống yêu cầu xác thực trước khi sử dụng chức năng quản lý sản phẩm.

---

## 🧪 8. Kiểm thử chức năng

### 8.1. Kiểm thử API

Sử dụng Swagger UI để kiểm tra các endpoint quản lý sản phẩm.

Các trường hợp kiểm thử:

- Lấy danh sách sản phẩm.
- Lấy sản phẩm theo ID.
- Tìm sản phẩm bằng mã vạch.
- Thêm sản phẩm mới.
- Cập nhật thông tin sản phẩm.
- Xóa sản phẩm.
- Kiểm tra kết quả tìm kiếm.
- Kiểm tra phân trang với các giá trị `pageNumber` và `pageSize` khác nhau.

### 8.2. Kiểm thử giao diện WinForms

Thực hiện kiểm tra trực tiếp trên `FormProductManagement`:

- Mở giao diện và kiểm tra danh sách sản phẩm.
- Chọn một sản phẩm trên `DataGridView`.
- Thực hiện tìm kiếm theo từ khóa.
- Chuyển sang trang tiếp theo và quay về trang trước.
- Thêm một sản phẩm hợp lệ.
- Cập nhật thông tin sản phẩm.
- Xóa sản phẩm sau khi xác nhận.
- Kiểm tra danh sách sau mỗi thao tác.
- Kiểm tra thông báo khi API gặp lỗi hoặc không trả về dữ liệu như mong đợi.

### 8.3. Kết quả kiểm thử

Kết quả kiểm thử cần được ghi nhận dựa trên quá trình chạy thực tế, bao gồm dữ liệu đầu vào, kết quả trả về và các lỗi đã xử lý.

Không kết luận tất cả chức năng hoạt động chính xác nếu chưa kiểm tra trực tiếp trên API và giao diện WinForms.

---

## 📌 9. Kết quả đạt được của Buổi 6

Qua quá trình phát triển và hoàn thiện chức năng quản lý sản phẩm, các nội dung đã được đề cập gồm:

- Tiếp tục phát triển chức năng quản lý sản phẩm trong hệ thống MiniSupermarket.
- Sử dụng ASP.NET Core Web API để cung cấp các endpoint thao tác với sản phẩm.
- Sử dụng Entity Framework Core và LINQ để truy vấn dữ liệu.
- Áp dụng `Include()` để truy xuất dữ liệu danh mục liên quan đến sản phẩm.
- Áp dụng `Skip()` và `Take()` để triển khai kỹ thuật phân trang.
- Bổ sung hoặc hoàn thiện chức năng tìm kiếm sản phẩm theo từ khóa.
- Sử dụng endpoint truy vấn sản phẩm theo mã vạch.
- Tích hợp dữ liệu API với giao diện `FormProductManagement`.
- Sử dụng `DataGridView` để hiển thị dữ liệu từ Backend.
- Thực hiện các thao tác CRUD sản phẩm thông qua API.
- Tiếp tục duy trì kiến trúc Client – Server và cơ chế giao tiếp JSON giữa WinForms và ASP.NET Core Web API.

Các kết quả trên cần được đối chiếu với mã nguồn và trạng thái chạy thực tế trước khi sử dụng làm báo cáo nghiệm thu cuối cùng.

---

## 📌 10. Quản lý mã nguồn với Git

Kiểm tra trạng thái repository:

```powershell
git status
```

Kiểm tra nhánh hiện tại:

```powershell
git branch --show-current
```

Thêm các file đã kiểm tra vào Staging:

```powershell
git add .
```

Commit thay đổi của Buổi 6:

```powershell
git commit -m "Hoan thien quan ly san pham phan trang"
```

Đồng bộ lên GitHub bằng nhánh đang sử dụng:

```powershell
git push origin <ten-nhanh>
```

Trước khi commit, cần kiểm tra danh sách file thay đổi để tránh đưa nhầm file cấu hình nhạy cảm hoặc các thay đổi không liên quan vào repository.

---

## 👨‍💻 11. Thông tin sinh viên

- **Họ tên sinh viên:** Nguyễn Minh Trọng
- **Mã sinh viên:** 2124110253
- **Lớp học phần:** CCQ2411D
- **Môn học:** Lập trình Ứng dụng .NET Core
- **Buổi thực hành:** Buổi 6
