using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conversor_de_monedas.Migrations
{
    /// <inheritdoc />
    public partial class segunda2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Conversion",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha",
                value: new DateTime(2023, 10, 13, 17, 24, 32, 87, DateTimeKind.Local).AddTicks(6013));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Conversion",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha",
                value: new DateTime(2023, 10, 13, 17, 23, 38, 508, DateTimeKind.Local).AddTicks(6798));
        }
    }
}
