using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Authentication.Data.Migrations
{
    /// <inheritdoc />
    public partial class authenticationservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsFrozed = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfLogIn = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ManagerCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastLogIn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTPExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastOTPChecked = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
