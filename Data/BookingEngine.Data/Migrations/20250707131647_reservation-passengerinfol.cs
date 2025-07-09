using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class reservationpassengerinfol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerInfos_Contacts_ConactInfoId",
                table: "PassengerInfos");

            migrationBuilder.DropIndex(
                name: "IX_Telephones_PassengerInfoId",
                table: "Telephones");

            migrationBuilder.DropIndex(
                name: "IX_Passports_PassengerInfoId",
                table: "Passports");

            migrationBuilder.RenameColumn(
                name: "ConactInfoId",
                table: "PassengerInfos",
                newName: "ContactInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_PassengerInfos_ConactInfoId",
                table: "PassengerInfos",
                newName: "IX_PassengerInfos_ContactInfoId");

            migrationBuilder.AddColumn<int>(
                name: "PassportId",
                table: "PassengerInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TelephoneId",
                table: "PassengerInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telephones_PassengerInfoId",
                table: "Telephones",
                column: "PassengerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_PassengerInfoId",
                table: "Passports",
                column: "PassengerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerInfos_PassportId",
                table: "PassengerInfos",
                column: "PassportId");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerInfos_TelephoneId",
                table: "PassengerInfos",
                column: "TelephoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerInfos_Contacts_ContactInfoId",
                table: "PassengerInfos",
                column: "ContactInfoId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerInfos_Passports_PassportId",
                table: "PassengerInfos",
                column: "PassportId",
                principalTable: "Passports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerInfos_Telephones_TelephoneId",
                table: "PassengerInfos",
                column: "TelephoneId",
                principalTable: "Telephones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerInfos_Contacts_ContactInfoId",
                table: "PassengerInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_PassengerInfos_Passports_PassportId",
                table: "PassengerInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_PassengerInfos_Telephones_TelephoneId",
                table: "PassengerInfos");

            migrationBuilder.DropIndex(
                name: "IX_Telephones_PassengerInfoId",
                table: "Telephones");

            migrationBuilder.DropIndex(
                name: "IX_Passports_PassengerInfoId",
                table: "Passports");

            migrationBuilder.DropIndex(
                name: "IX_PassengerInfos_PassportId",
                table: "PassengerInfos");

            migrationBuilder.DropIndex(
                name: "IX_PassengerInfos_TelephoneId",
                table: "PassengerInfos");

            migrationBuilder.DropColumn(
                name: "PassportId",
                table: "PassengerInfos");

            migrationBuilder.DropColumn(
                name: "TelephoneId",
                table: "PassengerInfos");

            migrationBuilder.RenameColumn(
                name: "ContactInfoId",
                table: "PassengerInfos",
                newName: "ConactInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_PassengerInfos_ContactInfoId",
                table: "PassengerInfos",
                newName: "IX_PassengerInfos_ConactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Telephones_PassengerInfoId",
                table: "Telephones",
                column: "PassengerInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passports_PassengerInfoId",
                table: "Passports",
                column: "PassengerInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerInfos_Contacts_ConactInfoId",
                table: "PassengerInfos",
                column: "ConactInfoId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
