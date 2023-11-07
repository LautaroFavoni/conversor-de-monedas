using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conversor_de_monedas.Migrations
{
    /// <inheritdoc />
    public partial class tres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Conversion",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha",
                value: new DateTime(2023, 10, 20, 18, 40, 55, 663, DateTimeKind.Local).AddTicks(2992));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Conversion",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha",
                value: new DateTime(2023, 10, 17, 16, 50, 47, 15, DateTimeKind.Local).AddTicks(9149));
        }
    }
}
