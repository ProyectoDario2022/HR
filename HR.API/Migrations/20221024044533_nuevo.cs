using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.API.Migrations
{
    public partial class nuevo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleTypes",
                table: "VehicleTypes");

            migrationBuilder.RenameTable(
                name: "VehicleTypes",
                newName: "ReclamoTypes");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleTypes_Descripcion",
                table: "ReclamoTypes",
                newName: "IX_ReclamoTypes_Descripcion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReclamoTypes",
                table: "ReclamoTypes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReclamoTypes",
                table: "ReclamoTypes");

            migrationBuilder.RenameTable(
                name: "ReclamoTypes",
                newName: "VehicleTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ReclamoTypes_Descripcion",
                table: "VehicleTypes",
                newName: "IX_VehicleTypes_Descripcion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleTypes",
                table: "VehicleTypes",
                column: "Id");
        }
    }
}
