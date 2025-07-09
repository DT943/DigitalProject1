using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class reservationpassengerinfol1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passports_PassengerInfos_PassengerInfoId",
                table: "Passports");

            migrationBuilder.DropForeignKey(
                name: "FK_Telephones_PassengerInfos_PassengerInfoId",
                table: "Telephones");

            migrationBuilder.DropIndex(
                name: "IX_Telephones_PassengerInfoId",
                table: "Telephones");

            migrationBuilder.DropIndex(
                name: "IX_Passports_PassengerInfoId",
                table: "Passports");

            migrationBuilder.DropColumn(
                name: "PassengerInfoId",
                table: "Telephones");

            migrationBuilder.DropColumn(
                name: "PassengerInfoId",
                table: "Passports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PassengerInfoId",
                table: "Telephones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassengerInfoId",
                table: "Passports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Telephones_PassengerInfoId",
                table: "Telephones",
                column: "PassengerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_PassengerInfoId",
                table: "Passports",
                column: "PassengerInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passports_PassengerInfos_PassengerInfoId",
                table: "Passports",
                column: "PassengerInfoId",
                principalTable: "PassengerInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telephones_PassengerInfos_PassengerInfoId",
                table: "Telephones",
                column: "PassengerInfoId",
                principalTable: "PassengerInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
