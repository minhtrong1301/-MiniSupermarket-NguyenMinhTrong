
using Microsoft.Data.SqlClient;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Kết nối đến đúng database đang sử dụng
string connectionString =
    @"Server=.\SQLEXPRESS;Database=NguyenMinhTrong_MiniSupermarketDb;Trusted_Connection=True;TrustServerCertificate=True;";

using SqlConnection connection = new SqlConnection(connectionString);

try
{
    connection.Open();

    // Bắt đầu một giao dịch SQL
    using SqlTransaction transaction = connection.BeginTransaction();

    try
    {
        int productId = 1;
        int customerId = 1;
        int quantity = 2;

        decimal unitPrice = 180000m;
        decimal totalAmount = unitPrice * quantity;

        Console.WriteLine("=== THUC HANH GIAO DICH BAN HANG ===");
        Console.WriteLine("Da ket noi SQL Server.");
        Console.WriteLine("Da bat dau transaction.");

        // Bước 1: Trừ tồn kho nếu sản phẩm còn đủ số lượng
        string updateStockSql = @"
            UPDATE Products
            SET StockQuantity = StockQuantity - @Quantity
            WHERE ProductId = @ProductId
              AND StockQuantity >= @Quantity;";

        using (SqlCommand command =
            new SqlCommand(updateStockSql, connection, transaction))
        {
            command.Parameters.AddWithValue("@Quantity", quantity);
            command.Parameters.AddWithValue("@ProductId", productId);

            int affectedRows = command.ExecuteNonQuery();

            if (affectedRows != 1)
            {
                throw new InvalidOperationException(
                    "San pham khong ton tai hoac khong du hang.");
            }
        }

        Console.WriteLine("Da tru ton kho 2 san pham trong transaction.");

        // Bước 2: Tạo đơn hàng và lấy mã đơn tự tăng
        string insertOrderSql = @"
            INSERT INTO Orders
                (CashierUsername, CustomerId, CustomerPhone,
                 OrderDate, TotalAmount, CashReceived, ChangeAmount)
            VALUES
                (@CashierUsername, @CustomerId, @CustomerPhone,
                 @OrderDate, @TotalAmount, @CashReceived, @ChangeAmount);

            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        int orderId;

        using (SqlCommand command =
            new SqlCommand(insertOrderSql, connection, transaction))
        {
            command.Parameters.AddWithValue("@CashierUsername", "thuc_hanh");
            command.Parameters.AddWithValue("@CustomerId", customerId);
            command.Parameters.AddWithValue("@CustomerPhone", DBNull.Value);
            command.Parameters.AddWithValue("@OrderDate", DateTime.Now);
            command.Parameters.AddWithValue("@TotalAmount", totalAmount);
            command.Parameters.AddWithValue("@CashReceived", totalAmount);
            command.Parameters.AddWithValue("@ChangeAmount", 0m);

            orderId = (int)command.ExecuteScalar()!;
        }

        Console.WriteLine($"Da tao don hang tam voi ma: {orderId}");

        // Bước 3: Thêm chi tiết đơn hàng
        string insertDetailSql = @"
            INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice)
            VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice);";

        using (SqlCommand command =
            new SqlCommand(insertDetailSql, connection, transaction))
        {
            command.Parameters.AddWithValue("@OrderId", orderId);
            command.Parameters.AddWithValue("@ProductId", productId);
            command.Parameters.AddWithValue("@Quantity", quantity);
            command.Parameters.AddWithValue("@UnitPrice", unitPrice);

            command.ExecuteNonQuery();
        }

        Console.WriteLine("Da them chi tiet don hang.");

        // Xác nhận giao dịch khi tất cả thao tác đều thành công
        transaction.Commit();

        Console.WriteLine("Commit thanh cong!");
        Console.WriteLine("Don hang da duoc luu vao database.");
    }
    catch (Exception ex)
    {
        // Hoàn tác cả trừ kho, tạo đơn hàng và chi tiết đơn hàng
        try
        {
            transaction.Rollback();
            Console.WriteLine("\nRollback thanh cong!");
            Console.WriteLine("Ton kho va don hang da duoc hoan tac.");
        }
        catch (Exception rollbackEx)
        {
            Console.WriteLine("Loi Rollback: " + rollbackEx.Message);
        }

        Console.WriteLine("Chi tiet loi: " + ex.Message);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Loi ket noi hoac loi SQL: " + ex.Message);
}

Console.WriteLine("\nNhan phim bat ky de ket thuc.");
Console.ReadKey();
