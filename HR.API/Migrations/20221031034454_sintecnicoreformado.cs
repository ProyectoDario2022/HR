using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.API.Migrations
{
    public partial class sintecnicoreformado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reclamoTecnicos_AspNetUsers_TecnicoId1",
                table: "reclamoTecnicos");

            migrationBuilder.DropIndex(
                name: "IX_reclamoTecnicos_TecnicoId1",
                table: "reclamoTecnicos");

            migrationBuilder.DropColumn(
                name: "TecnicoId1",
                table: "reclamoTecnicos");

            migrationBuilder.RenameColumn(
                name: "TecnicoId",
                table: "reclamoTecnicos",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "reclamoTecnicos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reclamoTecnicos_UserId1",
                table: "reclamoTecnicos",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_reclamoTecnicos_AspNetUsers_UserId1",
                table: "reclamoTecnicos",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reclamoTecnicos_AspNetUsers_UserId1",
                table: "reclamoTecnicos");

            migrationBuilder.DropIndex(
                name: "IX_reclamoTecnicos_UserId1",
                table: "reclamoTecnicos");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "reclamoTecnicos");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "reclamoTecnicos",
                newName: "TecnicoId");

            migrationBuilder.AddColumn<string>(
                name: "TecnicoId1",
                table: "reclamoTecnicos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_reclamoTecnicos_TecnicoId1",
                table: "reclamoTecnicos",
                column: "TecnicoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_reclamoTecnicos_AspNetUsers_TecnicoId1",
                table: "reclamoTecnicos",
                column: "TecnicoId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
