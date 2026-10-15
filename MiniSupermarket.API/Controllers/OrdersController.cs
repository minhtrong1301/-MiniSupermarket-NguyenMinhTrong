
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public OrdersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // POST: api/orders/checkout
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(
            [FromBody] CheckoutRequest request)
        {
            // 1. Kiểm tra dữ liệu đầu vào
            if (request.Items == null || request.Items.Count == 0)
            {
                return BadRequest(new
                {
                    message = "Giỏ hàng đang trống!"
                });
            }

            if (request.Items.Any(i => i.ProductId <= 0 || i.Quantity <= 0))
            {
                return BadRequest(new
                {
                    message = "Sản phẩm hoặc số lượng không hợp lệ!"
                });
            }

            if (request.CashReceived < 0)
            {
                return BadRequest(new
                {
                    message = "Số tiền khách đưa không hợp lệ!"
                });
            }

            // Gộp các dòng trùng ProductId để tránh xử lý lặp
            var items = request.Items
                .GroupBy(i => i.ProductId)
                .Select(g => new CheckoutItem
                {
                    ProductId = g.Key,
                    Quantity = g.Sum(i => i.Quantity)
                })
                .ToList();

            await using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                // 2. Lấy sản phẩm từ database
                var productIds = items.Select(i => i.ProductId).ToList();

                var products = await _context.Products
                    .Where(p => productIds.Contains(p.ProductId))
                    .ToListAsync();

                if (products.Count != productIds.Count)
                {
                    await transaction.RollbackAsync();

                    return BadRequest(new
                    {
                        message = "Có sản phẩm không tồn tại!"
                    });
                }

                // 3. Kiểm tra tồn kho
                foreach (var item in items)
                {
                    var product = products.First(
                        p => p.ProductId == item.ProductId);

                    if (product.StockQuantity < item.Quantity)
                    {
                        await transaction.RollbackAsync();

                        return BadRequest(new
                        {
                            message = $"Sản phẩm {product.ProductName} " +
                                      $"chỉ còn {product.StockQuantity} sản phẩm!"
                        });
                    }
                }

                // 4. Tính tổng tiền theo giá trong database
                decimal totalAmount = items.Sum(item =>
                {
                    var product = products.First(
                        p => p.ProductId == item.ProductId);

                    return product.Price * item.Quantity;
                });

                if (request.CashReceived < totalAmount)
                {
                    await transaction.RollbackAsync();

                    return BadRequest(new
                    {
                        message = "Tiền khách đưa chưa đủ thanh toán!",
                        totalAmount,
                        cashReceived = request.CashReceived,
                        changeAmount = 0
                    });
                }

                // 5. Tìm khách hàng nếu có nhập số điện thoại
                Customer? customer = null;
                string? customerPhone =
                    string.IsNullOrWhiteSpace(request.CustomerPhone)
                        ? null
                        : request.CustomerPhone.Trim();

                if (customerPhone != null)
                {
                    customer = await _context.Customers
                        .FirstOrDefaultAsync(
                            c => c.PhoneNumber == customerPhone);

                    if (customer == null)
                    {
                        await transaction.RollbackAsync();

                        return BadRequest(new
                        {
                            message = "Không tìm thấy khách hàng có số điện thoại này!"
                        });
                    }
                }

                // 6. Tạo hóa đơn
                var order = new Order
                {
                    CashierUsername =
                        User.Identity?.Name
                        ?? request.CashierUsername.Trim(),

                    CustomerId = customer?.CustomerId,
                    CustomerPhone = customerPhone,
                    OrderDate = DateTime.Now,
                    TotalAmount = totalAmount,
                    CashReceived = request.CashReceived,
                    ChangeAmount = request.CashReceived - totalAmount
                };

                _context.Orders.Add(order);

                // Lưu để database sinh OrderId
                await _context.SaveChangesAsync();

                // 7. Tạo chi tiết hóa đơn và trừ tồn kho
                foreach (var item in items)
                {
                    var product = products.First(
                        p => p.ProductId == item.ProductId);

                    _context.OrderDetails.Add(new OrderDetail
                    {
                        OrderId = order.OrderId,
                        ProductId = product.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = product.Price
                    });

                    product.StockQuantity -= item.Quantity;
                }

                await _context.SaveChangesAsync();

                // 8. Xác nhận toàn bộ giao dịch
                await transaction.CommitAsync();

                return Ok(new
                {
                    message = "Thanh toán thành công!",
                    orderId = order.OrderId,
                    orderDate = order.OrderDate,
                    cashierUsername = order.CashierUsername,
                    customerPhone = order.CustomerPhone,
                    totalAmount = order.TotalAmount,
                    cashReceived = order.CashReceived,
                    changeAmount = order.ChangeAmount
                });

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();

                return StatusCode(500, new
                {
                    message = "Đã xảy ra lỗi khi thanh toán. Giao dịch đã được hủy."
                });
            }
        }

        // GET: api/orders/quick-report
        [HttpGet("quick-report")]
        public async Task<IActionResult> GetQuickReport()
        {
            // Đếm tổng số hóa đơn
            int totalOrders = await _context.Orders.CountAsync();

            // Tính tổng doanh thu từ các hóa đơn
            decimal totalRevenue = await _context.Orders
                .SumAsync(o => (decimal?)o.TotalAmount) ?? 0;

            // Tìm sản phẩm bán chạy nhất dựa trên tổng số lượng đã bán
            var bestSeller = await _context.OrderDetails
                .GroupBy(d => new
                {
                    d.ProductId,
                    ProductName = d.Product!.ProductName
                })
                .Select(g => new
                {
                    ProductName = g.Key.ProductName,
                    TotalQuantity = g.Sum(d => d.Quantity)
                })
                .OrderByDescending(x => x.TotalQuantity)
                .FirstOrDefaultAsync();

            return Ok(new
            {
                totalOrders,
                totalRevenue,
                bestSeller = bestSeller?.ProductName ?? "Chưa có dữ liệu",
                bestSellerQuantity = bestSeller?.TotalQuantity ?? 0
            });
        }

    }

    // Dữ liệu WinForms gửi lên API
    public class CheckoutRequest
    {
        public string CashierUsername { get; set; } = string.Empty;

        public string? CustomerPhone { get; set; }

        public decimal CashReceived { get; set; }

        public List<CheckoutItem> Items { get; set; } = new();
    }

    public class CheckoutItem
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
