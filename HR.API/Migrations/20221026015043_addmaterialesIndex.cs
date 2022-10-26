using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.API.Migrations
{
    public partial class addmaterialesIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Materiales_Descripcion",
                table: "Materiales");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_Nombre",
                table: "Materiales",
                column: "Nombre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Materiales_Nombre",
                table: "Materiales");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_Descripcion",
                table: "Materiales",
                column: "Descripcion",
                unique: true);
        }
    }
}
