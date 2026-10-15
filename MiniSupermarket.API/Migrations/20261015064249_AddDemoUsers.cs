using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class AddDemoUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "IsActive", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Nguyễn Quản Trị", true, "AQAAAAIAAYagAAAAEDDOau1e/TNb5HtRYT5Bel2ux0rbg1C/1zUz6Yf1tKwUe9e0BXF4WctkEpE0rOMiSQ==", "Admin", "admin01" },
                    { 2, "Trần Giám Đốc", true, "AQAAAAIAAYagAAAAECP0HPtOD3EvVOW5Cr2eI1hph/bYUlnrjBVbfKeal+DUB2VDfeUlUpsi8pVoR0IDwg==", "Admin", "admin02" },
                    { 3, "Lê Thu Ngân", true, "AQAAAAIAAYagAAAAEArao3xpCUQQb/nE1IVQ8/muDFovXioNH951+AMDwx+dxinGeX/LYQ50XjkxcyVkpg==", "Cashier", "cashier01" },
                    { 4, "Phạm Bán Hàng", true, "AQAAAAIAAYagAAAAEJAH6jfy5yksvHNonzH8NqwxBVsaxCyUu5uIQfD+61W9kbJTxO0KFTmO+She27HoCw==", "Cashier", "cashier02" },
                    { 5, "Hoàng Thu Ngân", true, "AQAAAAIAAYagAAAAEEaqJx2tg+YIXmWNlHo+w+EtLrYxfOCW+BJ9AULoxbQhS1MNr+HY5Y7ben0NIOlWBQ==", "Cashier", "cashier03" },
                    { 6, "Vũ Thị Quầy", true, "AQAAAAIAAYagAAAAEH8M8+MqOYTDzQD6LSYPKYLVCS1vaJLpHGmghXvXDOGCIHBhdqOr2hej4qvUoDIp/A==", "Cashier", "cashier04" },
                    { 7, "Đỗ Bán Lẻ", true, "AQAAAAIAAYagAAAAEBvO0tw+UxxhMqg5YYNL+8uyjMgYTXjy3nVR+NZ9U6bHMTTM0e4UzeIwmFgsyqio6w==", "Cashier", "cashier05" },
                    { 8, "Ngô Quản Kho", true, "AQAAAAIAAYagAAAAEMtMXHePKh5Yuv0KDzR/8kROf2Ev8cp9DDK55qR2+cjeDO0g0eDFUO8q3upav9InGQ==", "Warehouse", "ware01" },
                    { 9, "Bùi Kiểm Kê", true, "AQAAAAIAAYagAAAAEJ6yHZfUme9NIbQWqnFXS9XdPCB0fjH2PuKLlaXC36798MNs4ZzKmFs17iyBVsDL+g==", "Warehouse", "ware02" },
                    { 10, "Dương Thủ Kho", true, "AQAAAAIAAYagAAAAEOpYEYkBObOJGSlS6Ke2qaHWkmum9o5XMD4LgwuQB378qgKur0iW4WbKPVU+akAENw==", "Warehouse", "ware03" },
                    { 11, "Lý Nhập Hàng", true, "AQAAAAIAAYagAAAAEMYhI00C/Y87m/FCUEFbi7CkqUulnE0r/5ZfF6d2KdpWgKM7P848nM1pBt+Kdppcjg==", "Warehouse", "ware04" },
                    { 12, "Đặng Hỗ Trợ", true, "AQAAAAIAAYagAAAAEMecWZoCuZ/qtuY+bOb196w65JWFIQ7wbJN+dW3wCxTuhT4miDuXU9YrORy0XMuSbA==", "Admin", "admin_backup" },
                    { 13, "Hồ Ca Chiều", true, "AQAAAAIAAYagAAAAEBZ3WqEzT9A9MGgVUfykCFv2H6GpDE0lQn7rU6V8RblsuhR+VR8rkWyFMK2agCA5xw==", "Cashier", "cashier06" },
                    { 14, "Trương Vận Chuyển", true, "AQAAAAIAAYagAAAAEPXG0UgSH0nAlITHo68I7wYA91aBjemTylYa1lJoFxojtVwUzAtGq2FOHMiLzSp2mw==", "Warehouse", "ware05" },
                    { 15, "Mai Giám Sát", true, "AQAAAAIAAYagAAAAEGZ02xEWKMLXXxYQjUSQkySWoIMJqYALzQFCAot+1X7cVsH9hMVSeGHcoP66Uo/Z0Q==", "Admin", "supervisor" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
