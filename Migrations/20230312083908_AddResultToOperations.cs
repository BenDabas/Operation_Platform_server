using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Operation_Platform.Migrations
{
    public partial class AddResultToOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Operations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 10, 39, 8, 10, DateTimeKind.Local).AddTicks(6707));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Operations");

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 11, 14, 18, 8, 759, DateTimeKind.Local).AddTicks(6514));
        }
    }
}
