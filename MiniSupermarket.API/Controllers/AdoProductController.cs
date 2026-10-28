
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MiniSupermarket.API.Controllers
{
    // DTO chứa thông tin sản phẩm trả về cho quầy thu ngân
    public class ProductLookupDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }

    [Route("api/ado-products")]
    [ApiController]
    public class AdoProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // Nhận cấu hình để lấy chuỗi kết nối database
        public AdoProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: /api/ado-products/barcode/8935001001
        [HttpGet("barcode/{barcode}")]
        public IActionResult GetProductByBarcode(string barcode)
        {
            // Kiểm tra mã vạch đầu vào
            if (string.IsNullOrWhiteSpace(barcode))
            {
                return BadRequest(new
                {
                    message = "Mã vạch không được để trống."
                });
            }

            // Lấy chuỗi kết nối từ appsettings.json
            string? connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return StatusCode(500, new
                {
                    message = "Chưa cấu hình chuỗi kết nối DefaultConnection."
                });
            }

            // Tìm sản phẩm theo mã vạch bằng tham số SQL
            string sql = @"
                SELECT ProductId, Barcode, ProductName, Price, StockQuantity
                FROM Products
                WHERE Barcode = @Barcode";

            try
            {
                using SqlConnection connection =
                    new SqlConnection(connectionString);

                using SqlCommand command = new SqlCommand(sql, connection);

                // Truyền tham số để tránh SQL Injection
                command.Parameters.AddWithValue("@Barcode", barcode.Trim());

                // Mở kết nối đến SQL Server
                connection.Open();

                // Đọc kết quả theo từng dòng
                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Chuyển dữ liệu SQL thành đối tượng DTO
                    ProductLookupDto product = new ProductLookupDto
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        Barcode = reader["Barcode"]?.ToString() ?? "",
                        ProductName = reader["ProductName"]?.ToString() ?? "",
                        Price = Convert.ToDecimal(reader["Price"]),
                        StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                    };

                    return Ok(product);
                }

                // Không tìm thấy sản phẩm tương ứng
                return NotFound(new
                {
                    message = $"Không tìm thấy sản phẩm có mã vạch: {barcode}"
                });
            }
            catch (SqlException)
            {
                // Không trả chi tiết lỗi SQL nội bộ cho client
                return StatusCode(500, new
                {
                    message = "Không thể truy vấn dữ liệu sản phẩm."
                });
            }
        }

        // GET: /api/ado-products/disconnected-cache
        [HttpGet("disconnected-cache")]
        public IActionResult GetProductsDisconnected()
        {
            string? connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return StatusCode(500, new
                {
                    message = "Chưa cấu hình chuỗi kết nối DefaultConnection."
                });
            }

            // Tạo DataTable để lưu dữ liệu sản phẩm trong RAM
            System.Data.DataTable productTable =
                new System.Data.DataTable("CachedProducts");

            try
            {
                string sql = @"
                    SELECT ProductId, Barcode, ProductName, Price, StockQuantity
                    FROM Products
                    ORDER BY ProductId ASC";

                using SqlConnection connection =
                    new SqlConnection(connectionString);

                using SqlCommand command = new SqlCommand(sql, connection);

                // SqlDataAdapter nạp dữ liệu vào DataTable
                using SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(productTable);

                // Chuyển các dòng DataTable thành danh sách DTO để trả về JSON
                var products = new List<ProductLookupDto>();

                foreach (System.Data.DataRow row in productTable.Rows)
                {
                    products.Add(new ProductLookupDto
                    {
                        ProductId = Convert.ToInt32(row["ProductId"]),
                        Barcode = row["Barcode"]?.ToString() ?? "",
                        ProductName = row["ProductName"]?.ToString() ?? "",
                        Price = Convert.ToDecimal(row["Price"]),
                        StockQuantity = Convert.ToInt32(row["StockQuantity"])
                    });
                }

                return Ok(new
                {
                    totalLoaded = productTable.Rows.Count,
                    cachedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    data = products
                });
            }
            catch (SqlException)
            {
                return StatusCode(500, new
                {
                    message = "Không thể tải danh sách sản phẩm."
                });
            }
        }

        // GET: /api/ado-products/filter-stock?minStock=50
        [HttpGet("filter-stock")]
        public IActionResult GetProductsByStock(int minStock = 50)
        {
            // Kiểm tra số lượng tồn kho đầu vào
            if (minStock < 0)
            {
                return BadRequest(new
                {
                    message = "Số lượng tồn kho không được âm."
                });
            }

            string? connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return StatusCode(500, new
                {
                    message = "Chưa cấu hình chuỗi kết nối."
                });
            }

            string sql = @"
                SELECT ProductId, Barcode, ProductName, Price, StockQuantity
                FROM Products
                WHERE StockQuantity <= @MinStock
                ORDER BY StockQuantity ASC";

            var products = new List<ProductLookupDto>();

            try
            {
                using SqlConnection connection =
                    new SqlConnection(connectionString);

                using SqlCommand command = new SqlCommand(sql, connection);

                // Truyền tham số an toàn vào câu SQL
                command.Parameters.Add("@MinStock",
                    System.Data.SqlDbType.Int).Value = minStock;

                connection.Open();

                // Đọc các sản phẩm thỏa điều kiện tồn kho
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new ProductLookupDto
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        Barcode = reader["Barcode"]?.ToString() ?? "",
                        ProductName = reader["ProductName"]?.ToString() ?? "",
                        Price = Convert.ToDecimal(reader["Price"]),
                        StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                    });
                }

                return Ok(new
                {
                    minStock,
                    totalFound = products.Count,
                    data = products
                });
            }
            catch (SqlException)
            {
                return StatusCode(500, new
                {
                    message = "Không thể truy vấn tồn kho sản phẩm."
                });
            }
        }

        // GET: /api/ado-products/category-count
        [HttpGet("category-count")]
        public IActionResult GetProductCountByCategory()
        {
            // Lấy chuỗi kết nối từ cấu hình ứng dụng
            string? connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return StatusCode(500, new
                {
                    message = "Chưa cấu hình chuỗi kết nối."
                });
            }

            // Truy vấn đếm số sản phẩm trong từng danh mục
            string sql = @"
                SELECT CategoryId, COUNT(*) AS Total
                FROM Products
                GROUP BY CategoryId
                ORDER BY CategoryId";

            // Tạo DataTable để lưu kết quả trên bộ nhớ RAM
            System.Data.DataTable categoryTable =
                new System.Data.DataTable("CategoryProductCounts");

            try
            {
                using SqlConnection connection =
                    new SqlConnection(connectionString);

                using SqlCommand command = new SqlCommand(sql, connection);

                // SqlDataAdapter tự mở kết nối, nạp dữ liệu và đóng kết nối
                using SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(categoryTable);

                // Chuyển dữ liệu từ DataTable thành danh sách kết quả
                var results = new List<object>();

                foreach (System.Data.DataRow row in categoryTable.Rows)
                {
                    results.Add(new
                    {
                        categoryId = row["CategoryId"] == DBNull.Value
                            ? (int?)null
                            : Convert.ToInt32(row["CategoryId"]),

                        total = Convert.ToInt32(row["Total"])
                    });
                }

                // Trả kết quả thống kê cho client
                return Ok(new
                {
                    totalCategories = categoryTable.Rows.Count,
                    data = results
                });
            }
            catch (SqlException)
            {
                return StatusCode(500, new
                {
                    message = "Không thể thống kê sản phẩm theo danh mục."
                });
            }
        }

    }
}
