using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class reservationpassengerinfol191 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerInfos_Contacts_ContactId",
                table: "PassengerInfos");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "PassengerInfos");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "PassengerInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerInfos_Contacts_ContactId",
                table: "PassengerInfos",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerInfos_Contacts_ContactId",
                table: "PassengerInfos");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "PassengerInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PassengerInfos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerInfos_Contacts_ContactId",
                table: "PassengerInfos",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");
        }
    }
}
