
using System;
using Microsoft.Data.SqlClient;

namespace ThucHanhAdoNet_Tiet1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ket noi toi database cua Bach hoa gia dinh Ba Tu.
            string connString =
                "Server=.\\SQLEXPRESS;" +
                "Database=NguyenMinhTrong_MiniSupermarketDb;" +
                "Trusted_Connection=True;" +
                "TrustServerCertificate=True;";

            Console.WriteLine("=== BAI 3: DANH SACH SAN PHAM ===");

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    // Truy van cac cot can hien thi tu bang Products.
                    string sql = @"
                        SELECT ProductId, Barcode, ProductName,
                               Price, StockQuantity
                        FROM Products
                        ORDER BY ProductId ASC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Mo ket noi truoc khi doc du lieu.
                        connection.Open();

                        // ExecuteReader tra ve luong doc du lieu.
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine(
                                "--------------------------------------------------------------------------");
                            Console.WriteLine(
                                $"{"MA SP",-6} | {"MA VACH",-15} | {"TEN SAN PHAM",-30} | {"DON GIA",12} | {"TON KHO",8}");
                            Console.WriteLine(
                                "--------------------------------------------------------------------------");

                            int count = 0;

                            // Doc tung dong cho den khi het du lieu.
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["ProductId"]);
                                string barcode = reader["Barcode"]?.ToString() ?? "";
                                string name = reader["ProductName"]?.ToString() ?? "";
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                int stock = Convert.ToInt32(reader["StockQuantity"]);

                                // In thong tin san pham theo cot.
                                Console.WriteLine(
                                    $"{id,-6} | {barcode,-15} | {name,-30} | {price,12:N0} | {stock,8}");

                                count++;
                            }

                            Console.WriteLine(
                                "--------------------------------------------------------------------------");
                            Console.WriteLine($"Tong so san pham da doc: {count}");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Loi SQL Server:");
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loi he thong:");
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Nhan phim bat ky de ket thuc...");
            Console.ReadKey();
        }
    }
}
