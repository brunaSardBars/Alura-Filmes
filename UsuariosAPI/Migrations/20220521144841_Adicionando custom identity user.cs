using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "4e1b388a-a19d-4660-9b90-fd375527378c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "2f010b45-6944-4d3b-8a1f-07fbf1cf6c38");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d6a272d-5af7-4bd0-bde5-b96477424df4", "AQAAAAEAACcQAAAAEB6glymF4vbcIED+APCdseUDbQvMk9nObcqtOkb+AX5sR0N6nf2T92NlpXe3A57GYQ==", "ad28920c-aa3a-49ca-8192-b55c6137f09b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "c4251edb-e53f-4571-aaa3-e9a7a024a3b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "240f5c77-0d9d-4ba4-9990-0049753e9c51");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "345308e0-dfb2-4bfb-ba06-3d75730195f6", "AQAAAAEAACcQAAAAEM9rz03DKCbiEC3fqHzUWCQclFpn4jsQrexAykf7AwfeHtceytaL3vuyDHvY2uHaEw==", "b39f68bc-518c-4fe9-960e-c32fa7adbfbb" });
        }
    }
}
