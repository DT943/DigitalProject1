using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Data.Migrations
{
    /// <inheritdoc />
    public partial class init_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13fa00c2-5f0d-427a-8a8a-b0d01d0b1f66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32b1bb5e-a23c-4161-95a9-3a8e7d17b7d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95a3f73f-bc21-49cd-b49e-032a435ec888");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e66d84c9-200c-4ea4-8b91-d39ab14c8b57");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e168f05-f689-4875-8918-68cdc7d9a325", null, "Customer", "CUSTOMER" },
                    { "95f928f8-ebb8-4beb-b759-283e01079497", null, "Driver", "DRIVER" },
                    { "9e1fe89a-77ac-411f-befa-7c69399dbb1e", null, "Admin", "ADMIN" },
                    { "b6aabc39-a78f-4aab-9f3a-d0041a101943", null, "CustomerService", "CUSTOMERSERVICE" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e168f05-f689-4875-8918-68cdc7d9a325");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95f928f8-ebb8-4beb-b759-283e01079497");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e1fe89a-77ac-411f-befa-7c69399dbb1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6aabc39-a78f-4aab-9f3a-d0041a101943");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13fa00c2-5f0d-427a-8a8a-b0d01d0b1f66", null, "Customer", "CUSTOMER" },
                    { "32b1bb5e-a23c-4161-95a9-3a8e7d17b7d7", null, "Driver", "DRIVER" },
                    { "95a3f73f-bc21-49cd-b49e-032a435ec888", null, "Admin", "ADMIN" },
                    { "e66d84c9-200c-4ea4-8b91-d39ab14c8b57", null, "CustomerService", "CUSTOMERSERVICE" }
                });
        }
    }
}
