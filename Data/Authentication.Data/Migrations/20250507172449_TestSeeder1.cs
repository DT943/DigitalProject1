using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Data.Migrations
{
    /// <inheritdoc />
    public partial class TestSeeder1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "004c55fd-17a3-475d-a2d1-b6f3c2d2aa45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04a9d0fa-88b8-4fc1-8191-8fd1d158fef1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b6a2533-b1ba-4c3d-8c3e-c266b96bdf60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c73c65-d456-4f1d-b6fb-221cf7b0f845");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21fca9ec-dc2d-4b02-a97d-68e3d6833a72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2730ff2d-b692-4709-a359-5af4d126889a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2aec0c0a-c944-48a1-80b7-3cc0d02c5792");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35a73b33-b411-4e64-b33d-9a701f1d1249");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43c949ce-d542-4593-bbd8-e6db4860dbe9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6858ff26-8221-4e87-b4f1-2be95f2c9178");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b5d0d25-ba0e-49e1-81be-db82294963f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cdc97e5-0756-469a-b2b6-8aa486000ba4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75498e2c-1179-40ef-a345-ac0ce7e32006");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75ed5081-4935-4a74-ac85-df86f85dfc30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "863bb6c2-2478-4087-bb61-5ddad54cfce0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "90e34370-453c-43e7-9889-e792e1e84cfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c9aaf9f-93af-40fa-9e84-a09207e9a7e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1b44e4e-4603-46d9-ae97-dbe8fdbb7826");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a38490c4-5554-4bb6-9fc0-7d1451748a0f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6898a2e-6d60-464d-9141-1f27647c3b68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b77ad806-fd41-47de-b532-8ab7f5f5140d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8114531-dba8-4522-9604-9e366397eb67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5f0093a-1983-450c-9748-b5c2d7b5725e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8c6e654-7bc5-43f5-b139-1ea820c2d45c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ded25add-d400-452a-bacb-24463a19ee6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e05f7042-26d2-4a89-af81-ab244c9161ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e58d5da7-fdb8-41c0-a74d-9b9ed1ec434d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f175c7de-6fdb-4fa9-8fec-08bdabab7a4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8c42226-57fb-4c26-8f84-7f3fa22a7d3a");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "004c55fd-17a3-475d-a2d1-b6f3c2d2aa45", null, "Notification-Manager", "NOTIFICATION-MANAGER" },
                    { "04a9d0fa-88b8-4fc1-8191-8fd1d158fef1", null, "CWCore-Admin", "CWCORE-ADMIN" },
                    { "0b6a2533-b1ba-4c3d-8c3e-c266b96bdf60", null, "CWCore-Manager", "CWCORE-MANAGER" },
                    { "18c73c65-d456-4f1d-b6fb-221cf7b0f845", null, "CWCore-Officer", "CWCORE-OFFICER" },
                    { "21fca9ec-dc2d-4b02-a97d-68e3d6833a72", null, "Gallery-Officer", "GALLERY-OFFICER" },
                    { "2730ff2d-b692-4709-a359-5af4d126889a", null, "Hotel-Supervisor", "HOTEL-SUPERVISOR" },
                    { "2aec0c0a-c944-48a1-80b7-3cc0d02c5792", null, "Notification-Admin", "NOTIFICATION-ADMIN" },
                    { "35a73b33-b411-4e64-b33d-9a701f1d1249", null, "CMS-Admin", "CMS-ADMIN" },
                    { "43c949ce-d542-4593-bbd8-e6db4860dbe9", null, "Offer-Admin", "OFFER-ADMIN" },
                    { "6858ff26-8221-4e87-b4f1-2be95f2c9178", null, "Gallery-Admin", "GALLERY-ADMIN" },
                    { "6b5d0d25-ba0e-49e1-81be-db82294963f5", null, "CMS-Supervisor", "CMS-SUPERVISOR" },
                    { "6cdc97e5-0756-469a-b2b6-8aa486000ba4", null, "CMS-Officer", "CMS-OFFICER" },
                    { "75498e2c-1179-40ef-a345-ac0ce7e32006", null, "Authentication-Supervisor", "AUTHENTICATION-SUPERVISOR" },
                    { "75ed5081-4935-4a74-ac85-df86f85dfc30", null, "Hotel-Manager", "HOTEL-MANAGER" },
                    { "863bb6c2-2478-4087-bb61-5ddad54cfce0", null, "Notification-Officer", "NOTIFICATION-OFFICER" },
                    { "90e34370-453c-43e7-9889-e792e1e84cfb", null, "Offer-Supervisor", "OFFER-SUPERVISOR" },
                    { "9c9aaf9f-93af-40fa-9e84-a09207e9a7e0", null, "Gallery-Manager", "GALLERY-MANAGER" },
                    { "a1b44e4e-4603-46d9-ae97-dbe8fdbb7826", null, "CMS-Manager", "CMS-MANAGER" },
                    { "a38490c4-5554-4bb6-9fc0-7d1451748a0f", null, "Authentication-Officer", "AUTHENTICATION-OFFICER" },
                    { "a6898a2e-6d60-464d-9141-1f27647c3b68", null, "Authentication-Manager", "AUTHENTICATION-MANAGER" },
                    { "b77ad806-fd41-47de-b532-8ab7f5f5140d", null, "SuperAdmin", "SUPERADMIN" },
                    { "b8114531-dba8-4522-9604-9e366397eb67", null, "Authentication-Admin", "AUTHENTICATION-ADMIN" },
                    { "c5f0093a-1983-450c-9748-b5c2d7b5725e", null, "Hotel-Officer", "HOTEL-OFFICER" },
                    { "d8c6e654-7bc5-43f5-b139-1ea820c2d45c", null, "Offer-Officer", "OFFER-OFFICER" },
                    { "ded25add-d400-452a-bacb-24463a19ee6b", null, "Offer-Manager", "OFFER-MANAGER" },
                    { "e05f7042-26d2-4a89-af81-ab244c9161ea", null, "Hotel-Admin", "HOTEL-ADMIN" },
                    { "e58d5da7-fdb8-41c0-a74d-9b9ed1ec434d", null, "Notification-Supervisor", "NOTIFICATION-SUPERVISOR" },
                    { "f175c7de-6fdb-4fa9-8fec-08bdabab7a4e", null, "CWCore-Supervisor", "CWCORE-SUPERVISOR" },
                    { "f8c42226-57fb-4c26-8f84-7f3fa22a7d3a", null, "Gallery-Supervisor", "GALLERY-SUPERVISOR" }
                });
        }
    }
}
