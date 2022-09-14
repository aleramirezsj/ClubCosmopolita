using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubCosmopolita.Migrations
{
    public partial class NuevoInicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Horarios = table.Column<string>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cobradores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido_Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido_Nombre = table.Column<string>(nullable: false),
                    Dirección = table.Column<string>(nullable: true),
                    Teléfono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    User = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuotas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(nullable: false),
                    Año = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Cobrada = table.Column<bool>(nullable: false),
                    Vencimiento = table.Column<DateTime>(nullable: false),
                    SocioId = table.Column<int>(nullable: false),
                    ActividadId = table.Column<int>(nullable: false),
                    CobradorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuotas_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuotas_Cobradores_CobradorId",
                        column: x => x.CobradorId,
                        principalTable: "Cobradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuotas_Socios_SocioId",
                        column: x => x.SocioId,
                        principalTable: "Socios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actividades",
                columns: new[] { "Id", "Costo", "Horarios", "Nombre" },
                values: new object[,]
                {
                    { 1, 2000m, "Martes y Jueves 20hs", "Folklore" },
                    { 2, 2500m, "Lunes y miércoles 15:00hs2", "Telas" }
                });

            migrationBuilder.InsertData(
                table: "Cobradores",
                columns: new[] { "Id", "Apellido_Nombre" },
                values: new object[,]
                {
                    { 1, "Juárez, Tomás" },
                    { 2, "Acevedo, Lautaro" }
                });

            migrationBuilder.InsertData(
                table: "Socios",
                columns: new[] { "Id", "Apellido_Nombre", "Dirección", "Teléfono" },
                values: new object[,]
                {
                    { 1, "Acevedo Lautaro", "San Justo", "3498345345" },
                    { 2, "Lescano Marcos", "San Justo", "3498324870" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nombre", "Password", "TipoUsuario", "User" },
                values: new object[] { 1, "Adminitrador", "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3", 2, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_ActividadId",
                table: "Cuotas",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_CobradorId",
                table: "Cuotas",
                column: "CobradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuotas_SocioId",
                table: "Cuotas",
                column: "SocioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuotas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Cobradores");

            migrationBuilder.DropTable(
                name: "Socios");
        }
    }
}
