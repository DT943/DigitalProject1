using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class pnrpaymentTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRETicketInfo_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRETicketInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRFee_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRFee");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRFlightSegment_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRFlightSegment");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRPassenger_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRResults_PaymentPNRContact_ContactId",
                table: "PaymentPNRResults");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRTax_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRTax");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPNRTax",
                table: "PaymentPNRTax");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPNRPassenger",
                table: "PaymentPNRPassenger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPNRFlightSegment",
                table: "PaymentPNRFlightSegment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPNRFee",
                table: "PaymentPNRFee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPNRETicketInfo",
                table: "PaymentPNRETicketInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPNRContact",
                table: "PaymentPNRContact");

            migrationBuilder.RenameTable(
                name: "PaymentPNRTax",
                newName: "PaymentPNRTaxs");

            migrationBuilder.RenameTable(
                name: "PaymentPNRPassenger",
                newName: "PaymentPNRPassengers");

            migrationBuilder.RenameTable(
                name: "PaymentPNRFlightSegment",
                newName: "PaymentPNRFlightSegments");

            migrationBuilder.RenameTable(
                name: "PaymentPNRFee",
                newName: "PaymentPNRFees");

            migrationBuilder.RenameTable(
                name: "PaymentPNRETicketInfo",
                newName: "PaymentPNRETicketInfos");

            migrationBuilder.RenameTable(
                name: "PaymentPNRContact",
                newName: "PaymentPNRContacts");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRTax_PaymentPNRResultId",
                table: "PaymentPNRTaxs",
                newName: "IX_PaymentPNRTaxs_PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRPassenger_PaymentPNRResultId",
                table: "PaymentPNRPassengers",
                newName: "IX_PaymentPNRPassengers_PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRFlightSegment_PaymentPNRResultId",
                table: "PaymentPNRFlightSegments",
                newName: "IX_PaymentPNRFlightSegments_PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRFee_PaymentPNRResultId",
                table: "PaymentPNRFees",
                newName: "IX_PaymentPNRFees_PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRETicketInfo_PaymentPNRResultId",
                table: "PaymentPNRETicketInfos",
                newName: "IX_PaymentPNRETicketInfos_PaymentPNRResultId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPNRTaxs",
                table: "PaymentPNRTaxs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPNRPassengers",
                table: "PaymentPNRPassengers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPNRFlightSegments",
                table: "PaymentPNRFlightSegments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPNRFees",
                table: "PaymentPNRFees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPNRETicketInfos",
                table: "PaymentPNRETicketInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPNRContacts",
                table: "PaymentPNRContacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRETicketInfos_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRETicketInfos",
                column: "PaymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRFees_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRFees",
                column: "PaymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRFlightSegments_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRFlightSegments",
                column: "PaymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRPassengers_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRPassengers",
                column: "PaymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRResults_PaymentPNRContacts_ContactId",
                table: "PaymentPNRResults",
                column: "ContactId",
                principalTable: "PaymentPNRContacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRTaxs_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRTaxs",
                column: "PaymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRETicketInfos_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRETicketInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRFees_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRFees");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRFlightSegments_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRFlightSegments");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRPassengers_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRPassengers");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRResults_PaymentPNRContacts_ContactId",
                table: "PaymentPNRResults");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRTaxs_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRTaxs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPNRTaxs",
                table: "PaymentPNRTaxs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPNRPassengers",
                table: "PaymentPNRPassengers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPNRFlightSegments",
                table: "PaymentPNRFlightSegments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPNRFees",
                table: "PaymentPNRFees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPNRETicketInfos",
                table: "PaymentPNRETicketInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentPNRContacts",
                table: "PaymentPNRContacts");

            migrationBuilder.RenameTable(
                name: "PaymentPNRTaxs",
                newName: "PaymentPNRTax");

            migrationBuilder.RenameTable(
                name: "PaymentPNRPassengers",
                newName: "PaymentPNRPassenger");

            migrationBuilder.RenameTable(
                name: "PaymentPNRFlightSegments",
                newName: "PaymentPNRFlightSegment");

            migrationBuilder.RenameTable(
                name: "PaymentPNRFees",
                newName: "PaymentPNRFee");

            migrationBuilder.RenameTable(
                name: "PaymentPNRETicketInfos",
                newName: "PaymentPNRETicketInfo");

            migrationBuilder.RenameTable(
                name: "PaymentPNRContacts",
                newName: "PaymentPNRContact");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRTaxs_PaymentPNRResultId",
                table: "PaymentPNRTax",
                newName: "IX_PaymentPNRTax_PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRPassengers_PaymentPNRResultId",
                table: "PaymentPNRPassenger",
                newName: "IX_PaymentPNRPassenger_PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRFlightSegments_PaymentPNRResultId",
                table: "PaymentPNRFlightSegment",
                newName: "IX_PaymentPNRFlightSegment_PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRFees_PaymentPNRResultId",
                table: "PaymentPNRFee",
                newName: "IX_PaymentPNRFee_PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRETicketInfos_PaymentPNRResultId",
                table: "PaymentPNRETicketInfo",
                newName: "IX_PaymentPNRETicketInfo_PaymentPNRResultId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPNRTax",
                table: "PaymentPNRTax",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPNRPassenger",
                table: "PaymentPNRPassenger",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPNRFlightSegment",
                table: "PaymentPNRFlightSegment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPNRFee",
                table: "PaymentPNRFee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPNRETicketInfo",
                table: "PaymentPNRETicketInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentPNRContact",
                table: "PaymentPNRContact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRETicketInfo_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRETicketInfo",
                column: "PaymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRFee_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRFee",
                column: "PaymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRFlightSegment_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRFlightSegment",
                column: "PaymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRPassenger_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRPassenger",
                column: "PaymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRResults_PaymentPNRContact_ContactId",
                table: "PaymentPNRResults",
                column: "ContactId",
                principalTable: "PaymentPNRContact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRTax_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRTax",
                column: "PaymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id");
        }
    }
}
