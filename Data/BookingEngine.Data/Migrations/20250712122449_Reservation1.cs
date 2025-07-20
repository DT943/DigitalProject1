using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class Reservation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Reservations_ReservationId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ReservationId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Contacts");

            migrationBuilder.AddColumn<int>(
                name: "ContactInfoId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ContactInfoId",
                table: "Reservations",
                column: "ContactInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Contacts_ContactInfoId",
                table: "Reservations",
                column: "ContactInfoId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Contacts_ContactInfoId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ContactInfoId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ContactInfoId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ReservationId",
                table: "Contacts",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Reservations_ReservationId",
                table: "Contacts",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}
