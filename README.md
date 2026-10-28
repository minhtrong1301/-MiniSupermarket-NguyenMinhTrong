# 🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)

**Môn học:** Lập trình Ứng dụng .NET Core (Mã môn: 229162)

**Buổi thực hành:** Buổi 5 - ADO.NET nâng cao, Stored Procedure và giao dịch POS Checkout

---

## 🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)

Dự án tiếp tục phát triển theo mô hình Client - Server, sử dụng ASP.NET Core Web API kết hợp với Windows Forms. Các chức năng đăng nhập JWT, phân quyền và quản lý tài khoản của Buổi 4 được giữ lại. Buổi 5 tập trung vào ADO.NET nâng cao, Stored Procedure và Transaction trong nghiệp vụ thanh toán POS Checkout.

**MiniSupermarket.API (Backend):** Tiếp nhận yêu cầu thanh toán, kiểm tra dữ liệu đầu vào và xử lý nghiệp vụ checkout. Sử dụng ADO.NET để kết nối SQL Server, thực thi câu lệnh hoặc Stored Procedure và quản lý giao dịch khi được triển khai.

**MiniSupermarket.WinForms (Frontend Client):** Cung cấp giao diện bán hàng POS, hỗ trợ quét mã vạch, quản lý giỏ hàng, tra cứu khách hàng, nhập tiền thanh toán và gửi yêu cầu đến API thông qua `HttpClient`.

**SQL Server:** Lưu trữ thông tin sản phẩm, khách hàng, đơn hàng và chi tiết đơn hàng. Các thao tác lưu đơn hàng và cập nhật tồn kho cần đảm bảo tính nhất quán dữ liệu.

**Luồng hoạt động của hệ thống:**

```text
┌────────────────────────────────┐
│     MiniSupermarket.WinForms   │
│            (Client)             │
├────────────────────────────────┤
│ FormPOS                        │
│ Quét mã vạch / Giỏ hàng        │
│ Thông tin khách hàng            │
│ ApiClientService               │
│ SessionManager / JWT           │
└───────────────┬────────────────┘
                │
                │ HTTP Request / JSON
                │ Authorization: Bearer <JWT>
                ▼
┌────────────────────────────────┐
│       MiniSupermarket.API      │
├────────────────────────────────┤
│ OrdersController / Checkout    │
│ Kiểm tra dữ liệu thanh toán     │
│ ADO.NET / SqlCommand           │
│ Stored Procedure               │
│ SQL Transaction                │
└───────────────┬────────────────┘
                │
                │ SqlConnection / SqlCommand
                ▼
┌────────────────────────────────┐
│           SQL Server           │
├────────────────────────────────┤
│ Products / Customers            │
│ Orders / OrderDetails           │
│ Xử lý thanh toán POS            │
│ Cập nhật số lượng tồn kho       │
└────────────────────────────────┘
```

---

## 🛠️ 2. Công nghệ Sử dụng

- **Ngôn ngữ:** C#.
- **Nền tảng:** .NET 8.
- **Backend:** ASP.NET Core Web API.
- **Frontend:** Windows Forms.
- **Cơ sở dữ liệu:** Microsoft SQL Server.
- **ADO.NET:** `SqlConnection`, `SqlCommand`, `SqlParameter`, `SqlDataReader`.
- **Stored Procedure:** Đóng gói và thực thi các thao tác SQL.
- **Transaction:** `SqlTransaction`, Commit và Rollback.
- **Entity Framework Core:** Tiếp tục hỗ trợ các chức năng dữ liệu hiện có.
- **Xác thực:** JWT Bearer Authentication.
- **Giao tiếp API:** `HttpClient`.
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
│   │   ├── ProductsController.cs
│   │   ├── CustomersController.cs
│   │   └── OrdersController.cs
│   │
│   ├── DTOs/
│   │   └── CheckoutRequestDto.cs
│   │
│   ├── Models/
│   │   ├── Product.cs
│   │   ├── Customer.cs
│   │   ├── Order.cs
│   │   └── OrderDetail.cs
│   │
│   ├── Data/
│   │   └── SupermarketDbContext.cs
│   │
│   ├── Program.cs
│   └── appsettings.json
│
└── MiniSupermarket.WinForms/
    ├── FormPOS.cs
    ├── FormPOS.Designer.cs
    ├── ApiClientService.cs
    ├── SessionManager.cs
    └── Program.cs
```

*Lưu ý: Cây thư mục minh họa các thành phần liên quan; giữ nguyên cấu trúc thực tế của Solution và chỉ bổ sung những tệp cần thiết.*

---

## 🧾 4. Nghiệp vụ POS Checkout

### 4.1. Quy trình thanh toán

1. Nhập hoặc quét mã vạch sản phẩm.
2. Thêm sản phẩm vào giỏ hàng và nhập số lượng.
3. Tra cứu thông tin khách hàng nếu cần.
4. Tính tổng tiền và nhập số tiền khách thanh toán.
5. Gửi yêu cầu checkout từ WinForms đến Web API.
6. API kiểm tra dữ liệu và thực hiện các thao tác lưu đơn hàng.
7. Trả kết quả thanh toán về giao diện POS.

### 4.2. ADO.NET và Stored Procedure

- `SqlConnection`: Kết nối đến SQL Server.
- `SqlCommand`: Thực thi câu lệnh SQL hoặc Stored Procedure.
- `SqlParameter`: Truyền tham số an toàn.
- `SqlTransaction`: Quản lý giao dịch cơ sở dữ liệu.
- `Commit()`: Xác nhận các thao tác khi giao dịch thành công.
- `Rollback()`: Hoàn tác các thao tác khi giao dịch thất bại.

### 4.3. Đảm bảo tính toàn vẹn dữ liệu

Trong quá trình checkout, việc tạo đơn hàng, lưu chi tiết đơn hàng và cập nhật tồn kho cần được xử lý nhất quán. Nếu có lỗi giữa chừng, Transaction cần hoàn tác các thao tác thuộc cùng giao dịch để tránh dữ liệu không đồng bộ.

---

## 🔌 5. Các API liên quan

| Phương thức | Endpoint tham khảo | Chức năng |
|---|---|---|
| GET | `/api/Products` | Lấy danh sách sản phẩm |
| GET | `/api/Products/barcode/{barcode}` | Tìm sản phẩm theo mã vạch |
| GET | `/api/Customers/phone/{phone}` | Tìm khách hàng theo số điện thoại |
| POST | `/api/Orders/checkout` | Xử lý thanh toán POS |

*Các endpoint trên dựa theo luồng nghiệp vụ đã trao đổi. Cần đối chiếu route trong mã nguồn để bảo đảm chính xác với phiên bản dự án hiện tại.*

---

## 🚀 6. Hướng dẫn chạy dự án

### 6.1. Chuẩn bị

- Cài đặt .NET SDK phù hợp.
- Khởi động SQL Server.
- Kiểm tra chuỗi kết nối trong `appsettings.json`.
- Đảm bảo cơ sở dữ liệu đã được tạo và có dữ liệu cần thiết.

### 6.2. Chạy Backend

1. Mở Solution bằng Visual Studio.
2. Chọn `MiniSupermarket.API` làm Startup Project.
3. Kiểm tra cấu hình kết nối cơ sở dữ liệu.
4. Chạy ứng dụng và mở Swagger để kiểm tra API.

### 6.3. Chạy Frontend

1. Chọn `MiniSupermarket.WinForms` để chạy.
2. Đảm bảo Web API đang hoạt động.
3. Kiểm tra địa chỉ API trong `ApiClientService.cs`.
4. Đăng nhập và mở màn hình POS.
5. Thực hiện thử nghiệm quy trình thanh toán.

---

## 🧪 7. Kiểm thử chức năng

| STT | Chức năng | Kết quả mong đợi |
|---|---|---|
| 1 | Tìm sản phẩm bằng mã vạch | Hiển thị đúng sản phẩm |
| 2 | Thêm sản phẩm vào giỏ | Cập nhật số lượng và thành tiền |
| 3 | Nhập số lượng vượt tồn kho | Không cho phép thanh toán không hợp lệ |
| 4 | Tiền khách đưa không đủ | Hiển thị thông báo phù hợp |
| 5 | Thanh toán hợp lệ | Tạo đơn hàng thành công |
| 6 | Có lỗi khi lưu đơn hàng | Rollback giao dịch nếu được cấu hình cùng Transaction |
| 7 | Kiểm tra tồn kho sau thanh toán | Số lượng tồn kho được cập nhật chính xác |
| 8 | Gọi API cần xác thực | Kiểm tra quyền truy cập bằng JWT |

### Kiểm tra dữ liệu trong SQL Server

- [ ] Đơn hàng được lưu đúng.
- [ ] Chi tiết đơn hàng khớp với giỏ hàng.
- [ ] Tổng tiền được tính chính xác.
- [ ] Số lượng tồn kho được cập nhật đúng.
- [ ] Dữ liệu không bị lưu dở dang khi giao dịch thất bại.

---

## 📌 8. Kết quả thực hành Buổi 5

- [ ] Tìm hiểu các đối tượng ADO.NET cơ bản và nâng cao.
- [ ] Hiểu cách sử dụng `SqlConnection`, `SqlCommand` và `SqlParameter`.
- [ ] Tìm hiểu Stored Procedure trong SQL Server.
- [ ] Nắm được cách sử dụng Transaction, Commit và Rollback.
- [ ] Áp dụng kiến thức vào nghiệp vụ POS Checkout.
- [ ] Kiểm tra kết quả thanh toán và dữ liệu tồn kho.
- [ ] Duy trì các chức năng đăng nhập JWT và phân quyền từ Buổi 4.

*Các mục trên là checklist mục tiêu; chỉ đánh dấu hoàn thành sau khi đã kiểm tra trên dự án thực tế.*

---

## 👨‍💻 9. Thông tin Sinh viên

- **Họ và tên:** Nguyễn Minh Trọng
- **MSSV:** 2124110253
- **Lớp:** CCQ2411D
- **Môn học:** Lập trình Ứng dụng .NET Core
- **Đề tài:** Hệ thống quản lý siêu thị mini (MiniSupermarket System)
- **Buổi thực hành:** Buổi 5 - ADO.NET nâng cao, Stored Procedure và Transaction POS Checkout
