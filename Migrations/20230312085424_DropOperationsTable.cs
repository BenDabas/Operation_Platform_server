using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Operation_Platform.Migrations
{
    public partial class DropOperationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Operations");

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 10, 54, 23, 720, DateTimeKind.Local).AddTicks(6932));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 12, 10, 39, 8, 10, DateTimeKind.Local).AddTicks(6707));

            migrationBuilder.CreateTable(
            name: "Operations",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstField = table.Column<string>(nullable: true),
                SecondField = table.Column<string>(nullable: true),
                Operator = table.Column<string>(nullable: true),
                DateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                Result = table.Column<string>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Operations", x => x.Id);
            });
                }
    }
}
