
namespace MiniSupermarket.API.DTOs
{
    // Luu thong tin doanh thu cua tung thu ngan
    public class CashierRevenueDto
    {
        // Ten tai khoan thu ngan
        public string CashierUsername { get; set; } = string.Empty;

        // Tong so don hang cua thu ngan
        public int TotalOrders { get; set; }

        // Tong doanh thu cua thu ngan
        public decimal TotalRevenue { get; set; }
    }
}
