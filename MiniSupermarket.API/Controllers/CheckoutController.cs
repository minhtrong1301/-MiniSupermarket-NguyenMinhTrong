
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MiniSupermarket.API.DTOs;
using System.Data;

namespace MiniSupermarket.API.Controllers
{
    [ApiController]
    [Route("api/checkout")]
    public class CheckoutController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CheckoutController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // POST: /api/checkout
        [HttpPost]
        public async Task<IActionResult> Checkout(
            [FromBody] CheckoutRequestDto request)
        {
            // 1. Kiểm tra dữ liệu đầu vào.
            if (request == null ||
                string.IsNullOrWhiteSpace(request.CashierUsername))
            {
                return BadRequest(new
                {
                    message = "Vui lòng cung cấp tên nhân viên thu ngân."
                });
            }

            if (request.Items == null || request.Items.Count == 0)
            {
                return BadRequest(new
                {
                    message = "Giỏ hàng không có sản phẩm."
                });
            }

            if (request.Items.Any(item =>
                item.ProductId <= 0 || item.Quantity <= 0))
            {
                return BadRequest(new
                {
                    message = "Mã sản phẩm hoặc số lượng không hợp lệ."
                });
            }

            if (request.CashReceived < 0)
            {
                return BadRequest(new
                {
                    message = "Số tiền khách đưa không hợp lệ."
                });
            }

            // Không cho phép một sản phẩm xuất hiện nhiều lần trong giỏ.
            // Việc gộp sản phẩm giúp tránh kiểm tra tồn kho sai lệch.
            if (request.Items
                .GroupBy(item => item.ProductId)
                .Any(group => group.Count() > 1))
            {
                return BadRequest(new
                {
                    message = "Một sản phẩm chỉ được xuất hiện một lần trong giỏ hàng."
                });
            }

            string connectionString =
                _configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Chưa cấu hình DefaultConnection.");

            await using var connection =
                new SqlConnection(connectionString);

            await connection.OpenAsync();

            // Bắt đầu giao dịch để các thao tác SQL thành công hoặc thất bại cùng nhau.
            await using var transaction =
                (SqlTransaction)await connection.BeginTransactionAsync(
                    IsolationLevel.Serializable);

            try
            {
                decimal totalAmount = 0;

                // Lưu giá thật đọc từ database để dùng khi ghi OrderDetails.
                var productPrices = new Dictionary<int, decimal>();

                // 2. Kiểm tra sản phẩm và lấy giá, tồn kho thật từ database.
                foreach (var item in request.Items.OrderBy(x => x.ProductId))
                {
                    await using var productCommand = new SqlCommand(
                        @"SELECT Price, StockQuantity
                          FROM Products WITH (UPDLOCK, HOLDLOCK)
                          WHERE ProductId = @ProductId",
                        connection,
                        transaction);

                    productCommand.Parameters.Add(
                        "@ProductId", SqlDbType.Int).Value = item.ProductId;

                    await using var reader =
                        await productCommand.ExecuteReaderAsync();

                    if (!await reader.ReadAsync())
                    {
                        throw new InvalidOperationException(
                            $"Không tìm thấy sản phẩm có mã {item.ProductId}.");
                    }

                    decimal price = reader.GetDecimal(0);
                    int stock = reader.GetInt32(1);

                    await reader.CloseAsync();

                    if (stock < item.Quantity)
                    {
                        throw new InvalidOperationException(
                            $"Sản phẩm mã {item.ProductId} không đủ tồn kho. " +
                            $"Tồn kho hiện tại: {stock}, số lượng yêu cầu: {item.Quantity}.");
                    }

                    if (price < 0)
                    {
                        throw new InvalidOperationException(
                            $"Giá sản phẩm mã {item.ProductId} không hợp lệ.");
                    }

                    productPrices[item.ProductId] = price;
                    totalAmount += price * item.Quantity;
                }

                // Kiểm tra tiền khách đưa sau khi tính tổng từ giá database.
                if (request.CashReceived < totalAmount)
                {
                    throw new InvalidOperationException(
                        $"Khách đưa chưa đủ tiền. Tổng tiền: {totalAmount:N0}.");
                }

                decimal changeAmount =
                    request.CashReceived - totalAmount;

                // 3. Nếu có chọn khách hàng, kiểm tra khách tồn tại.
                if (request.CustomerId.HasValue)
                {
                    await using var customerCommand = new SqlCommand(
                        @"SELECT CustomerId
                          FROM Customers WITH (UPDLOCK, HOLDLOCK)
                          WHERE CustomerId = @CustomerId",
                        connection,
                        transaction);

                    customerCommand.Parameters.Add(
                        "@CustomerId", SqlDbType.Int).Value =
                        request.CustomerId.Value;

                    object? customerId =
                        await customerCommand.ExecuteScalarAsync();

                    if (customerId == null)
                    {
                        throw new InvalidOperationException(
                            "Không tìm thấy khách hàng được chọn.");
                    }
                }

                // 4. Tạo đơn hàng và lấy OrderId vừa được SQL Server sinh ra.
                const string insertOrderSql = @"
                    INSERT INTO Orders
                    (
                        CashierUsername,
                        CustomerId,
                        CustomerPhone,
                        OrderDate,
                        TotalAmount,
                        CashReceived,
                        ChangeAmount
                    )
                    OUTPUT INSERTED.OrderId
                    VALUES
                    (
                        @CashierUsername,
                        @CustomerId,
                        @CustomerPhone,
                        SYSDATETIME(),
                        @TotalAmount,
                        @CashReceived,
                        @ChangeAmount
                    );";

                int orderId;

                await using (var orderCommand = new SqlCommand(
                    insertOrderSql, connection, transaction))
                {
                    orderCommand.Parameters.Add(
                        "@CashierUsername", SqlDbType.NVarChar, 256)
                        .Value = request.CashierUsername.Trim();

                    orderCommand.Parameters.Add(
                        "@CustomerId", SqlDbType.Int)
                        .Value = request.CustomerId.HasValue
                            ? request.CustomerId.Value
                            : DBNull.Value;

                    orderCommand.Parameters.Add(
                        "@CustomerPhone", SqlDbType.VarChar, 50)
                        .Value = DBNull.Value;

                    var totalParameter = orderCommand.Parameters.Add(
                        "@TotalAmount", SqlDbType.Decimal);
                    totalParameter.Precision = 18;
                    totalParameter.Scale = 2;
                    totalParameter.Value = totalAmount;

                    var cashParameter = orderCommand.Parameters.Add(
                        "@CashReceived", SqlDbType.Decimal);
                    cashParameter.Precision = 18;
                    cashParameter.Scale = 2;
                    cashParameter.Value = request.CashReceived;

                    var changeParameter = orderCommand.Parameters.Add(
                        "@ChangeAmount", SqlDbType.Decimal);
                    changeParameter.Precision = 18;
                    changeParameter.Scale = 2;
                    changeParameter.Value = changeAmount;

                    orderId = Convert.ToInt32(
                        await orderCommand.ExecuteScalarAsync());
                }

                // 5. Ghi chi tiết đơn hàng và trừ tồn kho.
                foreach (var item in request.Items)
                {
                    decimal price = productPrices[item.ProductId];

                    await using var detailCommand = new SqlCommand(
                        @"INSERT INTO OrderDetails
                          (OrderId, ProductId, Quantity, UnitPrice)
                          VALUES
                          (@OrderId, @ProductId, @Quantity, @UnitPrice)",
                        connection,
                        transaction);

                    detailCommand.Parameters.Add(
                        "@OrderId", SqlDbType.Int).Value = orderId;

                    detailCommand.Parameters.Add(
                        "@ProductId", SqlDbType.Int).Value = item.ProductId;

                    detailCommand.Parameters.Add(
                        "@Quantity", SqlDbType.Int).Value = item.Quantity;

                    var priceParameter = detailCommand.Parameters.Add(
                        "@UnitPrice", SqlDbType.Decimal);
                    priceParameter.Precision = 18;
                    priceParameter.Scale = 2;
                    priceParameter.Value = price;

                    await detailCommand.ExecuteNonQueryAsync();

                    await using var stockCommand = new SqlCommand(
                        @"UPDATE Products
                          SET StockQuantity = StockQuantity - @Quantity
                          WHERE ProductId = @ProductId
                            AND StockQuantity >= @Quantity",
                        connection,
                        transaction);

                    stockCommand.Parameters.Add(
                        "@Quantity", SqlDbType.Int).Value = item.Quantity;

                    stockCommand.Parameters.Add(
                        "@ProductId", SqlDbType.Int).Value = item.ProductId;

                    int affectedRows =
                        await stockCommand.ExecuteNonQueryAsync();

                    if (affectedRows != 1)
                    {
                        throw new InvalidOperationException(
                            $"Không thể cập nhật tồn kho sản phẩm mã {item.ProductId}.");
                    }
                }

                // 6. Cộng điểm cho khách hàng thành viên.
                // Quy tắc: cứ đủ 10.000 đồng được cộng 1 điểm.
                int earnedPoints = (int)Math.Floor(totalAmount / 10000m);

                if (request.CustomerId.HasValue && earnedPoints > 0)
                {
                    await using var pointsCommand = new SqlCommand(
                        @"UPDATE Customers
                          SET RewardPoints = RewardPoints + @Points
                          WHERE CustomerId = @CustomerId",
                        connection,
                        transaction);

                    pointsCommand.Parameters.Add(
                        "@Points", SqlDbType.Int).Value = earnedPoints;

                    pointsCommand.Parameters.Add(
                        "@CustomerId", SqlDbType.Int).Value =
                        request.CustomerId.Value;

                    int affectedRows =
                        await pointsCommand.ExecuteNonQueryAsync();

                    if (affectedRows != 1)
                    {
                        throw new InvalidOperationException(
                            "Không thể cập nhật điểm tích lũy khách hàng.");
                    }
                }

                // Chỉ xác nhận giao dịch sau khi tất cả thao tác thành công.
                await transaction.CommitAsync();

                return Ok(new
                {
                    success = true,
                    message = "Thanh toán thành công.",
                    orderId,
                    totalAmount,
                    cashReceived = request.CashReceived,
                    changeAmount,
                    earnedPoints = request.CustomerId.HasValue
                        ? earnedPoints
                        : 0
                });
            }
            catch (Exception ex)
            {
                // Hoàn tác đơn hàng, chi tiết, tồn kho và điểm nếu có lỗi.
                try
                {
                    await transaction.RollbackAsync();
                }
                catch
                {
                    // Giữ lại lỗi ban đầu nếu việc rollback cũng gặp lỗi.
                }

                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }


        // DELETE: /api/checkout/cancel/{orderId}
        [HttpDelete("cancel/{orderId:int}")]
        public async Task<IActionResult> CancelCheckout(int orderId)
        {
            if (orderId <= 0)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Mã đơn hàng không hợp lệ."
                });
            }

            string connectionString =
                _configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Chưa cấu hình DefaultConnection.");

            await using var connection =
                new SqlConnection(connectionString);

            await connection.OpenAsync();

            await using var transaction =
                (SqlTransaction)await connection.BeginTransactionAsync(
                    IsolationLevel.Serializable);

            try
            {
                // 1. Đọc và khóa đơn hàng trong suốt giao dịch.
                await using var orderCommand = new SqlCommand(
                    @"SELECT CustomerId, TotalAmount
                      FROM Orders WITH (UPDLOCK, HOLDLOCK)
                      WHERE OrderId = @OrderId",
                    connection,
                    transaction);

                orderCommand.Parameters.Add(
                    "@OrderId", SqlDbType.Int).Value = orderId;

                int? customerId = null;
                decimal totalAmount;

                await using (var reader =
                    await orderCommand.ExecuteReaderAsync())
                {
                    if (!await reader.ReadAsync())
                    {
                        throw new InvalidOperationException(
                            $"Không tìm thấy đơn hàng {orderId}.");
                    }

                    customerId = reader.IsDBNull(0)
                        ? null
                        : reader.GetInt32(0);

                    totalAmount = reader.GetDecimal(1);
                }

                // 2. Lấy chi tiết đơn hàng để hoàn lại tồn kho.
                var orderItems = new List<(int ProductId, int Quantity)>();

                await using (var detailCommand = new SqlCommand(
                    @"SELECT ProductId, Quantity
                      FROM OrderDetails
                      WHERE OrderId = @OrderId",
                    connection,
                    transaction))
                {
                    detailCommand.Parameters.Add(
                        "@OrderId", SqlDbType.Int).Value = orderId;

                    await using var reader =
                        await detailCommand.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        orderItems.Add((
                            reader.GetInt32(0),
                            reader.GetInt32(1)));
                    }
                }

                if (orderItems.Count == 0)
                {
                    throw new InvalidOperationException(
                        "Đơn hàng không có chi tiết để hoàn kho.");
                }

                // 3. Hoàn lại số lượng cho từng sản phẩm.
                foreach (var item in orderItems)
                {
                    await using var stockCommand = new SqlCommand(
                        @"UPDATE Products
                          SET StockQuantity = StockQuantity + @Quantity
                          WHERE ProductId = @ProductId",
                        connection,
                        transaction);

                    stockCommand.Parameters.Add(
                        "@Quantity", SqlDbType.Int).Value = item.Quantity;

                    stockCommand.Parameters.Add(
                        "@ProductId", SqlDbType.Int).Value = item.ProductId;

                    int affectedRows =
                        await stockCommand.ExecuteNonQueryAsync();

                    if (affectedRows != 1)
                    {
                        throw new InvalidOperationException(
                            $"Không thể hoàn kho sản phẩm {item.ProductId}.");
                    }
                }

                // 4. Trừ lại điểm đã cộng khi thanh toán.
                // Quy tắc hiện tại: mỗi 10.000 đồng được 1 điểm.
                int pointsToDeduct =
                    (int)Math.Floor(totalAmount / 10000m);

                if (customerId.HasValue && pointsToDeduct > 0)
                {
                    await using var pointsCommand = new SqlCommand(
                        @"UPDATE Customers
                          SET RewardPoints = RewardPoints - @Points
                          WHERE CustomerId = @CustomerId
                            AND RewardPoints >= @Points",
                        connection,
                        transaction);

                    pointsCommand.Parameters.Add(
                        "@Points", SqlDbType.Int).Value = pointsToDeduct;

                    pointsCommand.Parameters.Add(
                        "@CustomerId", SqlDbType.Int).Value =
                        customerId.Value;

                    int affectedRows =
                        await pointsCommand.ExecuteNonQueryAsync();

                    if (affectedRows != 1)
                    {
                        throw new InvalidOperationException(
                            "Không thể trừ điểm thưởng. " +
                            "Hãy kiểm tra số điểm hiện có của khách hàng.");
                    }
                }

                // 5. Xóa chi tiết trước để bảo đảm khóa ngoại.
                await using (var deleteDetailsCommand = new SqlCommand(
                    @"DELETE FROM OrderDetails
                      WHERE OrderId = @OrderId",
                    connection,
                    transaction))
                {
                    deleteDetailsCommand.Parameters.Add(
                        "@OrderId", SqlDbType.Int).Value = orderId;

                    await deleteDetailsCommand.ExecuteNonQueryAsync();
                }

                // 6. Xóa đơn hàng.
                await using (var deleteOrderCommand = new SqlCommand(
                    @"DELETE FROM Orders
                      WHERE OrderId = @OrderId",
                    connection,
                    transaction))
                {
                    deleteOrderCommand.Parameters.Add(
                        "@OrderId", SqlDbType.Int).Value = orderId;

                    int affectedRows =
                        await deleteOrderCommand.ExecuteNonQueryAsync();

                    if (affectedRows != 1)
                    {
                        throw new InvalidOperationException(
                            "Không thể xóa đơn hàng.");
                    }
                }

                // Xác nhận tất cả thao tác cùng lúc.
                await transaction.CommitAsync();

                return Ok(new
                {
                    success = true,
                    message = "Hủy đơn hàng thành công.",
                    orderId,
                    restoredItems = orderItems.Count,
                    deductedPoints = customerId.HasValue
                        ? pointsToDeduct
                        : 0
                });
            }
            catch (Exception ex)
            {
                // Nếu có lỗi, hoàn tác cả việc hoàn kho và trừ điểm.
                try
                {
                    await transaction.RollbackAsync();
                }
                catch
                {
                    // Giữ lại thông báo lỗi ban đầu.
                }

                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }


    }
}
