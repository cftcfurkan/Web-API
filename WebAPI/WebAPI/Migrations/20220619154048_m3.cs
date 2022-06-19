using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Name", "Price", "Stock" },
                values: new object[] { 1, new DateTime(2022, 6, 18, 18, 40, 48, 89, DateTimeKind.Local).AddTicks(9944), "Bilgisayar", 1000m, 500 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Name", "Price", "Stock" },
                values: new object[] { 2, new DateTime(2022, 6, 17, 18, 40, 48, 89, DateTimeKind.Local).AddTicks(9957), "Telefon", 1800m, 700 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Name", "Price", "Stock" },
                values: new object[] { 3, new DateTime(2022, 6, 15, 18, 40, 48, 89, DateTimeKind.Local).AddTicks(9958), "Klavye", 200m, 300 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
