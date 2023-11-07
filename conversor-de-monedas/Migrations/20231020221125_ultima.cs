using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conversor_de_monedas.Migrations
{
    /// <inheritdoc />
    public partial class ultima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "valor",
                table: "Monedas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Conversion",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha",
                value: new DateTime(2023, 10, 20, 19, 11, 25, 228, DateTimeKind.Local).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 1,
                column: "valor",
                value: 0.002);

            migrationBuilder.UpdateData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 2,
                column: "valor",
                value: 1.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "valor",
                table: "Monedas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.UpdateData(
                table: "Conversion",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha",
                value: new DateTime(2023, 10, 20, 18, 40, 55, 663, DateTimeKind.Local).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 1,
                column: "valor",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Monedas",
                keyColumn: "Id",
                keyValue: 2,
                column: "valor",
                value: 1000);
        }
    }
}
