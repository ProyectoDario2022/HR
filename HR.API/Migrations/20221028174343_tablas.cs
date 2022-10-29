using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.API.Migrations
{
    public partial class tablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FuncionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Abonados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    DNI = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reclamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    TipoId = table.Column<int>(type: "int", nullable: true),
                    HLlegada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HSalida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resolucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbonadoId = table.Column<int>(type: "int", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reclamos_Abonados_AbonadoId",
                        column: x => x.AbonadoId,
                        principalTable: "Abonados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reclamos_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reclamos_ReclamoTypes_TipoId",
                        column: x => x.TipoId,
                        principalTable: "ReclamoTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReclamoMateriales",
                columns: table => new
                {
                    ReclamoId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    CantidadUsada = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReclamoMateriales", x => new { x.ReclamoId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_ReclamoMateriales_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReclamoMateriales_Reclamos_ReclamoId",
                        column: x => x.ReclamoId,
                        principalTable: "Reclamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reclamoTecnicos",
                columns: table => new
                {
                    ReclamoId = table.Column<int>(type: "int", nullable: false),
                    TecnicoId = table.Column<int>(type: "int", nullable: false),
                    TecnicoId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reclamoTecnicos", x => new { x.ReclamoId, x.TecnicoId });
                    table.ForeignKey(
                        name: "FK_reclamoTecnicos_AspNetUsers_TecnicoId1",
                        column: x => x.TecnicoId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_reclamoTecnicos_Reclamos_ReclamoId",
                        column: x => x.ReclamoId,
                        principalTable: "Reclamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FuncionId",
                table: "AspNetUsers",
                column: "FuncionId");

            migrationBuilder.CreateIndex(
                name: "IX_Abonados_Numero",
                table: "Abonados",
                column: "Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReclamoMateriales_MaterialId",
                table: "ReclamoMateriales",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_AbonadoId",
                table: "Reclamos",
                column: "AbonadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_MaterialId",
                table: "Reclamos",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_TipoId",
                table: "Reclamos",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_reclamoTecnicos_TecnicoId1",
                table: "reclamoTecnicos",
                column: "TecnicoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Funciones_FuncionId",
                table: "AspNetUsers",
                column: "FuncionId",
                principalTable: "Funciones",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Funciones_FuncionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ReclamoMateriales");

            migrationBuilder.DropTable(
                name: "reclamoTecnicos");

            migrationBuilder.DropTable(
                name: "Reclamos");

            migrationBuilder.DropTable(
                name: "Abonados");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FuncionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FuncionId",
                table: "AspNetUsers");
        }
    }
}
