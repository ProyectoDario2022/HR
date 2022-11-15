using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.API.Migrations
{
    public partial class Reclamo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamos_Abonados_AbonadoId",
                table: "Reclamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamos_Materiales_MaterialId",
                table: "Reclamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamos_ReclamoTypes_TipoId",
                table: "Reclamos");

            migrationBuilder.DropIndex(
                name: "IX_Reclamos_MaterialId",
                table: "Reclamos");

            migrationBuilder.DropIndex(
                name: "IX_Reclamos_TipoId",
                table: "Reclamos");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Reclamos");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "Reclamos");

            migrationBuilder.AlterColumn<string>(
                name: "Resolucion",
                table: "Reclamos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observaciones",
                table: "Reclamos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HSalida",
                table: "Reclamos",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HLlegada",
                table: "Reclamos",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Reclamos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AbonadoId",
                table: "Reclamos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoReclamoId",
                table: "Reclamos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_TipoReclamoId",
                table: "Reclamos",
                column: "TipoReclamoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamos_Abonados_AbonadoId",
                table: "Reclamos",
                column: "AbonadoId",
                principalTable: "Abonados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamos_ReclamoTypes_TipoReclamoId",
                table: "Reclamos",
                column: "TipoReclamoId",
                principalTable: "ReclamoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reclamos_Abonados_AbonadoId",
                table: "Reclamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reclamos_ReclamoTypes_TipoReclamoId",
                table: "Reclamos");

            migrationBuilder.DropIndex(
                name: "IX_Reclamos_TipoReclamoId",
                table: "Reclamos");

            migrationBuilder.DropColumn(
                name: "TipoReclamoId",
                table: "Reclamos");

            migrationBuilder.AlterColumn<string>(
                name: "Resolucion",
                table: "Reclamos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Observaciones",
                table: "Reclamos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HSalida",
                table: "Reclamos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HLlegada",
                table: "Reclamos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Reclamos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "AbonadoId",
                table: "Reclamos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Reclamos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "Reclamos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_MaterialId",
                table: "Reclamos",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamos_TipoId",
                table: "Reclamos",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamos_Abonados_AbonadoId",
                table: "Reclamos",
                column: "AbonadoId",
                principalTable: "Abonados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamos_Materiales_MaterialId",
                table: "Reclamos",
                column: "MaterialId",
                principalTable: "Materiales",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reclamos_ReclamoTypes_TipoId",
                table: "Reclamos",
                column: "TipoId",
                principalTable: "ReclamoTypes",
                principalColumn: "Id");
        }
    }
}
