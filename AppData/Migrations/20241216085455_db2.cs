using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "phuongthucthanhtoans",
                columns: new[] { "Id", "Tenpttt", "Trangthai" },
                values: new object[] { 1, "Thanh toán khi nhận hàng (COD - Cash on Delivery)", 0 });

            migrationBuilder.InsertData(
                table: "phuongthucthanhtoans",
                columns: new[] { "Id", "Tenpttt", "Trangthai" },
                values: new object[] { 2, "Chuyển khoản ngân hàng", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "phuongthucthanhtoans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "phuongthucthanhtoans",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
