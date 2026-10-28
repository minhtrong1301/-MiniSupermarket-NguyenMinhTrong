
namespace MiniSupermarket.API.DTOs
{
    // Luu thong tin thong ke cua mot san pham ban chay
    public class TopSellingProductDto
    {
        // Ma san pham
        public int ProductId { get; set; }

        // Ten san pham
        public string ProductName { get; set; } = string.Empty;

        // Tong so luong da ban
        public int TotalQuantitySold { get; set; }

        // Tong doanh so cua san pham
        public decimal TotalSales { get; set; }
    }
}
