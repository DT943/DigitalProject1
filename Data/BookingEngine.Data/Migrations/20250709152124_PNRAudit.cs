using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class PNRAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookFlightSegments_InquirePNRResponse_InquirePNRResponseId",
                table: "BookFlightSegments");

            migrationBuilder.DropForeignKey(
                name: "FK_BookPassengers_InquirePNRResponse_InquirePNRResponseId",
                table: "BookPassengers");

            migrationBuilder.DropForeignKey(
                name: "FK_InquirePNRResponse_BookContactInfos_ContactInfoId",
                table: "InquirePNRResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_InquirePNRResponse_BookFares_FareId",
                table: "InquirePNRResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_InquirePNRResponse_BookPassengerCounts_PassengerCountsId",
                table: "InquirePNRResponse");

            migrationBuilder.DropForeignKey(
                name: "FK_InquirePNRs_InquirePNRResponse_InquirePNRResponseId",
                table: "InquirePNRs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InquirePNRResponse",
                table: "InquirePNRResponse");

            migrationBuilder.RenameTable(
                name: "InquirePNRResponse",
                newName: "InquirePNRResponses");

            migrationBuilder.RenameIndex(
                name: "IX_InquirePNRResponse_PassengerCountsId",
                table: "InquirePNRResponses",
                newName: "IX_InquirePNRResponses_PassengerCountsId");

            migrationBuilder.RenameIndex(
                name: "IX_InquirePNRResponse_FareId",
                table: "InquirePNRResponses",
                newName: "IX_InquirePNRResponses_FareId");

            migrationBuilder.RenameIndex(
                name: "IX_InquirePNRResponse_ContactInfoId",
                table: "InquirePNRResponses",
                newName: "IX_InquirePNRResponses_ContactInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InquirePNRResponses",
                table: "InquirePNRResponses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookFlightSegments_InquirePNRResponses_InquirePNRResponseId",
                table: "BookFlightSegments",
                column: "InquirePNRResponseId",
                principalTable: "InquirePNRResponses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPassengers_InquirePNRResponses_InquirePNRResponseId",
                table: "BookPassengers",
                column: "InquirePNRResponseId",
                principalTable: "InquirePNRResponses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InquirePNRResponses_BookContactInfos_ContactInfoId",
                table: "InquirePNRResponses",
                column: "ContactInfoId",
                principalTable: "BookContactInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InquirePNRResponses_BookFares_FareId",
                table: "InquirePNRResponses",
                column: "FareId",
                principalTable: "BookFares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InquirePNRResponses_BookPassengerCounts_PassengerCountsId",
                table: "InquirePNRResponses",
                column: "PassengerCountsId",
                principalTable: "BookPassengerCounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InquirePNRs_InquirePNRResponses_InquirePNRResponseId",
                table: "InquirePNRs",
                column: "InquirePNRResponseId",
                principalTable: "InquirePNRResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookFlightSegments_InquirePNRResponses_InquirePNRResponseId",
                table: "BookFlightSegments");

            migrationBuilder.DropForeignKey(
                name: "FK_BookPassengers_InquirePNRResponses_InquirePNRResponseId",
                table: "BookPassengers");

            migrationBuilder.DropForeignKey(
                name: "FK_InquirePNRResponses_BookContactInfos_ContactInfoId",
                table: "InquirePNRResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_InquirePNRResponses_BookFares_FareId",
                table: "InquirePNRResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_InquirePNRResponses_BookPassengerCounts_PassengerCountsId",
                table: "InquirePNRResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_InquirePNRs_InquirePNRResponses_InquirePNRResponseId",
                table: "InquirePNRs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InquirePNRResponses",
                table: "InquirePNRResponses");

            migrationBuilder.RenameTable(
                name: "InquirePNRResponses",
                newName: "InquirePNRResponse");

            migrationBuilder.RenameIndex(
                name: "IX_InquirePNRResponses_PassengerCountsId",
                table: "InquirePNRResponse",
                newName: "IX_InquirePNRResponse_PassengerCountsId");

            migrationBuilder.RenameIndex(
                name: "IX_InquirePNRResponses_FareId",
                table: "InquirePNRResponse",
                newName: "IX_InquirePNRResponse_FareId");

            migrationBuilder.RenameIndex(
                name: "IX_InquirePNRResponses_ContactInfoId",
                table: "InquirePNRResponse",
                newName: "IX_InquirePNRResponse_ContactInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InquirePNRResponse",
                table: "InquirePNRResponse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookFlightSegments_InquirePNRResponse_InquirePNRResponseId",
                table: "BookFlightSegments",
                column: "InquirePNRResponseId",
                principalTable: "InquirePNRResponse",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPassengers_InquirePNRResponse_InquirePNRResponseId",
                table: "BookPassengers",
                column: "InquirePNRResponseId",
                principalTable: "InquirePNRResponse",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InquirePNRResponse_BookContactInfos_ContactInfoId",
                table: "InquirePNRResponse",
                column: "ContactInfoId",
                principalTable: "BookContactInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InquirePNRResponse_BookFares_FareId",
                table: "InquirePNRResponse",
                column: "FareId",
                principalTable: "BookFares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InquirePNRResponse_BookPassengerCounts_PassengerCountsId",
                table: "InquirePNRResponse",
                column: "PassengerCountsId",
                principalTable: "BookPassengerCounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InquirePNRs_InquirePNRResponse_InquirePNRResponseId",
                table: "InquirePNRs",
                column: "InquirePNRResponseId",
                principalTable: "InquirePNRResponse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
