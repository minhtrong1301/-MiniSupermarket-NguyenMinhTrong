using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedOrdersAndOrderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CashReceived", "CashierUsername", "ChangeAmount", "CustomerId", "CustomerPhone", "OrderDate", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 200000m, "cashier01", 20000m, 1, "0912345678", new DateTime(2026, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 180000m },
                    { 2, 50000m, "cashier02", 18000m, 2, "0987654321", new DateTime(2026, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 32000m },
                    { 3, 150000m, "cashier01", 35000m, 3, "0903112233", new DateTime(2026, 10, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), 115000m },
                    { 4, 20000m, "cashier03", 2000m, 4, "0938889900", new DateTime(2026, 10, 2, 14, 0, 0, 0, DateTimeKind.Unspecified), 18000m },
                    { 5, 20000m, "cashier02", 10000m, 5, "0977123456", new DateTime(2026, 10, 3, 8, 30, 0, 0, DateTimeKind.Unspecified), 10000m },
                    { 6, 50000m, "cashier04", 12000m, 6, "0966554433", new DateTime(2026, 10, 3, 15, 0, 0, 0, DateTimeKind.Unspecified), 38000m },
                    { 7, 30000m, "cashier01", 2000m, 7, "0944118899", new DateTime(2026, 10, 4, 9, 30, 0, 0, DateTimeKind.Unspecified), 28000m },
                    { 8, 50000m, "cashier05", 20000m, 8, "0918273645", new DateTime(2026, 10, 4, 16, 0, 0, 0, DateTimeKind.Unspecified), 30000m },
                    { 9, 50000m, "cashier02", 25000m, 9, "0922334455", new DateTime(2026, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 25000m },
                    { 10, 50000m, "cashier03", 15000m, 10, "0955667788", new DateTime(2026, 10, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), 35000m },
                    { 11, 50000m, "cashier04", 5000m, 11, "0909090909", new DateTime(2026, 10, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 45000m },
                    { 12, 30000m, "cashier01", 8000m, 12, "0933221100", new DateTime(2026, 10, 6, 14, 30, 0, 0, DateTimeKind.Unspecified), 22000m },
                    { 13, 150000m, "cashier05", 45000m, 13, "0978990011", new DateTime(2026, 10, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), 105000m },
                    { 14, 50000m, "cashier02", 8000m, 14, "0911223344", new DateTime(2026, 10, 7, 15, 0, 0, 0, DateTimeKind.Unspecified), 42000m },
                    { 15, 30000m, "cashier03", 5000m, 15, "0945678901", new DateTime(2026, 10, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), 25000m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 180000m },
                    { 2, 2, 2, 1, 32000m },
                    { 3, 3, 3, 1, 115000m },
                    { 4, 4, 4, 1, 18000m },
                    { 5, 5, 5, 1, 10000m },
                    { 6, 6, 6, 1, 38000m },
                    { 7, 7, 7, 1, 28000m },
                    { 8, 8, 8, 1, 30000m },
                    { 9, 9, 9, 1, 25000m },
                    { 10, 10, 10, 1, 35000m },
                    { 11, 11, 11, 1, 45000m },
                    { 12, 12, 12, 1, 22000m },
                    { 13, 13, 13, 1, 105000m },
                    { 14, 14, 14, 1, 42000m },
                    { 15, 15, 15, 1, 25000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 15);
        }
    }
}
