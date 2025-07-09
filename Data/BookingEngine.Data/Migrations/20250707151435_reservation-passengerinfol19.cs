using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class reservationpassengerinfol19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerInfos_Contacts_ContactInfoId",
                table: "PassengerInfos");

            migrationBuilder.DropIndex(
                name: "IX_PassengerInfos_ContactInfoId",
                table: "PassengerInfos");

            migrationBuilder.DropColumn(
                name: "ContactInfoId",
                table: "PassengerInfos");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "PassengerInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Contacts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerInfos_ContactId",
                table: "PassengerInfos",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerInfos_Contacts_ContactId",
                table: "PassengerInfos",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerInfos_Contacts_ContactId",
                table: "PassengerInfos");

            migrationBuilder.DropIndex(
                name: "IX_PassengerInfos_ContactId",
                table: "PassengerInfos");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "PassengerInfos");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "ContactInfoId",
                table: "PassengerInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PassengerInfos_ContactInfoId",
                table: "PassengerInfos",
                column: "ContactInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerInfos_Contacts_ContactInfoId",
                table: "PassengerInfos",
                column: "ContactInfoId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
