using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.API.Migrations
{
    public partial class seedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "16d8a596-5386-4fed-ad59-6fd3e0d3ace1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b002848-a4df-4946-8744-9a4825d93eef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72630415-260e-4d69-a055-7aaab671c46b");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Direccion", "Document", "Email", "EmailConfirmed", "FirstName", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { "16d8a596-5386-4fed-ad59-6fd3e0d3ace1", 0, "a0d39363-e241-438e-a85c-43116071bcc2", "Entre rios 10", "22890345", "prueba1@gmail.com", false, "Dario", new Guid("00000000-0000-0000-0000-000000000000"), "Paez", false, null, null, null, null, "11111111", false, "bce06cae-d8b3-4cdc-8c05-9db2c6676e99", false, "prueba1@gmail.com", 0 },
                    { "3b002848-a4df-4946-8744-9a4825d93eef", 0, "2847aef5-71f6-4a43-a39b-44e03a1dc6f8", "callao 1", "22890456", "prueba2@gmail.com", false, "Eze", new Guid("00000000-0000-0000-0000-000000000000"), "Anchorena", false, null, null, null, null, "11111111", false, "51a5de8d-2780-41fe-a172-8429e512d98a", false, "prueba2@gmail.com", 0 },
                    { "72630415-260e-4d69-a055-7aaab671c46b", 0, "4a890a1c-b462-48e5-897a-7274498d588f", "callao 1", "22890456", "prueba3@gmail.com", false, "Maximiliano", new Guid("00000000-0000-0000-0000-000000000000"), "Dominguez", false, null, null, null, null, "11111111", false, "c1be2f4c-e7b9-4c74-868a-7415506eedb4", false, "prueba3@gmail.com", 1 }
                });

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
    }
}
