using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace conversor_de_monedas.Migrations
{
    /// <inheritdoc />
    public partial class cuarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Conversion",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha",
                value: new DateTime(2023, 10, 20, 19, 14, 1, 754, DateTimeKind.Local).AddTicks(967));

            migrationBuilder.InsertData(
                table: "Monedas",
                columns: new[] { "Id", "Name", "Sigla", "valor" },
                values: new object[,]
                {
                    { 3, "Euro", "EUR", 1.0900000000000001 },
                    { 4, "Corona Checa", "KC", 0.042999999999999997 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Conversion",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha",
                value: new DateTime(2023, 10, 20, 19, 11, 25, 228, DateTimeKind.Local).AddTicks(2888));
        }
    }
}
