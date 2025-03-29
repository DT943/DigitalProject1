using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddOTPFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01a62732-554b-4bee-9eea-4f075d7b02b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15d429d7-3352-4c92-897c-c2ad6e11239c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d65a565-4415-425c-b987-5c8e8fe5c750");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fe9abca-53c8-4411-aa07-733144922c60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23586d35-c476-443a-ab6e-1f010d61dbeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f0e81a4-a32d-4d09-9795-f501eccb1bb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d83e4d7-ea43-4027-9d1a-bcabdd18d355");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4564b2d0-53d6-40aa-910f-1173e69dffd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d50bb02-9b10-4bde-b923-899cbadc5e41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5274b296-11ce-4f13-a4d8-87475476142d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "579a117a-42c5-4493-bdfb-a67121e17d6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b04f1ed-f7ec-43cc-8910-6d0d9c9fbd4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68abdd8c-aef7-4a09-9a4d-4f6889774b04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cdd8b30-49e6-43d9-b3a6-dbc3a33cf321");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "775972aa-7c6f-4c3a-b34e-1c41fb67cf85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77792dda-d2c5-45d4-9934-58a4be477473");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c246a35-332b-47f8-93e8-08f2cfca0280");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ed477fa-29fa-46e2-9934-d2a69d6856b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f86201c-ca19-4797-be3d-3eff7c918fb2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4293440-8152-4329-97fb-a5f5468b5bbb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b94ecd82-927f-403c-86dd-11fec2a85f34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9df6ac4-c65e-47d3-b80c-3b6faa225fa2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6e04296-563c-49dd-8f4c-a4b42a6595cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "def9c4ad-3313-4fb3-944f-3eabf4f9e143");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eae2b2ce-eb57-45d7-8078-bc3abe0471ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed48149f-ab12-4f80-8ed7-d275c0135b6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2c3ee04-dc2c-4cc3-9df8-8588c4b76eb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3d4a6f7-ea56-4eb1-a567-c1d91869c3ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe86a05e-bd2f-40de-9454-4647cd922f5a");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLogIn",
                table: "AspNetUsers",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OTP",
                table: "AspNetUsers",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OTPExpiration",
                table: "AspNetUsers",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "NumberOfLogIn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OTP",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OTPExpiration",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01a62732-554b-4bee-9eea-4f075d7b02b2", null, "Gallery-Officer", "GALLERY-OFFICER" },
                    { "15d429d7-3352-4c92-897c-c2ad6e11239c", null, "Hotel-Supervisor", "HOTEL-SUPERVISOR" },
                    { "1d65a565-4415-425c-b987-5c8e8fe5c750", null, "Notification-Manager", "NOTIFICATION-MANAGER" },
                    { "1fe9abca-53c8-4411-aa07-733144922c60", null, "Authntication-Admin", "AUTHNTICATION-ADMIN" },
                    { "23586d35-c476-443a-ab6e-1f010d61dbeb", null, "Notification-Officer", "NOTIFICATION-OFFICER" },
                    { "2f0e81a4-a32d-4d09-9795-f501eccb1bb0", null, "Hotel-Admin", "HOTEL-ADMIN" },
                    { "3d83e4d7-ea43-4027-9d1a-bcabdd18d355", null, "Offer-Admin", "OFFER-ADMIN" },
                    { "4564b2d0-53d6-40aa-910f-1173e69dffd3", null, "CMS-Officer", "CMS-OFFICER" },
                    { "4d50bb02-9b10-4bde-b923-899cbadc5e41", null, "Authntication-Manager", "AUTHNTICATION-MANAGER" },
                    { "5274b296-11ce-4f13-a4d8-87475476142d", null, "Offer-Supervisor", "OFFER-SUPERVISOR" },
                    { "579a117a-42c5-4493-bdfb-a67121e17d6a", null, "CWCore-Officer", "CWCORE-OFFICER" },
                    { "5b04f1ed-f7ec-43cc-8910-6d0d9c9fbd4e", null, "Notification-Admin", "NOTIFICATION-ADMIN" },
                    { "68abdd8c-aef7-4a09-9a4d-4f6889774b04", null, "CWCore-Manager", "CWCORE-MANAGER" },
                    { "6cdd8b30-49e6-43d9-b3a6-dbc3a33cf321", null, "SuperAdmin", "SUPERADMIN" },
                    { "775972aa-7c6f-4c3a-b34e-1c41fb67cf85", null, "Authntication-Officer", "AUTHNTICATION-OFFICER" },
                    { "77792dda-d2c5-45d4-9934-58a4be477473", null, "CMS-Supervisor", "CMS-SUPERVISOR" },
                    { "7c246a35-332b-47f8-93e8-08f2cfca0280", null, "Hotel-Officer", "HOTEL-OFFICER" },
                    { "7ed477fa-29fa-46e2-9934-d2a69d6856b2", null, "CMS-Admin", "CMS-ADMIN" },
                    { "8f86201c-ca19-4797-be3d-3eff7c918fb2", null, "Notification-Supervisor", "NOTIFICATION-SUPERVISOR" },
                    { "b4293440-8152-4329-97fb-a5f5468b5bbb", null, "Offer-Officer", "OFFER-OFFICER" },
                    { "b94ecd82-927f-403c-86dd-11fec2a85f34", null, "CMS-Manager", "CMS-MANAGER" },
                    { "c9df6ac4-c65e-47d3-b80c-3b6faa225fa2", null, "Authntication-Supervisor", "AUTHNTICATION-SUPERVISOR" },
                    { "d6e04296-563c-49dd-8f4c-a4b42a6595cb", null, "Offer-Manager", "OFFER-MANAGER" },
                    { "def9c4ad-3313-4fb3-944f-3eabf4f9e143", null, "Gallery-Manager", "GALLERY-MANAGER" },
                    { "eae2b2ce-eb57-45d7-8078-bc3abe0471ad", null, "Hotel-Manager", "HOTEL-MANAGER" },
                    { "ed48149f-ab12-4f80-8ed7-d275c0135b6c", null, "CWCore-Admin", "CWCORE-ADMIN" },
                    { "f2c3ee04-dc2c-4cc3-9df8-8588c4b76eb9", null, "Gallery-Supervisor", "GALLERY-SUPERVISOR" },
                    { "f3d4a6f7-ea56-4eb1-a567-c1d91869c3ad", null, "CWCore-Supervisor", "CWCORE-SUPERVISOR" },
                    { "fe86a05e-bd2f-40de-9454-4647cd922f5a", null, "Gallery-Admin", "GALLERY-ADMIN" }
                });
        }
    }
}
