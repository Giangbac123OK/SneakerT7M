using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class HungUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Ngaygiaodukien",
                table: "hoadons",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Diemsudung",
                table: "hoadons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Tiencoc",
                table: "hoadons",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Soluong",
                table: "giamgias",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diemsudung",
                table: "hoadons");

            migrationBuilder.DropColumn(
                name: "Tiencoc",
                table: "hoadons");

            migrationBuilder.DropColumn(
                name: "Soluong",
                table: "giamgias");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Ngaygiaodukien",
                table: "hoadons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
