using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VentilacionAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistroVentilacion",
                columns: table => new
                {
                    RegistroVentilacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroVentilacion", x => x.RegistroVentilacionId);
                });

            migrationBuilder.CreateTable(
                name: "Sede",
                columns: table => new
                {
                    SedeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sede", x => x.SedeId);
                });

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    HabitacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Ancho = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Alto = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Largo = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    SedeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.HabitacionId);
                    table.ForeignKey(
                        name: "FK_Habitacion_Sede_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sede",
                        principalColumn: "SedeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrificioVentilacion",
                columns: table => new
                {
                    OrificioVentilacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Ubicacion = table.Column<string>(type: "varchar(50)", nullable: true),
                    Ancho = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Alto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AreaTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HabitacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrificioVentilacion", x => x.OrificioVentilacionId);
                    table.ForeignKey(
                        name: "FK_OrificioVentilacion_Habitacion_HabitacionId",
                        column: x => x.HabitacionId,
                        principalTable: "Habitacion",
                        principalColumn: "HabitacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlujoAire",
                columns: table => new
                {
                    FlujoAireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    OrificioVentilacionId = table.Column<int>(type: "int", nullable: false),
                    RegistroVentilacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlujoAire", x => x.FlujoAireId);
                    table.ForeignKey(
                        name: "FK_FlujoAire_OrificioVentilacion_OrificioVentilacionId",
                        column: x => x.OrificioVentilacionId,
                        principalTable: "OrificioVentilacion",
                        principalColumn: "OrificioVentilacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlujoAire_RegistroVentilacion_RegistroVentilacionId",
                        column: x => x.RegistroVentilacionId,
                        principalTable: "RegistroVentilacion",
                        principalColumn: "RegistroVentilacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlujoAire_OrificioVentilacionId",
                table: "FlujoAire",
                column: "OrificioVentilacionId");

            migrationBuilder.CreateIndex(
                name: "IX_FlujoAire_RegistroVentilacionId",
                table: "FlujoAire",
                column: "RegistroVentilacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitacion_SedeId",
                table: "Habitacion",
                column: "SedeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrificioVentilacion_HabitacionId",
                table: "OrificioVentilacion",
                column: "HabitacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlujoAire");

            migrationBuilder.DropTable(
                name: "OrificioVentilacion");

            migrationBuilder.DropTable(
                name: "RegistroVentilacion");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "Sede");
        }
    }
}
