using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RewardPoints = table.Column<int>(type: "int", nullable: false),
                    MembershipRank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Gạo, Nếp & Cốc loại", "Gạo ST25, gạo nở, nếp nương, đậu xanh, đậu đỏ" },
                    { 2, "Gia vị & Dầu ăn", "Nước mắm, nước tương, hạt nêm, đường, dầu ăn" },
                    { 3, "Mì, Phở & Thực phẩm ăn liền", "Mì gói, phở khô, bún tươi, hủ tiếu, cháo ăn liền" },
                    { 4, "Bánh kẹo & Đồ ăn vặt", "Bánh quy, kẹo dẻo, snack, hạt điều, mứt" },
                    { 5, "Nước giải khát & Trà", "Nước ngọt, nước khoáng, trà túi lọc, cà phê hòa tan" },
                    { 6, "Sữa & Sản phẩm từ sữa", "Sữa tươi, sữa đặc, sữa chua, phô mai" },
                    { 7, "Thực phẩm đóng hộp", "Cá hộp, thịt hộp, pate, ngô ngọt đóng hộp" },
                    { 8, "Hóa mỹ phẩm & Tắm giặt", "Xà bông, dầu gội, nước rửa chén, nước lau nhà, bột giặt" },
                    { 9, "Vệ sinh cá nhân", "Kem đánh răng, bàn chải, khăn giấy, khẩu trang" },
                    { 10, "Đồ dùng gia đình & Gia dụng", "Băng dính, túi rác, màng bọc thực phẩm, chổi, khăn lau" },
                    { 11, "Thực phẩm khô & Nông sản", "Nấm hương, mộc nhĩ, tôm khô, măng khô" },
                    { 12, "Gia vị tươi & Đồ sơ chế", "Hành, tỏi, ớt, sả, gừng đóng gói" },
                    { 13, "Đồ uống có cồn & Bia", "Bia lon, rượu nếp, rượu vang" },
                    { 14, "Đồ mẹ và bé", "Tã bỉm, tăm bông em bé, khăn giấy ướt" },
                    { 15, "Nến, Hương & Đồ thờ cúng", "Hương thắp, nến cốc, giấy cúng gia đình" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 1, "123 Lê Lợi, Quận 1, TP.HCM", "Nguyễn Văn An", "Bạc", "0912345678", 350 },
                    { 2, "456 Nguyễn Trãi, Quận 5, TP.HCM", "Trần Thị Bình", "Kim Cương", "0987654321", 1200 },
                    { 3, "789 Võ Văn Tần, Quận 3, TP.HCM", "Lê Hoàng Cường", "Chuẩn", "0903112233", 50 },
                    { 4, "12 Điện Biên Phủ, Bình Thạnh, TP.HCM", "Phạm Minh Dung", "Vàng", "0938889900", 750 },
                    { 5, "88 Lý Thường Kiệt, Tân Bình, TP.HCM", "Hoàng Quốc Dung", "Chuẩn", "0977123456", 0 },
                    { 6, "54 CMT8, Quận 10, TP.HCM", "Đỗ Thị Giang", "Chuẩn", "0966554433", 150 },
                    { 7, "301 Hải Phòng, Thanh Khê, Đà Nẵng", "Vũ Hải Đăng", "Bạc", "0944118899", 520 },
                    { 8, "15 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội", "Ngô Bích Hằng", "Kim Cương", "0918273645", 2100 },
                    { 9, "67 Nguyễn Văn Cừ, Long Biên, Hà Nội", "Bùi Anh Tuấn", "Vàng", "0922334455", 890 },
                    { 10, "234 Ba Tháng Hai, Quận 10, TP.HCM", "Đặng Thu Thảo", "Bạc", "0955667788", 410 },
                    { 11, "11 Phạm Văn Đồng, Thủ Đức, TP.HCM", "Trịnh Quốc Bảo", "Chuẩn", "0909090909", 30 },
                    { 12, "89 Nguyễn Thị Minh Khai, Quận 3, TP.HCM", "Lý Mỹ Nhân", "Vàng", "0933221100", 1050 },
                    { 13, "43 Quang Trung, Gò Vấp, TP.HCM", "Dương Văn Khoa", "Bạc", "0978990011", 620 },
                    { 14, "500 Nam Kỳ Khởi Nghĩa, Quận 3, TP.HCM", "Mai Phương Thúy", "Kim Cương", "0911223344", 1850 },
                    { 15, "76 Nguyễn Văn Linh, Quận 7, TP.HCM", "Cao Thái Sơn", "Chuẩn", "0945678901", 95 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "8935001001", 1, 180000m, "Gạo Ông Thọ ST25 5kg", 50 },
                    { 2, "8935001002", 2, 32000m, "Nước mắm Nam Ngư 500ml", 120 },
                    { 3, "8935001003", 3, 115000m, "Mì Hảo Hảo Tôm Chua Cay (Thùng 30 gói)", 40 },
                    { 4, "8935001004", 4, 18000m, "Bánh quy OREO vị Vani 133g", 80 },
                    { 5, "8935001005", 5, 10000m, "Nước khoáng Lavie 1.5L", 150 },
                    { 6, "8935001006", 6, 38000m, "Sữa tươi Vinamilk Có Đường 1L", 60 },
                    { 7, "8935001007", 7, 28000m, "Cá ngừ ngâm dầu Hạ Long 175g", 45 },
                    { 8, "8935001008", 8, 30000m, "Nước rửa chén Sunlight Chanh 750ml", 90 },
                    { 9, "8935001009", 9, 25000m, "Kem đánh răng PS Bảo Vệ 123 180g", 100 },
                    { 10, "8935001010", 10, 35000m, "Túi rác tự hủy sinh học 1kg", 75 },
                    { 11, "8935001011", 11, 45000m, "Nấm hương khô Cao Bằng 100g", 30 },
                    { 12, "8935001012", 12, 22000m, "Tỏi Lý Sơn đóng gói 200g", 50 },
                    { 13, "8935001013", 13, 105000m, "Bia Tiger Lon 330ml (Lốc 6 lon)", 35 },
                    { 14, "8935001014", 14, 42000m, "Khăn giấy ướt Bobby 100 tờ", 65 },
                    { 15, "8935001015", 15, 25000m, "Hương trầm thảo mộc cao cấp 100 nén", 85 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
