using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLastOtpChecked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "LastOTPChecked",
                table: "AspNetUsers",
                type: "TIMESTAMP(7)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "036af88c-7f26-4a5c-9f8e-b7275bb205b2", null, "Authntication-Manager", "AUTHNTICATION-MANAGER" },
                    { "03ff3ee3-8950-41b1-8445-0bf577f9e150", null, "Hotel-Officer", "HOTEL-OFFICER" },
                    { "04934ab6-6c9c-4fa1-ab36-9c6ee954e748", null, "CMS-Admin", "CMS-ADMIN" },
                    { "071121a3-a5da-45b6-9e24-5014ccc6246e", null, "Offer-Officer", "OFFER-OFFICER" },
                    { "096a28ab-9b2e-45f0-b648-cd88b7517202", null, "Notification-Admin", "NOTIFICATION-ADMIN" },
                    { "398137ed-cee2-4013-9c94-ccc90ef53e89", null, "Notification-Supervisor", "NOTIFICATION-SUPERVISOR" },
                    { "3aaa5d33-d9d9-49aa-8756-f96a55a30d00", null, "Gallery-Supervisor", "GALLERY-SUPERVISOR" },
                    { "40d6aa2b-76f6-458a-869f-ac215526e07c", null, "CWCore-Manager", "CWCORE-MANAGER" },
                    { "4334c7b8-b800-4561-8a0e-7785aaaa2887", null, "Hotel-Admin", "HOTEL-ADMIN" },
                    { "4c00bc71-a1c3-4302-abd3-91dc2c10d6d5", null, "Offer-Manager", "OFFER-MANAGER" },
                    { "53bef389-bd02-478d-b970-a151b652a3a3", null, "SuperAdmin", "SUPERADMIN" },
                    { "69a8eac4-bf50-417c-84d9-32bdcabd908f", null, "Gallery-Admin", "GALLERY-ADMIN" },
                    { "705dd026-fd38-44ef-9b9b-850100a87de3", null, "Authntication-Officer", "AUTHNTICATION-OFFICER" },
                    { "70e941cd-dca5-4af7-a468-71abe33b80de", null, "Hotel-Manager", "HOTEL-MANAGER" },
                    { "735ef191-4635-41b3-af9a-19ef21fb8964", null, "CMS-Manager", "CMS-MANAGER" },
                    { "83b1358a-d571-4494-888d-fe4f2456f0af", null, "Offer-Supervisor", "OFFER-SUPERVISOR" },
                    { "85edc6aa-54b7-4121-ae58-883aa6e0fcb6", null, "CWCore-Admin", "CWCORE-ADMIN" },
                    { "88ab1ebd-e139-4654-9ab4-483373a4ad32", null, "Notification-Manager", "NOTIFICATION-MANAGER" },
                    { "9a20b562-abd8-47e6-8252-bce057ebe10c", null, "CWCore-Supervisor", "CWCORE-SUPERVISOR" },
                    { "9aa58402-e520-47f7-afb3-b66ff512789d", null, "Authntication-Supervisor", "AUTHNTICATION-SUPERVISOR" },
                    { "9bbcf419-5c0a-4caa-85f1-245b2b947826", null, "Hotel-Supervisor", "HOTEL-SUPERVISOR" },
                    { "9e6f2224-16bf-4110-b648-b4ef6553e798", null, "Notification-Officer", "NOTIFICATION-OFFICER" },
                    { "a6480ac0-a844-49e1-abc0-316a752b076e", null, "Offer-Admin", "OFFER-ADMIN" },
                    { "b78e69ab-dd6b-41e1-ad16-18ba3de500cb", null, "Gallery-Officer", "GALLERY-OFFICER" },
                    { "caec9049-8143-4d9c-b1b2-b07bba9adbb6", null, "CMS-Supervisor", "CMS-SUPERVISOR" },
                    { "db2b3834-62ea-4363-b545-91b735424e24", null, "Authntication-Admin", "AUTHNTICATION-ADMIN" },
                    { "e606249e-f1cb-4534-abf2-8d0d4fe77e7d", null, "Gallery-Manager", "GALLERY-MANAGER" },
                    { "edd3383c-5aed-4374-8d4b-476203efd386", null, "CMS-Officer", "CMS-OFFICER" },
                    { "fdecff09-b290-4c2f-89f5-e6af65955382", null, "CWCore-Officer", "CWCORE-OFFICER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "036af88c-7f26-4a5c-9f8e-b7275bb205b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03ff3ee3-8950-41b1-8445-0bf577f9e150");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04934ab6-6c9c-4fa1-ab36-9c6ee954e748");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "071121a3-a5da-45b6-9e24-5014ccc6246e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "096a28ab-9b2e-45f0-b648-cd88b7517202");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "398137ed-cee2-4013-9c94-ccc90ef53e89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aaa5d33-d9d9-49aa-8756-f96a55a30d00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40d6aa2b-76f6-458a-869f-ac215526e07c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4334c7b8-b800-4561-8a0e-7785aaaa2887");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c00bc71-a1c3-4302-abd3-91dc2c10d6d5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53bef389-bd02-478d-b970-a151b652a3a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69a8eac4-bf50-417c-84d9-32bdcabd908f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "705dd026-fd38-44ef-9b9b-850100a87de3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70e941cd-dca5-4af7-a468-71abe33b80de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "735ef191-4635-41b3-af9a-19ef21fb8964");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83b1358a-d571-4494-888d-fe4f2456f0af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85edc6aa-54b7-4121-ae58-883aa6e0fcb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88ab1ebd-e139-4654-9ab4-483373a4ad32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a20b562-abd8-47e6-8252-bce057ebe10c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa58402-e520-47f7-afb3-b66ff512789d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bbcf419-5c0a-4caa-85f1-245b2b947826");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e6f2224-16bf-4110-b648-b4ef6553e798");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6480ac0-a844-49e1-abc0-316a752b076e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b78e69ab-dd6b-41e1-ad16-18ba3de500cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caec9049-8143-4d9c-b1b2-b07bba9adbb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db2b3834-62ea-4363-b545-91b735424e24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e606249e-f1cb-4534-abf2-8d0d4fe77e7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edd3383c-5aed-4374-8d4b-476203efd386");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdecff09-b290-4c2f-89f5-e6af65955382");

            migrationBuilder.DropColumn(
                name: "LastOTPChecked",
                table: "AspNetUsers");

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
    }
}
