using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.API.Migrations
{
    public partial class datanew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Funciones",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Instalador" },
                    { 2, "Service" },
                    { 3, "Red" }
                });

            migrationBuilder.InsertData(
                table: "Materiales",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 1, "Conector RG59", "RG 59" });

            migrationBuilder.InsertData(
                table: "ReclamoTypes",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Instalacion" },
                    { 2, "Service" },
                    { 3, "Red" },
                    { 4, "Reinstalacion" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funciones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Funciones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Funciones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materiales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReclamoTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReclamoTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReclamoTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReclamoTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
