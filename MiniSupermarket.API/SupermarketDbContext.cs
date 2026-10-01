using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; } // Khai báo thêm bảng Customers

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Data Seeding cho Categories (15 danh mục)
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Gạo, Nếp & Cốc loại", Description = "Gạo ST25, gạo nở, nếp nương, đậu xanh, đậu đỏ" },
                new Category { CategoryId = 2, CategoryName = "Gia vị & Dầu ăn", Description = "Nước mắm, nước tương, hạt nêm, đường, dầu ăn" },
                new Category { CategoryId = 3, CategoryName = "Mì, Phở & Thực phẩm ăn liền", Description = "Mì gói, phở khô, bún tươi, hủ tiếu, cháo ăn liền" },
                new Category { CategoryId = 4, CategoryName = "Bánh kẹo & Đồ ăn vặt", Description = "Bánh quy, kẹo dẻo, snack, hạt điều, mứt" },
                new Category { CategoryId = 5, CategoryName = "Nước giải khát & Trà", Description = "Nước ngọt, nước khoáng, trà túi lọc, cà phê hòa tan" },
                new Category { CategoryId = 6, CategoryName = "Sữa & Sản phẩm từ sữa", Description = "Sữa tươi, sữa đặc, sữa chua, phô mai" },
                new Category { CategoryId = 7, CategoryName = "Thực phẩm đóng hộp", Description = "Cá hộp, thịt hộp, pate, ngô ngọt đóng hộp" },
                new Category { CategoryId = 8, CategoryName = "Hóa mỹ phẩm & Tắm giặt", Description = "Xà bông, dầu gội, nước rửa chén, nước lau nhà, bột giặt" },
                new Category { CategoryId = 9, CategoryName = "Vệ sinh cá nhân", Description = "Kem đánh răng, bàn chải, khăn giấy, khẩu trang" },
                new Category { CategoryId = 10, CategoryName = "Đồ dùng gia đình & Gia dụng", Description = "Băng dính, túi rác, màng bọc thực phẩm, chổi, khăn lau" },
                new Category { CategoryId = 11, CategoryName = "Thực phẩm khô & Nông sản", Description = "Nấm hương, mộc nhĩ, tôm khô, măng khô" },
                new Category { CategoryId = 12, CategoryName = "Gia vị tươi & Đồ sơ chế", Description = "Hành, tỏi, ớt, sả, gừng đóng gói" },
                new Category { CategoryId = 13, CategoryName = "Đồ uống có cồn & Bia", Description = "Bia lon, rượu nếp, rượu vang" },
                new Category { CategoryId = 14, CategoryName = "Đồ mẹ và bé", Description = "Tã bỉm, tăm bông em bé, khăn giấy ướt" },
                new Category { CategoryId = 15, CategoryName = "Nến, Hương & Đồ thờ cúng", Description = "Hương thắp, nến cốc, giấy cúng gia đình" }
            );

            // 2. Data Seeding cho Products (15 sản phẩm)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Barcode = "8935001001", ProductName = "Gạo Ông Thọ ST25 5kg", Price = 180000, StockQuantity = 50, CategoryId = 1 },
                new Product { ProductId = 2, Barcode = "8935001002", ProductName = "Nước mắm Nam Ngư 500ml", Price = 32000, StockQuantity = 120, CategoryId = 2 },
                new Product { ProductId = 3, Barcode = "8935001003", ProductName = "Mì Hảo Hảo Tôm Chua Cay (Thùng 30 gói)", Price = 115000, StockQuantity = 40, CategoryId = 3 },
                new Product { ProductId = 4, Barcode = "8935001004", ProductName = "Bánh quy OREO vị Vani 133g", Price = 18000, StockQuantity = 80, CategoryId = 4 },
                new Product { ProductId = 5, Barcode = "8935001005", ProductName = "Nước khoáng Lavie 1.5L", Price = 10000, StockQuantity = 150, CategoryId = 5 },
                new Product { ProductId = 6, Barcode = "8935001006", ProductName = "Sữa tươi Vinamilk Có Đường 1L", Price = 38000, StockQuantity = 60, CategoryId = 6 },
                new Product { ProductId = 7, Barcode = "8935001007", ProductName = "Cá ngừ ngâm dầu Hạ Long 175g", Price = 28000, StockQuantity = 45, CategoryId = 7 },
                new Product { ProductId = 8, Barcode = "8935001008", ProductName = "Nước rửa chén Sunlight Chanh 750ml", Price = 30000, StockQuantity = 90, CategoryId = 8 },
                new Product { ProductId = 9, Barcode = "8935001009", ProductName = "Kem đánh răng PS Bảo Vệ 123 180g", Price = 25000, StockQuantity = 100, CategoryId = 9 },
                new Product { ProductId = 10, Barcode = "8935001010", ProductName = "Túi rác tự hủy sinh học 1kg", Price = 35000, StockQuantity = 75, CategoryId = 10 },
                new Product { ProductId = 11, Barcode = "8935001011", ProductName = "Nấm hương khô Cao Bằng 100g", Price = 45000, StockQuantity = 30, CategoryId = 11 },
                new Product { ProductId = 12, Barcode = "8935001012", ProductName = "Tỏi Lý Sơn đóng gói 200g", Price = 22000, StockQuantity = 50, CategoryId = 12 },
                new Product { ProductId = 13, Barcode = "8935001013", ProductName = "Bia Tiger Lon 330ml (Lốc 6 lon)", Price = 105000, StockQuantity = 35, CategoryId = 13 },
                new Product { ProductId = 14, Barcode = "8935001014", ProductName = "Khăn giấy ướt Bobby 100 tờ", Price = 42000, StockQuantity = 65, CategoryId = 14 },
                new Product { ProductId = 15, Barcode = "8935001015", ProductName = "Hương trầm thảo mộc cao cấp 100 nén", Price = 25000, StockQuantity = 85, CategoryId = 15 }
            );

            // Data Seeding cho Customers (15 khách hàng mẫu)
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Nguyễn Văn An", PhoneNumber = "0912345678", Address = "123 Lê Lợi, Quận 1, TP.HCM", MembershipRank = "Bạc", RewardPoints = 350 },
                new Customer { CustomerId = 2, CustomerName = "Trần Thị Bình", PhoneNumber = "0987654321", Address = "456 Nguyễn Trãi, Quận 5, TP.HCM", MembershipRank = "Kim Cương", RewardPoints = 1200 },
                new Customer { CustomerId = 3, CustomerName = "Lê Hoàng Cường", PhoneNumber = "0903112233", Address = "789 Võ Văn Tần, Quận 3, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 50 },
                new Customer { CustomerId = 4, CustomerName = "Phạm Minh Dung", PhoneNumber = "0938889900", Address = "12 Điện Biên Phủ, Bình Thạnh, TP.HCM", MembershipRank = "Vàng", RewardPoints = 750 },
                new Customer { CustomerId = 5, CustomerName = "Hoàng Quốc Dung", PhoneNumber = "0977123456", Address = "88 Lý Thường Kiệt, Tân Bình, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 0 },
                new Customer { CustomerId = 6, CustomerName = "Đỗ Thị Giang", PhoneNumber = "0966554433", Address = "54 CMT8, Quận 10, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 150 },
                new Customer { CustomerId = 7, CustomerName = "Vũ Hải Đăng", PhoneNumber = "0944118899", Address = "301 Hải Phòng, Thanh Khê, Đà Nẵng", MembershipRank = "Bạc", RewardPoints = 520 },
                new Customer { CustomerId = 8, CustomerName = "Ngô Bích Hằng", PhoneNumber = "0918273645", Address = "15 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội", MembershipRank = "Kim Cương", RewardPoints = 2100 },
                new Customer { CustomerId = 9, CustomerName = "Bùi Anh Tuấn", PhoneNumber = "0922334455", Address = "67 Nguyễn Văn Cừ, Long Biên, Hà Nội", MembershipRank = "Vàng", RewardPoints = 890 },
                new Customer { CustomerId = 10, CustomerName = "Đặng Thu Thảo", PhoneNumber = "0955667788", Address = "234 Ba Tháng Hai, Quận 10, TP.HCM", MembershipRank = "Bạc", RewardPoints = 410 },
                new Customer { CustomerId = 11, CustomerName = "Trịnh Quốc Bảo", PhoneNumber = "0909090909", Address = "11 Phạm Văn Đồng, Thủ Đức, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 30 },
                new Customer { CustomerId = 12, CustomerName = "Lý Mỹ Nhân", PhoneNumber = "0933221100", Address = "89 Nguyễn Thị Minh Khai, Quận 3, TP.HCM", MembershipRank = "Vàng", RewardPoints = 1050 },
                new Customer { CustomerId = 13, CustomerName = "Dương Văn Khoa", PhoneNumber = "0978990011", Address = "43 Quang Trung, Gò Vấp, TP.HCM", MembershipRank = "Bạc", RewardPoints = 620 },
                new Customer { CustomerId = 14, CustomerName = "Mai Phương Thúy", PhoneNumber = "0911223344", Address = "500 Nam Kỳ Khởi Nghĩa, Quận 3, TP.HCM", MembershipRank = "Kim Cương", RewardPoints = 1850 },
                new Customer { CustomerId = 15, CustomerName = "Cao Thái Sơn", PhoneNumber = "0945678901", Address = "76 Nguyễn Văn Linh, Quận 7, TP.HCM", MembershipRank = "Chuẩn", RewardPoints = 95 }
            );
        }
    }
}