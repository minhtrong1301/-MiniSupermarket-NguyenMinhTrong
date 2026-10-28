🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)
Môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)

Buổi thực hành: Buổi 5 - ADO.NET nâng cao, Stored Procedure và giao dịch POS Checkout
🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)
Dự án tiếp tục phát triển theo mô hình Client - Server, sử dụng ASP.NET Core Web API kết hợp với Windows Forms. Các chức năng JWT, phân quyền và quản lý tài khoản của Buổi 4 được giữ lại. Buổi 5 tập trung vào ADO.NET, Stored Procedure và transaction trong nghiệp vụ POS Checkout.

MiniSupermarket.API (Backend): Tiếp nhận yêu cầu thanh toán, kiểm tra dữ liệu đầu vào và thực hiện nghiệp vụ checkout. ADO.NET có thể được sử dụng với SqlConnection, SqlCommand, SqlParameter để gọi Stored Procedure và quản lý giao dịch SQL.

MiniSupermarket.WinForms (Frontend Client): Cung cấp giao diện POS để quét mã vạch, thêm sản phẩm vào giỏ, tra cứu khách hàng, nhập số tiền khách đưa và gửi yêu cầu thanh toán đến API. Các yêu cầu dùng HttpClient và JWT Bearer Token khi endpoint yêu cầu xác thực.

SQL Server: Lưu sản phẩm, tồn kho, đơn hàng và chi tiết đơn hàng. Các thao tác tạo đơn và cập nhật tồn kho cần được thực hiện nhất quán.

Luồng hoạt động dự kiến:
┌────────────────────────────────────┐
│       MiniSupermarket.WinForms     │
├────────────────────────────────────┤
│ FormPOS                            │
│ Quét mã vạch / Giỏ hàng             │
│ Thông tin khách hàng / Thanh toán   │
│ ApiClientService / SessionManager   │
└──────────────────┬─────────────────┘
                   │ HTTP Request / JSON
                   │ Authorization: Bearer <JWT>
                   ▼
┌────────────────────────────────────┐
│         MiniSupermarket.API        │
├────────────────────────────────────┤
│ OrdersController / Checkout        │
│ Kiểm tra dữ liệu yêu cầu            │
│ ADO.NET / SqlCommand                │
│ Gọi Stored Procedure                │
│ SQL Transaction                     │
└──────────────────┬─────────────────┘
                   │ SqlConnection / SqlCommand
                   ▼
┌────────────────────────────────────┐
│             SQL Server             │
├────────────────────────────────────┤
│ Products / Customers                │
│ Orders / OrderDetails               │
│ Stored Procedure xử lý checkout    │
│ Cập nhật tồn kho                   │
└────────────────────────────────────┘
Sơ đồ là luồng mục tiêu của Buổi 5. Tên controller, endpoint và Stored Procedure cần khớp với mã nguồn thực tế.
🛠️ 2. Công nghệ sử dụng
- Ngôn ngữ: C#.
- Nền tảng: .NET 8.0.
- Backend: ASP.NET Core Web API.
- ORM hiện có: Entity Framework Core 8, tiếp tục sử dụng cho các chức năng hiện tại.
- Truy cập dữ liệu Buổi 5: ADO.NET với SqlConnection, SqlCommand, SqlParameter và SqlTransaction khi phù hợp.
- Cơ sở dữ liệu: Microsoft SQL Server Express.
- Stored Procedure: Đóng gói các thao tác SQL cho nghiệp vụ checkout.
- Giao dịch dữ liệu: SQL Transaction để bảo đảm các thao tác liên quan thành công cùng nhau hoặc được rollback.
- Xác thực: JWT Bearer Authentication, kế thừa từ Buổi 4.
- Frontend: Windows Forms (.NET 8.0).
- Giao tiếp API: HttpClient, System.Net.Http.Json.
- Kiểm thử API: Swagger UI.
- Quản lý mã nguồn: Git và GitHub.
📂 3. Cấu trúc Solution
Cấu trúc dưới đây chỉ mô tả các thành phần liên quan. Giữ nguyên file hiện có; chỉ thêm file khi thực sự cần và sau khi đối chiếu mã nguồn.
MiniSupermarketSystem/
│
├── MiniSupermarket.API/
│   ├── Controllers/
│   │   ├── AuthController.cs
│   │   ├── CustomersController.cs
│   │   ├── ProductsController.cs
│   │   ├── OrdersController.cs
│   │   └── UsersController.cs
│   ├── DTOs/
│   │   └── CheckoutRequestDto.cs (nếu project tách DTO)
│   ├── Models/
│   │   ├── User.cs
│   │   ├── Customer.cs
│   │   ├── Product.cs
│   │   ├── Order.cs
│   │   └── OrderDetail.cs
│   ├── Services/ (nếu có service riêng)
│   ├── Migrations/
│   ├── SupermarketDbContext.cs
│   ├── Program.cs
│   └── appsettings.json
│
└── MiniSupermarket.WinForms/
    ├── FormPOS.cs
    ├── FormPOS.Designer.cs
    ├── ApiClientService.cs
    ├── SessionManager.cs
    └── Program.cs
Lưu ý: Không cần tạo lại toàn bộ file hoặc xóa/đổi tên file đang được Buổi 4 sử dụng.
🧾 4. Nghiệp vụ POS Checkout
4.1. Quy trình bán hàng
1. Nhân viên đăng nhập vào hệ thống.
2. Quét mã vạch hoặc tìm sản phẩm để thêm vào giỏ hàng.
3. Kiểm tra tên sản phẩm, đơn giá, số lượng và thành tiền.
4. Tra cứu khách hàng bằng số điện thoại nếu cần.
5. Nhập số tiền khách đưa.
6. Gửi yêu cầu checkout từ WinForms đến API.
7. API kiểm tra dữ liệu và thực hiện lưu đơn hàng, chi tiết đơn hàng, cập nhật tồn kho.
8. Trả kết quả về WinForms để hiển thị thông báo và cập nhật giao diện.
4.2. Nguyên tắc dữ liệu
- API không nên tin tưởng hoàn toàn giá và tổng tiền do client gửi lên; cần kiểm tra lại thông tin sản phẩm từ database.
- Số lượng mua phải lớn hơn 0.
- Kiểm tra tồn kho trước khi trừ hàng.
- Dùng tham số SQL (SqlParameter) thay vì nối chuỗi trực tiếp để hạn chế SQL Injection.
- Tạo đơn hàng, thêm chi tiết và trừ tồn kho nên nằm trong cùng một giao dịch.
- Nếu một bước thất bại, rollback để tránh đơn hàng và tồn kho ở trạng thái không nhất quán.
- Kiểm tra khả năng gửi lặp yêu cầu thanh toán để hạn chế tạo đơn hàng trùng.
4.3. Stored Procedure
Stored Procedure đóng gói các câu lệnh SQL cho một nghiệp vụ cụ thể. Với Buổi 5, có thể xây dựng Stored Procedure cho checkout, nhưng tên procedure, tham số và cấu trúc bảng phải được xác định dựa trên database thực tế.

Trước khi triển khai cần xác minh:
- Tên bảng và cột thực tế của Products, Orders, OrderDetails.
- Cách lưu giá, số lượng, khách hàng và nhân viên thu ngân.
- Stored Procedure đã tồn tại hay chưa.
- Transaction được quản lý trong Stored Procedure hay trong C#; cần chọn cách nhất quán, tránh quản lý trùng không cần thiết.
4.4. Giao dịch SQL Transaction
Giao dịch giúp bảo đảm tính toàn vẹn dữ liệu. Luồng tổng quát:
BEGIN TRANSACTION
    Kiểm tra sản phẩm và tồn kho
    Tạo đơn hàng
    Lưu chi tiết đơn hàng
    Trừ tồn kho
COMMIT nếu tất cả thành công
ROLLBACK nếu có lỗi
Nếu dùng SqlTransaction trong C#, các câu lệnh liên quan cần dùng cùng SqlConnection và gắn với transaction đó. Nếu Stored Procedure tự quản lý transaction, cần xác định rõ cách xử lý lỗi và rollback ở phía SQL.
🔌 5. API và tích hợp WinForms
Các endpoint sau là những endpoint cần kiểm tra trong project; không tự ý đổi route đang được FormPOS.cs sử dụng.
Phương thức	Endpoint tham khảo	Chức năng
GET	/api/Products	Lấy danh sách sản phẩm
GET	/api/Products/barcode/{barcode}	Tra cứu sản phẩm bằng mã vạch, nếu đã triển khai
GET	/api/Customers/phone/{phone}	Tra cứu khách hàng bằng số điện thoại, nếu đã triển khai
POST	/api/Orders/checkout	Gửi yêu cầu thanh toán, nếu route hiện tại dùng endpoint này


FormPOS sử dụng ApiClientService để gọi API. Cần giữ nguyên cấu trúc request/response và route đang được backend triển khai; nếu endpoint thực tế khác bảng tham khảo trên, README phải cập nhật theo mã nguồn.

Thông tin thường có trong yêu cầu checkout:
- Tên hoặc mã nhân viên thu ngân.
- Số điện thoại khách hàng (có thể để trống nếu cho phép khách vãng lai).
- Số tiền khách đưa.
- Danh sách sản phẩm gồm ProductId, Quantity và UnitPrice nếu DTO hiện tại đang sử dụng các trường này.
Các trường bắt buộc và cách tính tổng tiền phải khớp với DTO/controller hiện tại. Không tạo DTO hoặc đổi tên thuộc tính nếu chưa kiểm tra code thực tế.
⚙️ 6. Hướng dẫn khởi chạy dự án
Bước 1. Chuẩn bị môi trường
- .NET 8 SDK.
- Visual Studio hoặc Visual Studio Code.
- SQL Server Express và SSMS nếu cần quản lý cơ sở dữ liệu.
- Các gói NuGet đã được khai báo trong project.
Bước 2. Kiểm tra cấu hình database
Mở MiniSupermarket.API/appsettings.json, kiểm tra connection string và cấu hình JWT. Không đưa mật khẩu thật hoặc khóa bí mật lên GitHub.
Bước 3. Kiểm tra database và migration
Tại thư mục MiniSupermarket.API, chạy:
dotnet ef migrations list
Chỉ chạy dotnet ef database update khi đã xác minh migration và database đích. Không xóa database hoặc tạo lại migration khởi tạo khi không có yêu cầu rõ ràng.
Bước 4. Kiểm tra Stored Procedure
Trong SQL Server Management Studio, xác minh Stored Procedure checkout đã tồn tại và tham số khớp với cách gọi trong code. Nếu chưa có, hãy thiết kế dựa trên schema thực tế trước khi tạo.
Bước 5. Khởi chạy API
dotnet run
Chạy tại thư mục MiniSupermarket.API, kiểm tra URL thực tế trong Terminal và mở Swagger nếu đã cấu hình.
Bước 6. Khởi chạy WinForms
Mở solution trong Visual Studio, chọn MiniSupermarket.WinForms làm Startup Project và chạy. Đăng nhập bằng tài khoản hợp lệ đã được thiết lập từ Buổi 4.
🧪 7. Kiểm thử Buổi 5
Kiểm thử bằng dữ liệu thử nghiệm và đối chiếu phản hồi API với dữ liệu SQL Server.
STT	Trường hợp kiểm thử	Kết quả mong đợi
1	Quét mã vạch hợp lệ	Sản phẩm được tìm thấy và có thể thêm vào giỏ
2	Quét mã vạch không tồn tại	Hiển thị thông báo phù hợp
3	Thêm sản phẩm với số lượng hợp lệ	Giỏ hàng hiển thị số lượng và thành tiền đúng
4	Gửi số lượng bằng 0 hoặc âm	API từ chối dữ liệu không hợp lệ
5	Mua số lượng vượt tồn kho	Không hoàn tất đơn hàng và không trừ tồn kho
6	Tiền khách đưa không đủ	Từ chối thanh toán nếu nghiệp vụ yêu cầu đủ tiền
7	Checkout hợp lệ	Đơn hàng, chi tiết được lưu và tồn kho được cập nhật
8	Lỗi phát sinh giữa checkout	Transaction rollback, dữ liệu không ở trạng thái dở dang
9	Gọi endpoint được bảo vệ khi không có token	API từ chối yêu cầu
10	Tải lại dữ liệu sau checkout	Đơn hàng và tồn kho phản ánh đúng kết quả


7.1. Kiểm tra kết quả trong SQL Server
Sau mỗi lần checkout, đối chiếu:
- Đơn hàng mới trong bảng Orders.
- Các dòng tương ứng trong OrderDetails.
- Số lượng tồn kho của các sản phẩm liên quan.
- Tổng tiền đơn hàng và các giá trị chi tiết.
Tên bảng, tên cột và điều kiện truy vấn cần điều chỉnh theo schema thực tế.
7.2. Kiểm tra an toàn dữ liệu
- Không nối chuỗi đầu vào người dùng trực tiếp vào SQL.
- Dùng SqlParameter cho dữ liệu truyền vào câu lệnh hoặc Stored Procedure.
- Đảm bảo rollback khi checkout thất bại.
- Không làm mất các chức năng JWT và phân quyền đã hoàn thành ở Buổi 4.
📌 8. Kết quả và mục tiêu Buổi 5
Các mục tiêu của Buổi 5 gồm:
- Tiếp tục sử dụng kiến trúc Client - Server của project.
- Giữ lại xác thực JWT và phân quyền từ Buổi 4.
- Tìm hiểu và áp dụng ADO.NET trong xử lý dữ liệu phù hợp.
- Sử dụng SqlConnection, SqlCommand và SqlParameter để làm việc với SQL Server.
- Tìm hiểu cách gọi Stored Procedure từ C#.
- Áp dụng SQL Transaction để bảo đảm tính nhất quán cho nghiệp vụ checkout.
- Kiểm tra việc tạo đơn hàng, lưu chi tiết và cập nhật tồn kho.
- Kiểm thử các tình huống thành công, dữ liệu không hợp lệ và lỗi giữa giao dịch.
Đây là mục tiêu và tiêu chí kiểm thử. Chỉ ghi chức năng là hoàn thành sau khi đã triển khai và kiểm thử thành công trong project thực tế.

🌿 9. Quản lý phiên bản với Git
Buổi 5 nên được phát triển trên nhánh riêng, kế thừa mã nguồn Buổi 4. Trước khi thao tác, kiểm tra trạng thái và nhánh hiện tại:
git status
git branch --show-current
git branch -a
Nếu các chỉnh sửa Buổi 4 vẫn chưa commit, cần giữ lại chúng và xác định đúng nhánh cơ sở trước khi tạo nhánh Buổi 5. Không dùng git reset --hard, git restore . hoặc lệnh xóa thay đổi khi chưa sao lưu.

Sau khi đã tạo hoặc chuyển sang nhánh Buổi 5, kiểm tra các file thay đổi:
git status
git diff
Chỉ stage các file liên quan và đã kiểm tra:
git add <duong-dan-file>
git commit -m "Hoan thanh buoi 5 ADO.NET va POS Checkout"
git push -u origin Buoi5
Chỉ chạy lệnh commit/push sau khi đã xác minh tên nhánh chính xác, các thay đổi đã được lưu và không có thông tin nhạy cảm. Nếu nhánh trên remote có tên khác, thay Buoi5 bằng tên nhánh thực tế.

👨‍💻 10. Thông tin sinh viên
- Họ tên sinh viên: Nguyễn Minh Trọng
- Mã sinh viên: 2124110253
- Lớp học phần: CCQ2411D
- Môn học: Lập trình Ứng dụng .NET Core
- Buổi thực hành: Buổi 5
