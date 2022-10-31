using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.API.Migrations
{
    public partial class sintecnico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reclamoTecnicos_AspNetUsers_TecnicoId1",
                table: "reclamoTecnicos");

            migrationBuilder.AlterColumn<string>(
                name: "TecnicoId1",
                table: "reclamoTecnicos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reclamoTecnicos_AspNetUsers_TecnicoId1",
                table: "reclamoTecnicos",
                column: "TecnicoId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reclamoTecnicos_AspNetUsers_TecnicoId1",
                table: "reclamoTecnicos");

            migrationBuilder.AlterColumn<string>(
                name: "TecnicoId1",
                table: "reclamoTecnicos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_reclamoTecnicos_AspNetUsers_TecnicoId1",
                table: "reclamoTecnicos",
                column: "TecnicoId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
