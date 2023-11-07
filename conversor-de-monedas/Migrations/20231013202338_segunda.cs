using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace conversor_de_monedas.Migrations
{
    /// <inheritdoc />
    public partial class segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMonedaOrigen = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMonedaDestino = table.Column<int>(type: "INTEGER", nullable: false),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversion_Monedas_IdMonedaDestino",
                        column: x => x.IdMonedaDestino,
                        principalTable: "Monedas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conversion_Monedas_IdMonedaOrigen",
                        column: x => x.IdMonedaOrigen,
                        principalTable: "Monedas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conversion_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Conversion",
                columns: new[] { "Id", "IdMonedaDestino", "IdMonedaOrigen", "IdUser", "UserId", "fecha" },
                values: new object[] { 1, 2, 1, null, 1, new DateTime(2023, 10, 13, 17, 23, 38, 508, DateTimeKind.Local).AddTicks(6798) });

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_IdMonedaDestino",
                table: "Conversion",
                column: "IdMonedaDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_IdMonedaOrigen",
                table: "Conversion",
                column: "IdMonedaOrigen");

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_IdUser",
                table: "Conversion",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversion");
        }
    }
}
