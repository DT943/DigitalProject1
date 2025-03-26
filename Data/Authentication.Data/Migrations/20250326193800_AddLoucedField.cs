using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLoucedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02cf41c8-b1cc-4d3b-af43-5056e44b1f94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e8e86e8-a0ee-4abf-aedb-718dec59aedc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "120d87b0-692c-4fa9-95aa-6ff4c50f46d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1632ca23-2b0d-4aff-af80-4f5b5fc781cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17d4bed3-4cb2-4755-9ad9-0d20382044cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a2b55d4-36c0-4456-953f-b689fde6dc87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20456a46-768f-4b41-8f2d-eb369a1821a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f0ed211-ea63-4ac5-bc73-2faedce22790");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35b3f54a-1f09-4e63-93df-542775030f38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "527a5695-617f-4904-a8f4-0b3c9ecf4ec6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c768e18-c23d-4751-997d-7734018901ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5de8bcb0-281e-4d56-a25d-bff4885a2e0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9647facd-82ea-407c-966d-64a044a2beda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9de39cac-e6b1-4656-a1fe-93cd0948e9b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5debc4e-adfe-4dcd-8b20-af72fafd919f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a632ae4b-e04d-4f7f-b7ce-3d1e2f7419b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6fb49d3-f2c3-4c68-a378-3a0a7ece5d12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ada29c72-fd08-42fd-b35d-d1894cb1789f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b42d05e8-c81d-4719-91d4-e41835e667dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bba2e343-3b28-4181-9252-75a3e5fcf0a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf0f10ad-d1e1-4758-843c-e53c40fe3652");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c97afe02-a810-4b1a-900f-8efa7a80424d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9cc5cce-6d69-4950-a83b-6b7c516685f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd95df83-8804-477f-9d0a-1e3f2f17d5e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d16c3bf7-71b8-45b2-8a55-4a8ea5b94a6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eac2f75a-15c8-43b5-a7a6-b57892536986");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f368bf80-cf94-4252-af43-c139f2b5f6ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb30410e-effc-49ca-ad9f-14da8617ede6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff944bf4-0c66-4679-ba9d-0d7b01478e49");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "CMS-Manager", "03d648c9-2fb7-4851-becb-068c8bc1b923" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "SuperAdmin", "6b7b3f73-ecad-4acd-97c0-9e0c79e1c0ed" });

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "MotherName",
                table: "AspNetUsers",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "AspNetUsers",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "AspNetUsers",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "AspNetUsers",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MotherName",
                table: "AspNetUsers",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityNumber",
                table: "AspNetUsers",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "NUMBER(10)",
                maxLength: 50,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "AspNetUsers",
                type: "NVARCHAR2(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TIMESTAMP(7) WITH TIME ZONE", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PasswordHash = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    SecurityStamp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    UserName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02cf41c8-b1cc-4d3b-af43-5056e44b1f94", null, "Notification-Supervisor", "NOTIFICATION-SUPERVISOR" },
                    { "0e8e86e8-a0ee-4abf-aedb-718dec59aedc", null, "Hotel-Supervisor", "HOTEL-SUPERVISOR" },
                    { "120d87b0-692c-4fa9-95aa-6ff4c50f46d9", null, "CMS-Officer", "CMS-OFFICER" },
                    { "1632ca23-2b0d-4aff-af80-4f5b5fc781cc", null, "CWCore-Officer", "CWCORE-OFFICER" },
                    { "17d4bed3-4cb2-4755-9ad9-0d20382044cd", null, "Hotel-Admin", "HOTEL-ADMIN" },
                    { "1a2b55d4-36c0-4456-953f-b689fde6dc87", null, "Gallery-Officer", "GALLERY-OFFICER" },
                    { "20456a46-768f-4b41-8f2d-eb369a1821a9", null, "Notification-Officer", "NOTIFICATION-OFFICER" },
                    { "2f0ed211-ea63-4ac5-bc73-2faedce22790", null, "Gallery-Supervisor", "GALLERY-SUPERVISOR" },
                    { "35b3f54a-1f09-4e63-93df-542775030f38", null, "CMS-Supervisor", "CMS-SUPERVISOR" },
                    { "527a5695-617f-4904-a8f4-0b3c9ecf4ec6", null, "CMS-Admin", "CMS-ADMIN" },
                    { "5c768e18-c23d-4751-997d-7734018901ec", null, "Notification-Manager", "NOTIFICATION-MANAGER" },
                    { "5de8bcb0-281e-4d56-a25d-bff4885a2e0e", null, "Offer-Officer", "OFFER-OFFICER" },
                    { "9647facd-82ea-407c-966d-64a044a2beda", null, "Hotel-Officer", "HOTEL-OFFICER" },
                    { "9de39cac-e6b1-4656-a1fe-93cd0948e9b0", null, "Hotel-Manager", "HOTEL-MANAGER" },
                    { "a5debc4e-adfe-4dcd-8b20-af72fafd919f", null, "SuperAdmin", "SUPERADMIN" },
                    { "a632ae4b-e04d-4f7f-b7ce-3d1e2f7419b4", null, "Offer-Manager", "OFFER-MANAGER" },
                    { "a6fb49d3-f2c3-4c68-a378-3a0a7ece5d12", null, "Gallery-Admin", "GALLERY-ADMIN" },
                    { "ada29c72-fd08-42fd-b35d-d1894cb1789f", null, "CMS-Manager", "CMS-MANAGER" },
                    { "b42d05e8-c81d-4719-91d4-e41835e667dc", null, "Notification-Admin", "NOTIFICATION-ADMIN" },
                    { "bba2e343-3b28-4181-9252-75a3e5fcf0a8", null, "CWCore-Admin", "CWCORE-ADMIN" },
                    { "bf0f10ad-d1e1-4758-843c-e53c40fe3652", null, "CWCore-Manager", "CWCORE-MANAGER" },
                    { "c97afe02-a810-4b1a-900f-8efa7a80424d", null, "Offer-Supervisor", "OFFER-SUPERVISOR" },
                    { "c9cc5cce-6d69-4950-a83b-6b7c516685f2", null, "Authntication-Admin", "AUTHNTICATION-ADMIN" },
                    { "cd95df83-8804-477f-9d0a-1e3f2f17d5e2", null, "Offer-Admin", "OFFER-ADMIN" },
                    { "d16c3bf7-71b8-45b2-8a55-4a8ea5b94a6b", null, "Authntication-Supervisor", "AUTHNTICATION-SUPERVISOR" },
                    { "eac2f75a-15c8-43b5-a7a6-b57892536986", null, "Gallery-Manager", "GALLERY-MANAGER" },
                    { "f368bf80-cf94-4252-af43-c139f2b5f6ad", null, "Authntication-Officer", "AUTHNTICATION-OFFICER" },
                    { "fb30410e-effc-49ca-ad9f-14da8617ede6", null, "CWCore-Supervisor", "CWCORE-SUPERVISOR" },
                    { "ff944bf4-0c66-4679-ba9d-0d7b01478e49", null, "Authntication-Manager", "AUTHNTICATION-MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "CMS-Manager", "03d648c9-2fb7-4851-becb-068c8bc1b923" },
                    { "SuperAdmin", "6b7b3f73-ecad-4acd-97c0-9e0c79e1c0ed" }
                });

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "03d648c9-2fb7-4851-becb-068c8bc1b923", 0, "e85b2f90-ba0c-431c-bf21-802c8a25ee3d", "manager@example.com", true, false, null, "MANAGER@EXAMPLE.COM", "MANAGER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAsFGEIkQ/z9GViBPo4KyMhJ9VvpJ+7adlBvCVNnceDAQBEv2HPMgWS3z0Sus7uCeg==", null, false, "c138afa4-21d7-4dc2-859c-78c3b84be9ab", false, "manager@example.com" },
                    { "6b7b3f73-ecad-4acd-97c0-9e0c79e1c0ed", 0, "fdf32f3c-c323-4c5a-b252-e9cab0afd216", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEH5PqrRKDVK8DgMHP3jfNvx7qe7TwXgkx2nNEwY4N1D/JPHJf//ytzjxGnLQwWy8eg==", null, false, "2160d2d7-a84e-4f7c-a44b-6171a4b38dfd", false, "admin@example.com" }
                });
        }
    }
}
