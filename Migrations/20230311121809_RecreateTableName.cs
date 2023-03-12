using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Operation_Platform.Migrations
{
    public partial class RecreateTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Operations",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                FirstField = table.Column<string>(nullable: true),
                SecondField = table.Column<string>(nullable: true),
                Operator = table.Column<string>(nullable: true),
                DateTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Operations", x => x.Id);
            });

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 11, 14, 18, 8, 759, DateTimeKind.Local).AddTicks(6514));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2023, 3, 11, 14, 17, 15, 729, DateTimeKind.Local).AddTicks(5861));
        }
    }
}
