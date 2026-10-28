
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using MiniSupermarket.API.DTOs;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ReportsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Reports/revenue-by-cashier
        [HttpGet("revenue-by-cashier")]
        public async Task<IActionResult> GetRevenueByCashier()
        {
            // Lay chuoi ket noi SQL Server tu appsettings.json
            string? connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Khong tim thay chuoi ket noi DefaultConnection."
                });
            }

            var reportList = new List<CashierRevenueDto>();

            try
            {
                // Mo ket noi den database
                await using var connection =
                    new SqlConnection(connectionString);

                // Goi Stored Procedure da tao trong SQL Server
                await using var command =
                    new SqlCommand("sp_GetRevenueByCashier", connection);

                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                // Doc ket qua do Stored Procedure tra ve
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var report = new CashierRevenueDto
                    {
                        CashierUsername = reader["CashierUsername"].ToString()
                            ?? string.Empty,

                        TotalOrders = Convert.ToInt32(reader["TotalOrders"]),

                        TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                    };

                    reportList.Add(report);
                }

                // Tong doanh thu cua tat ca thu ngan
                decimal grandTotalRevenue =
                    reportList.Sum(item => item.TotalRevenue);

                return Ok(new
                {
                    success = true,
                    generatedAt = DateTime.Now,
                    totalCashiers = reportList.Count,
                    grandTotalRevenue,
                    data = reportList
                });
            }
            catch (SqlException ex)
            {
                // Tra loi khi co loi truy van SQL Server
                return StatusCode(500, new
                {
                    success = false,
                    message = "Khong the lay bao cao doanh thu.",
                    detail = ex.Message
                });
            }
        }


        // GET: api/Reports/revenue-by-date-range?fromDate=2026-01-01&toDate=2026-12-31
        [HttpGet("revenue-by-date-range")]
        public async Task<IActionResult> GetRevenueByDateRange(
            [FromQuery] DateTime fromDate,
            [FromQuery] DateTime toDate)
        {
            // Kiem tra khoang ngay dau vao
            if (fromDate == default || toDate == default ||
                fromDate.Date > toDate.Date)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Vui long nhap khoang ngay hop le."
                });
            }

            string? connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Khong tim thay chuoi ket noi DefaultConnection."
                });
            }

            var reportList = new List<CashierRevenueDto>();

            try
            {
                await using var connection =
                    new SqlConnection(connectionString);

                await using var command =
                    new SqlCommand("sp_GetRevenueByDateRange", connection);

                // Bao cho SQL Server biet day la Stored Procedure
                command.CommandType = CommandType.StoredProcedure;

                // Truyen tham so ngay vao Stored Procedure
                command.Parameters.Add("@FromDate", SqlDbType.Date)
                    .Value = fromDate.Date;

                command.Parameters.Add("@ToDate", SqlDbType.Date)
                    .Value = toDate.Date;

                await connection.OpenAsync();

                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    reportList.Add(new CashierRevenueDto
                    {
                        CashierUsername =
                            reader["CashierUsername"].ToString()
                            ?? string.Empty,

                        TotalOrders =
                            Convert.ToInt32(reader["TotalOrders"]),

                        TotalRevenue =
                            Convert.ToDecimal(reader["TotalRevenue"])
                    });
                }

                return Ok(new
                {
                    success = true,
                    fromDate = fromDate.Date,
                    toDate = toDate.Date,
                    totalCashiers = reportList.Count,
                    grandTotalRevenue =
                        reportList.Sum(item => item.TotalRevenue),
                    data = reportList
                });
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Khong the lay bao cao doanh thu theo ngay.",
                    detail = ex.Message
                });
            }
        }


        // GET: api/Reports/top-selling-products
        [HttpGet("top-selling-products")]
        public async Task<IActionResult> GetTopSellingProducts()
        {
            string? connectionString =
                _configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Khong tim thay chuoi ket noi DefaultConnection."
                });
            }

            var productList = new List<TopSellingProductDto>();

            try
            {
                await using var connection =
                    new SqlConnection(connectionString);

                await using var command =
                    new SqlCommand(
                        "sp_GetTop5BestSellingProducts",
                        connection);

                // Goi Stored Procedure thay vi viet truy van SQL truc tiep
                command.CommandType = CommandType.StoredProcedure;

                await connection.OpenAsync();

                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var product = new TopSellingProductDto
                    {
                        ProductId =
                            Convert.ToInt32(reader["ProductId"]),

                        ProductName =
                            reader["ProductName"].ToString()
                            ?? string.Empty,

                        TotalQuantitySold =
                            Convert.ToInt32(reader["TotalQuantitySold"]),

                        TotalSales =
                            Convert.ToDecimal(reader["TotalSales"])
                    };

                    productList.Add(product);
                }

                return Ok(new
                {
                    success = true,
                    totalProducts = productList.Count,
                    data = productList
                });
            }
            catch (SqlException ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Khong the lay danh sach san pham ban chay.",
                    detail = ex.Message
                });
            }
        }


    }
}

