
namespace MiniSupermarket.API.DTOs
{
    // Thông tin một sản phẩm trong giỏ hàng thanh toán.
    public class CartItemCheckoutDto
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        // API sẽ lấy giá thật từ database, không tin giá client gửi lên.
        public decimal UnitPrice { get; set; }
    }

    // Thông tin yêu cầu thanh toán tại quầy POS.
    public class CheckoutRequestDto
    {
        // Tên nhân viên thực hiện thanh toán.
        public string CashierUsername { get; set; } = string.Empty;

        // Có thể null nếu khách mua lẻ.
        public int? CustomerId { get; set; }

        // Số tiền khách đưa cho nhân viên.
        public decimal CashReceived { get; set; }

        // Danh sách sản phẩm cần thanh toán.
        public List<CartItemCheckoutDto> Items { get; set; } = new();
    }
}
