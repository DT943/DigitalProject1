using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Data.Migrations
{
    /// <inheritdoc />
    public partial class addisdeleted : Migration
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1385a14b-c73c-49b3-ab9d-b96a5352c279", null, "CWCore-Manager", "CWCORE-MANAGER" },
                    { "18def062-854e-475f-8153-2e383842d8ff", null, "Offer-Manager", "OFFER-MANAGER" },
                    { "20aee4b5-3f62-4165-8ac3-34f657b92b83", null, "Notification-Officer", "NOTIFICATION-OFFICER" },
                    { "2123b5f7-0d6c-4281-a0e8-e6c559a158c4", null, "Notification-Admin", "NOTIFICATION-ADMIN" },
                    { "295156fd-b99f-4146-b86e-cc55eeb90b76", null, "Offer-Admin", "OFFER-ADMIN" },
                    { "2a019680-ebe7-4325-b9a7-c72db024e93d", null, "Authntication-Supervisor", "AUTHNTICATION-SUPERVISOR" },
                    { "2cc1dabf-88b6-4cb3-82b8-90db7070b145", null, "Hotel-Officer", "HOTEL-OFFICER" },
                    { "352720cc-52bf-4286-894f-d36401ad1484", null, "Gallery-Supervisor", "GALLERY-SUPERVISOR" },
                    { "41da0ca2-8e26-4cd9-83ab-4d99ad249825", null, "Gallery-Officer", "GALLERY-OFFICER" },
                    { "4cf8202b-72a7-44ca-b73c-3c8e387f62f7", null, "Hotel-Supervisor", "HOTEL-SUPERVISOR" },
                    { "52671c53-51e6-41da-b641-6c8967967b12", null, "Offer-Officer", "OFFER-OFFICER" },
                    { "52d31128-62e1-4c17-84f9-58d2c75374af", null, "SuperAdmin", "SUPERADMIN" },
                    { "55f07e28-0a3c-4b9a-a71d-fb7fa15865a3", null, "CMS-Admin", "CMS-ADMIN" },
                    { "6a74d24a-c2ae-4f65-b197-c499caede304", null, "Offer-Supervisor", "OFFER-SUPERVISOR" },
                    { "6c387b1b-12fb-4c4e-a3d4-5c50d2abd82b", null, "Notification-Supervisor", "NOTIFICATION-SUPERVISOR" },
                    { "6ea1b674-05d1-4711-953a-d097ceab2ec9", null, "Notification-Manager", "NOTIFICATION-MANAGER" },
                    { "7d1bcbab-b688-46cf-ae78-28cb3b42e6ce", null, "Gallery-Admin", "GALLERY-ADMIN" },
                    { "a3fc42ae-74bd-4fcf-adf5-35bffd44a36a", null, "CWCore-Officer", "CWCORE-OFFICER" },
                    { "a74368b1-3a8f-4458-8c67-721f48992a3a", null, "Authntication-Admin", "AUTHNTICATION-ADMIN" },
                    { "b135d18f-be25-430d-867f-8abbcbb60674", null, "Hotel-Manager", "HOTEL-MANAGER" },
                    { "bf4a8b5f-9051-4890-8b08-2c9e5da3d518", null, "Authntication-Officer", "AUTHNTICATION-OFFICER" },
                    { "c27ef78a-6a9f-4062-9330-91e8abbfd066", null, "CMS-Supervisor", "CMS-SUPERVISOR" },
                    { "c2bebd68-03ff-47c1-82a1-1343d5af444b", null, "Hotel-Admin", "HOTEL-ADMIN" },
                    { "c6b01627-2918-43a9-af64-1ced5737c2b9", null, "CWCore-Supervisor", "CWCORE-SUPERVISOR" },
                    { "d8d79b47-e5c8-4489-87e1-85ef83f1e147", null, "CMS-Manager", "CMS-MANAGER" },
                    { "d94170ef-f96f-4ac3-963a-abb3b94454ed", null, "Authntication-Manager", "AUTHNTICATION-MANAGER" },
                    { "dce24368-1aa0-4876-8faa-faae25abe4d1", null, "CMS-Officer", "CMS-OFFICER" },
                    { "dd7fedfe-2651-451d-bc2d-7076e0b2436d", null, "Gallery-Manager", "GALLERY-MANAGER" },
                    { "ec9ce570-1ce7-47ae-9722-78647d98aedf", null, "CWCore-Admin", "CWCORE-ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1385a14b-c73c-49b3-ab9d-b96a5352c279");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18def062-854e-475f-8153-2e383842d8ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20aee4b5-3f62-4165-8ac3-34f657b92b83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2123b5f7-0d6c-4281-a0e8-e6c559a158c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "295156fd-b99f-4146-b86e-cc55eeb90b76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a019680-ebe7-4325-b9a7-c72db024e93d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cc1dabf-88b6-4cb3-82b8-90db7070b145");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "352720cc-52bf-4286-894f-d36401ad1484");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41da0ca2-8e26-4cd9-83ab-4d99ad249825");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cf8202b-72a7-44ca-b73c-3c8e387f62f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52671c53-51e6-41da-b641-6c8967967b12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52d31128-62e1-4c17-84f9-58d2c75374af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55f07e28-0a3c-4b9a-a71d-fb7fa15865a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a74d24a-c2ae-4f65-b197-c499caede304");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c387b1b-12fb-4c4e-a3d4-5c50d2abd82b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ea1b674-05d1-4711-953a-d097ceab2ec9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d1bcbab-b688-46cf-ae78-28cb3b42e6ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3fc42ae-74bd-4fcf-adf5-35bffd44a36a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a74368b1-3a8f-4458-8c67-721f48992a3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b135d18f-be25-430d-867f-8abbcbb60674");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf4a8b5f-9051-4890-8b08-2c9e5da3d518");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c27ef78a-6a9f-4062-9330-91e8abbfd066");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2bebd68-03ff-47c1-82a1-1343d5af444b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6b01627-2918-43a9-af64-1ced5737c2b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8d79b47-e5c8-4489-87e1-85ef83f1e147");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d94170ef-f96f-4ac3-963a-abb3b94454ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dce24368-1aa0-4876-8faa-faae25abe4d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd7fedfe-2651-451d-bc2d-7076e0b2436d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec9ce570-1ce7-47ae-9722-78647d98aedf");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
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
