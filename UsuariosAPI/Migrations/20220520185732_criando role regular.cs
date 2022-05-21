using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "240f5c77-0d9d-4ba4-9990-0049753e9c51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "c4251edb-e53f-4571-aaa3-e9a7a024a3b9", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "345308e0-dfb2-4bfb-ba06-3d75730195f6", "AQAAAAEAACcQAAAAEM9rz03DKCbiEC3fqHzUWCQclFpn4jsQrexAykf7AwfeHtceytaL3vuyDHvY2uHaEw==", "b39f68bc-518c-4fe9-960e-c32fa7adbfbb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "ca3db1c5-ab59-4b3e-ab93-2103b3e0dda1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07fba410-f2dd-4158-b059-15ff66094ee6", "AQAAAAEAACcQAAAAELARpq44SPiEdWAdZVq7r64jeLOn7taQ+oKW9eEb7flZT4YQxu5D+omVDzDA2rMfWw==", "24052501-35a3-4a79-9012-83a4df140061" });
        }
    }
}
