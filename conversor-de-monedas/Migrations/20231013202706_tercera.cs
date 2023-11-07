using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conversor_de_monedas.Migrations
{
    /// <inheritdoc />
    public partial class tercera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversion_Users_IdUser",
                table: "Conversion");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Conversion");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "Conversion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Conversion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IdUser", "fecha" },
                values: new object[] { 1, new DateTime(2023, 10, 13, 17, 27, 6, 529, DateTimeKind.Local).AddTicks(801) });

            migrationBuilder.AddForeignKey(
                name: "FK_Conversion_Users_IdUser",
                table: "Conversion",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversion_Users_IdUser",
                table: "Conversion");

            migrationBuilder.AlterColumn<int>(
                name: "IdUser",
                table: "Conversion",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Conversion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Conversion",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IdUser", "UserId", "fecha" },
                values: new object[] { null, 1, new DateTime(2023, 10, 13, 17, 24, 40, 856, DateTimeKind.Local).AddTicks(5672) });

            migrationBuilder.AddForeignKey(
                name: "FK_Conversion_Users_IdUser",
                table: "Conversion",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
