using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conversor_de_monedas.Migrations
{
    /// <inheritdoc />
    public partial class agregarRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Conversion",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha",
                value: new DateTime(2023, 11, 28, 16, 18, 1, 540, DateTimeKind.Local).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: "ADMIN");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: "Free");

            migrationBuilder.UpdateData(
                table: "suscripciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "TirosMax",
                value: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Conversion",
                keyColumn: "Id",
                keyValue: 1,
                column: "fecha",
                value: new DateTime(2023, 10, 20, 19, 14, 1, 754, DateTimeKind.Local).AddTicks(967));

            migrationBuilder.UpdateData(
                table: "suscripciones",
                keyColumn: "Id",
                keyValue: 2,
                column: "TirosMax",
                value: 9999);
        }
    }
}
