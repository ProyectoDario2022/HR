using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.API.Migrations
{
    public partial class tablas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_Numero",
                table: "Reclamos",
                column: "Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Document",
                table: "AspNetUsers",
                column: "Document",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reclamos_Numero",
                table: "Reclamos");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Document",
                table: "AspNetUsers");
        }
    }
}
