using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOTPExpiration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0add298a-7885-4bdc-a3e9-bd458af2216f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "143c4dde-de36-4cb0-9470-daea9cfc0605");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1699397a-1406-4285-bed1-4f3f6dd45fb1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "264a27c6-8b18-452d-af24-49208315d2f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26aa8d64-6a11-4676-b62e-8ae3bf70fcca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "336bb7c3-4511-4f1c-af52-3060cc53fc32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b1bb6d5-8d3f-4fd6-9836-0433a7164dbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d64b6db-7d0e-4fa4-adb2-1e169ecb23c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54077d26-601c-459d-a35f-70568824e23f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6685bf0a-9a3f-4c38-b35d-4ff801149971");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69f4c7e3-3718-4ddb-a892-a435e009a065");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75bc483b-ce38-4d4c-83ec-741cb88ca41c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89bbd946-fe9c-4bb6-8858-e56bc758ecbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a20ef9e-8c71-4abf-8055-e6af97f86286");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "962519aa-5f18-4c72-8617-5beebffff6a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abd1d3e0-5ca1-442a-b49f-b468fb2153c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7ca6e18-b684-4c9d-ad81-2360c42844ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9d9cd23-6768-41d0-b92f-0a27d5adf8ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb935858-f5d8-435f-8306-398b4f589308");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc974da8-8d20-46fa-8ba2-8dd04289ff3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2baaa05-6b3c-4f9e-89ae-ad6999b927ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9ff2012-714e-4450-b554-b6ce6f884a9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd3562f1-173e-41e8-af38-ca9dbb0b9c81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "deed1365-7db2-4e33-974f-a17bf066c987");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df27a56c-7b7c-4042-9f91-396665180960");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e06e8c80-0b7d-4253-85bd-fa4063846f90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2bb3df9-4e9e-4bc0-b99f-2fa739d09934");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbd700a8-3345-49e2-82bd-11d5af216dc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd929c43-0673-4281-95a3-be7db745de1a");

            migrationBuilder.AddColumn<int>(
                name: "OTPUsageCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "OTPUsageCount",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0add298a-7885-4bdc-a3e9-bd458af2216f", null, "Hotel-Supervisor", "HOTEL-SUPERVISOR" },
                    { "143c4dde-de36-4cb0-9470-daea9cfc0605", null, "Notification-Supervisor", "NOTIFICATION-SUPERVISOR" },
                    { "1699397a-1406-4285-bed1-4f3f6dd45fb1", null, "Gallery-Supervisor", "GALLERY-SUPERVISOR" },
                    { "264a27c6-8b18-452d-af24-49208315d2f4", null, "Authntication-Manager", "AUTHNTICATION-MANAGER" },
                    { "26aa8d64-6a11-4676-b62e-8ae3bf70fcca", null, "Offer-Manager", "OFFER-MANAGER" },
                    { "336bb7c3-4511-4f1c-af52-3060cc53fc32", null, "Offer-Officer", "OFFER-OFFICER" },
                    { "3b1bb6d5-8d3f-4fd6-9836-0433a7164dbd", null, "Hotel-Admin", "HOTEL-ADMIN" },
                    { "4d64b6db-7d0e-4fa4-adb2-1e169ecb23c2", null, "CMS-Officer", "CMS-OFFICER" },
                    { "54077d26-601c-459d-a35f-70568824e23f", null, "SuperAdmin", "SUPERADMIN" },
                    { "6685bf0a-9a3f-4c38-b35d-4ff801149971", null, "CWCore-Supervisor", "CWCORE-SUPERVISOR" },
                    { "69f4c7e3-3718-4ddb-a892-a435e009a065", null, "CMS-Admin", "CMS-ADMIN" },
                    { "75bc483b-ce38-4d4c-83ec-741cb88ca41c", null, "CMS-Manager", "CMS-MANAGER" },
                    { "89bbd946-fe9c-4bb6-8858-e56bc758ecbf", null, "Gallery-Officer", "GALLERY-OFFICER" },
                    { "8a20ef9e-8c71-4abf-8055-e6af97f86286", null, "Hotel-Manager", "HOTEL-MANAGER" },
                    { "962519aa-5f18-4c72-8617-5beebffff6a7", null, "Offer-Admin", "OFFER-ADMIN" },
                    { "abd1d3e0-5ca1-442a-b49f-b468fb2153c5", null, "Hotel-Officer", "HOTEL-OFFICER" },
                    { "b7ca6e18-b684-4c9d-ad81-2360c42844ea", null, "Notification-Officer", "NOTIFICATION-OFFICER" },
                    { "c9d9cd23-6768-41d0-b92f-0a27d5adf8ed", null, "CMS-Supervisor", "CMS-SUPERVISOR" },
                    { "cb935858-f5d8-435f-8306-398b4f589308", null, "CWCore-Manager", "CWCORE-MANAGER" },
                    { "cc974da8-8d20-46fa-8ba2-8dd04289ff3b", null, "Offer-Supervisor", "OFFER-SUPERVISOR" },
                    { "d2baaa05-6b3c-4f9e-89ae-ad6999b927ea", null, "CWCore-Admin", "CWCORE-ADMIN" },
                    { "d9ff2012-714e-4450-b554-b6ce6f884a9b", null, "Authntication-Officer", "AUTHNTICATION-OFFICER" },
                    { "dd3562f1-173e-41e8-af38-ca9dbb0b9c81", null, "Authntication-Supervisor", "AUTHNTICATION-SUPERVISOR" },
                    { "deed1365-7db2-4e33-974f-a17bf066c987", null, "Notification-Manager", "NOTIFICATION-MANAGER" },
                    { "df27a56c-7b7c-4042-9f91-396665180960", null, "Gallery-Admin", "GALLERY-ADMIN" },
                    { "e06e8c80-0b7d-4253-85bd-fa4063846f90", null, "Notification-Admin", "NOTIFICATION-ADMIN" },
                    { "e2bb3df9-4e9e-4bc0-b99f-2fa739d09934", null, "Authntication-Admin", "AUTHNTICATION-ADMIN" },
                    { "fbd700a8-3345-49e2-82bd-11d5af216dc0", null, "Gallery-Manager", "GALLERY-MANAGER" },
                    { "fd929c43-0673-4281-95a3-be7db745de1a", null, "CWCore-Officer", "CWCORE-OFFICER" }
                });
        }
    }
}
