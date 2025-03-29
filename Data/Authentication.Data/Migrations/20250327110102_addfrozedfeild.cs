using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Data.Migrations
{
    /// <inheritdoc />
    public partial class addfrozedfeild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02537d6e-78af-4283-9c81-a4c3726938f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04440a0b-4715-421e-9abb-91c30dcd12c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b73d86f-0ff8-4ad9-ab58-ff52308dea1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21ddfca7-f0b9-4efb-8184-40090779c5b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29c666bf-a6bd-45b2-b4e5-c7edfe6cb98f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b10e3de-e565-4e5c-b120-73fb803bb096");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f3652c0-ba36-4cab-8e98-36a7e98a0dba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61b7da41-0984-4362-a68f-08bac6f39cf9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "652f9335-c834-48e7-8217-57c8365b36c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66fabd0d-c971-4d2d-835d-16599d205686");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d2ca768-a80a-4fa3-aad4-e3700266f579");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d7b724f-757c-4d83-b488-ef3ed8a55d9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c6edcae-811f-4f62-82c0-af6a9e7c95ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83209eeb-a604-4247-828d-18bd7788f52d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84d42ef8-8fa7-4785-acf0-d6c4970c6de7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89ad789d-5cc1-4fec-ac4b-a7b0455dce52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8db992f2-f87c-42e5-8f6a-162523d391e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9107aad7-31be-4313-8edf-9db675d53e13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94d41678-e74e-4719-974f-f654d33aa82d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f57ff5b-e9ea-41e5-9fd1-c0083ccc8b9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9c44bdf-9cd8-4a90-85bf-98b756444d5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc8a6b69-9e33-4edf-ab8a-7ec63f086ec7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf01eea4-c6be-4fe9-aad4-c3c3b5997560");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf255e6c-7d61-4b02-8872-c4efe62ea6af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2099570-c01b-4b56-b757-4c3091ea88d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7fa8752-fcbe-474f-8f7f-ccba3c500c1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df24e689-b71b-4182-a1a3-83b2119cdab2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7ab47f5-2daa-4b57-b128-5054cf6480c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f93c3430-5abe-4ba5-b2ec-90236b479b63");

            migrationBuilder.AlterColumn<string>(
                name: "OTP",
                table: "AspNetUsers",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AddColumn<bool>(
                name: "IsFrozed",
                table: "AspNetUsers",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d39a088-6914-4c5a-a71c-b4e496b7c4dd", null, "Gallery-Supervisor", "GALLERY-SUPERVISOR" },
                    { "249d5350-8dd9-4109-bc6a-995e7650bb9b", null, "CMS-Manager", "CMS-MANAGER" },
                    { "2a560d28-8edf-44de-9bd7-7266a8e28487", null, "Authntication-Officer", "AUTHNTICATION-OFFICER" },
                    { "30a27a69-e016-4373-baee-69d1cf128bbd", null, "CWCore-Supervisor", "CWCORE-SUPERVISOR" },
                    { "38b944e8-ef31-42c7-8662-ef46bb03e253", null, "Gallery-Admin", "GALLERY-ADMIN" },
                    { "3bd68ef3-3fef-45e1-9330-1652bb419c15", null, "Notification-Manager", "NOTIFICATION-MANAGER" },
                    { "4310baf1-e069-418e-9e22-13975a21d9fc", null, "Offer-Supervisor", "OFFER-SUPERVISOR" },
                    { "5aef887f-acf7-481d-9d33-47f8a2f38996", null, "CWCore-Admin", "CWCORE-ADMIN" },
                    { "5ee754f9-46cb-415e-a382-fa0e1896eb6d", null, "Authntication-Supervisor", "AUTHNTICATION-SUPERVISOR" },
                    { "5f36d8e3-1bb7-449f-9853-b17f1fa306b8", null, "CWCore-Officer", "CWCORE-OFFICER" },
                    { "63b51b72-5e22-4a51-ba92-5833693eac7f", null, "Hotel-Manager", "HOTEL-MANAGER" },
                    { "65c184b5-9787-41be-83d2-e30787934f20", null, "Gallery-Officer", "GALLERY-OFFICER" },
                    { "6a4f546c-eb5b-4346-9ccf-f77f7a2c728e", null, "Authntication-Manager", "AUTHNTICATION-MANAGER" },
                    { "6bf0d6ea-6331-44aa-ae46-6e0af234dc66", null, "Offer-Officer", "OFFER-OFFICER" },
                    { "732de7b1-0ab3-42dc-9322-53e65bb9cf61", null, "Notification-Officer", "NOTIFICATION-OFFICER" },
                    { "7b2aa64f-2c21-4cd3-869a-3d08bce412d0", null, "CMS-Admin", "CMS-ADMIN" },
                    { "7eae305d-afc1-465d-a392-a39ecbee525a", null, "CMS-Officer", "CMS-OFFICER" },
                    { "7fb085c9-b003-4c12-b130-470f72f1dcd9", null, "Hotel-Admin", "HOTEL-ADMIN" },
                    { "877b5bff-ec24-4119-84a7-0f89b52d235c", null, "Offer-Admin", "OFFER-ADMIN" },
                    { "8c92ce49-861d-4c99-a001-1605049a570b", null, "Hotel-Officer", "HOTEL-OFFICER" },
                    { "8ce71c02-3000-4a9d-a262-01ecdc9789e9", null, "Gallery-Manager", "GALLERY-MANAGER" },
                    { "ac983ac1-83a7-40f2-8fcd-1b24496d3d73", null, "Notification-Supervisor", "NOTIFICATION-SUPERVISOR" },
                    { "be680c63-bf8b-49f0-a50d-eacc73e76d3b", null, "Notification-Admin", "NOTIFICATION-ADMIN" },
                    { "cc618b51-3d07-4673-b4f1-6b3abd682317", null, "Hotel-Supervisor", "HOTEL-SUPERVISOR" },
                    { "eb1d9bcd-2874-4fba-b719-1ff63f0b4d3f", null, "CWCore-Manager", "CWCORE-MANAGER" },
                    { "efb3300b-39fd-4757-80f5-c02e87841315", null, "SuperAdmin", "SUPERADMIN" },
                    { "f6bd22b4-bcc5-4664-992f-8ad3ec9a48df", null, "Authntication-Admin", "AUTHNTICATION-ADMIN" },
                    { "fc13f516-a1b8-4445-bfcc-e04a400b0e7a", null, "Offer-Manager", "OFFER-MANAGER" },
                    { "fd1ef1e6-e601-4d78-b625-e4a65afac09b", null, "CMS-Supervisor", "CMS-SUPERVISOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d39a088-6914-4c5a-a71c-b4e496b7c4dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "249d5350-8dd9-4109-bc6a-995e7650bb9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a560d28-8edf-44de-9bd7-7266a8e28487");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30a27a69-e016-4373-baee-69d1cf128bbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b944e8-ef31-42c7-8662-ef46bb03e253");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bd68ef3-3fef-45e1-9330-1652bb419c15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4310baf1-e069-418e-9e22-13975a21d9fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5aef887f-acf7-481d-9d33-47f8a2f38996");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ee754f9-46cb-415e-a382-fa0e1896eb6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f36d8e3-1bb7-449f-9853-b17f1fa306b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63b51b72-5e22-4a51-ba92-5833693eac7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65c184b5-9787-41be-83d2-e30787934f20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a4f546c-eb5b-4346-9ccf-f77f7a2c728e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bf0d6ea-6331-44aa-ae46-6e0af234dc66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "732de7b1-0ab3-42dc-9322-53e65bb9cf61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b2aa64f-2c21-4cd3-869a-3d08bce412d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7eae305d-afc1-465d-a392-a39ecbee525a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fb085c9-b003-4c12-b130-470f72f1dcd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "877b5bff-ec24-4119-84a7-0f89b52d235c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c92ce49-861d-4c99-a001-1605049a570b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ce71c02-3000-4a9d-a262-01ecdc9789e9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac983ac1-83a7-40f2-8fcd-1b24496d3d73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be680c63-bf8b-49f0-a50d-eacc73e76d3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc618b51-3d07-4673-b4f1-6b3abd682317");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb1d9bcd-2874-4fba-b719-1ff63f0b4d3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efb3300b-39fd-4757-80f5-c02e87841315");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6bd22b4-bcc5-4664-992f-8ad3ec9a48df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc13f516-a1b8-4445-bfcc-e04a400b0e7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd1ef1e6-e601-4d78-b625-e4a65afac09b");

            migrationBuilder.DropColumn(
                name: "IsFrozed",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "OTP",
                table: "AspNetUsers",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02537d6e-78af-4283-9c81-a4c3726938f8", null, "Notification-Supervisor", "NOTIFICATION-SUPERVISOR" },
                    { "04440a0b-4715-421e-9abb-91c30dcd12c1", null, "Offer-Officer", "OFFER-OFFICER" },
                    { "0b73d86f-0ff8-4ad9-ab58-ff52308dea1a", null, "Hotel-Manager", "HOTEL-MANAGER" },
                    { "21ddfca7-f0b9-4efb-8184-40090779c5b0", null, "CMS-Officer", "CMS-OFFICER" },
                    { "29c666bf-a6bd-45b2-b4e5-c7edfe6cb98f", null, "Offer-Admin", "OFFER-ADMIN" },
                    { "5b10e3de-e565-4e5c-b120-73fb803bb096", null, "Notification-Officer", "NOTIFICATION-OFFICER" },
                    { "5f3652c0-ba36-4cab-8e98-36a7e98a0dba", null, "Gallery-Supervisor", "GALLERY-SUPERVISOR" },
                    { "61b7da41-0984-4362-a68f-08bac6f39cf9", null, "Gallery-Officer", "GALLERY-OFFICER" },
                    { "652f9335-c834-48e7-8217-57c8365b36c0", null, "Gallery-Admin", "GALLERY-ADMIN" },
                    { "66fabd0d-c971-4d2d-835d-16599d205686", null, "CWCore-Manager", "CWCORE-MANAGER" },
                    { "6d2ca768-a80a-4fa3-aad4-e3700266f579", null, "SuperAdmin", "SUPERADMIN" },
                    { "6d7b724f-757c-4d83-b488-ef3ed8a55d9b", null, "Offer-Manager", "OFFER-MANAGER" },
                    { "7c6edcae-811f-4f62-82c0-af6a9e7c95ca", null, "CMS-Admin", "CMS-ADMIN" },
                    { "83209eeb-a604-4247-828d-18bd7788f52d", null, "Hotel-Officer", "HOTEL-OFFICER" },
                    { "84d42ef8-8fa7-4785-acf0-d6c4970c6de7", null, "Offer-Supervisor", "OFFER-SUPERVISOR" },
                    { "89ad789d-5cc1-4fec-ac4b-a7b0455dce52", null, "CMS-Manager", "CMS-MANAGER" },
                    { "8db992f2-f87c-42e5-8f6a-162523d391e9", null, "Hotel-Admin", "HOTEL-ADMIN" },
                    { "9107aad7-31be-4313-8edf-9db675d53e13", null, "Authntication-Admin", "AUTHNTICATION-ADMIN" },
                    { "94d41678-e74e-4719-974f-f654d33aa82d", null, "CWCore-Admin", "CWCORE-ADMIN" },
                    { "9f57ff5b-e9ea-41e5-9fd1-c0083ccc8b9c", null, "Notification-Admin", "NOTIFICATION-ADMIN" },
                    { "a9c44bdf-9cd8-4a90-85bf-98b756444d5c", null, "Gallery-Manager", "GALLERY-MANAGER" },
                    { "bc8a6b69-9e33-4edf-ab8a-7ec63f086ec7", null, "Authntication-Manager", "AUTHNTICATION-MANAGER" },
                    { "bf01eea4-c6be-4fe9-aad4-c3c3b5997560", null, "Authntication-Supervisor", "AUTHNTICATION-SUPERVISOR" },
                    { "cf255e6c-7d61-4b02-8872-c4efe62ea6af", null, "Hotel-Supervisor", "HOTEL-SUPERVISOR" },
                    { "d2099570-c01b-4b56-b757-4c3091ea88d7", null, "Notification-Manager", "NOTIFICATION-MANAGER" },
                    { "d7fa8752-fcbe-474f-8f7f-ccba3c500c1f", null, "CMS-Supervisor", "CMS-SUPERVISOR" },
                    { "df24e689-b71b-4182-a1a3-83b2119cdab2", null, "Authntication-Officer", "AUTHNTICATION-OFFICER" },
                    { "e7ab47f5-2daa-4b57-b128-5054cf6480c6", null, "CWCore-Officer", "CWCORE-OFFICER" },
                    { "f93c3430-5abe-4ba5-b2ec-90236b479b63", null, "CWCore-Supervisor", "CWCORE-SUPERVISOR" }
                });
        }
    }
}
