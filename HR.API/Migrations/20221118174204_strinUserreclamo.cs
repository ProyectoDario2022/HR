﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.API.Migrations
{
    public partial class strinUserreclamo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "reclamoTecnicos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_reclamoTecnicos_UserId",
                table: "reclamoTecnicos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_reclamoTecnicos_AspNetUsers_UserId",
                table: "reclamoTecnicos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reclamoTecnicos_AspNetUsers_UserId",
                table: "reclamoTecnicos");

            migrationBuilder.DropIndex(
                name: "IX_reclamoTecnicos_UserId",
                table: "reclamoTecnicos");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "reclamoTecnicos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
