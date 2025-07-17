using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class pymenrPNRAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FK_PaymentPNRTaxs_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRTaxs");

            migrationBuilder.RenameColumn(
                name: "PaymentPNRResultId",
                table: "PaymentPNRTaxs",
                newName: "paymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRTaxs_PaymentPNRResultId",
                table: "PaymentPNRTaxs",
                newName: "IX_PaymentPNRTaxs_paymentPNRResultId");

            migrationBuilder.RenameColumn(
                name: "PaymentPNRResultId",
                table: "PaymentPNRPassengers",
                newName: "paymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRPassengers_PaymentPNRResultId",
                table: "PaymentPNRPassengers",
                newName: "IX_PaymentPNRPassengers_paymentPNRResultId");

            migrationBuilder.RenameColumn(
                name: "PaymentPNRResultId",
                table: "PaymentPNRFlightSegments",
                newName: "paymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRFlightSegments_PaymentPNRResultId",
                table: "PaymentPNRFlightSegments",
                newName: "IX_PaymentPNRFlightSegments_paymentPNRResultId");

            migrationBuilder.RenameColumn(
                name: "PaymentPNRResultId",
                table: "PaymentPNRFees",
                newName: "paymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRFees_PaymentPNRResultId",
                table: "PaymentPNRFees",
                newName: "IX_PaymentPNRFees_paymentPNRResultId");

            migrationBuilder.RenameColumn(
                name: "PaymentPNRResultId",
                table: "PaymentPNRETicketInfos",
                newName: "paymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRETicketInfos_PaymentPNRResultId",
                table: "PaymentPNRETicketInfos",
                newName: "IX_PaymentPNRETicketInfos_paymentPNRResultId");

            migrationBuilder.AlterColumn<int>(
                name: "paymentPNRResultId",
                table: "PaymentPNRTaxs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "paymentPNRResultId",
                table: "PaymentPNRPassengers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "paymentPNRResultId",
                table: "PaymentPNRFlightSegments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "paymentPNRResultId",
                table: "PaymentPNRFees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "paymentPNRResultId",
                table: "PaymentPNRETicketInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRETicketInfos_PaymentPNRResults_paymentPNRResultId",
                table: "PaymentPNRETicketInfos",
                column: "paymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRFees_PaymentPNRResults_paymentPNRResultId",
                table: "PaymentPNRFees",
                column: "paymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRFlightSegments_PaymentPNRResults_paymentPNRResultId",
                table: "PaymentPNRFlightSegments",
                column: "paymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRPassengers_PaymentPNRResults_paymentPNRResultId",
                table: "PaymentPNRPassengers",
                column: "paymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentPNRTaxs_PaymentPNRResults_paymentPNRResultId",
                table: "PaymentPNRTaxs",
                column: "paymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRETicketInfos_PaymentPNRResults_paymentPNRResultId",
                table: "PaymentPNRETicketInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRFees_PaymentPNRResults_paymentPNRResultId",
                table: "PaymentPNRFees");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRFlightSegments_PaymentPNRResults_paymentPNRResultId",
                table: "PaymentPNRFlightSegments");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRPassengers_PaymentPNRResults_paymentPNRResultId",
                table: "PaymentPNRPassengers");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentPNRTaxs_PaymentPNRResults_paymentPNRResultId",
                table: "PaymentPNRTaxs");

            migrationBuilder.RenameColumn(
                name: "paymentPNRResultId",
                table: "PaymentPNRTaxs",
                newName: "PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRTaxs_paymentPNRResultId",
                table: "PaymentPNRTaxs",
                newName: "IX_PaymentPNRTaxs_PaymentPNRResultId");

            migrationBuilder.RenameColumn(
                name: "paymentPNRResultId",
                table: "PaymentPNRPassengers",
                newName: "PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRPassengers_paymentPNRResultId",
                table: "PaymentPNRPassengers",
                newName: "IX_PaymentPNRPassengers_PaymentPNRResultId");

            migrationBuilder.RenameColumn(
                name: "paymentPNRResultId",
                table: "PaymentPNRFlightSegments",
                newName: "PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRFlightSegments_paymentPNRResultId",
                table: "PaymentPNRFlightSegments",
                newName: "IX_PaymentPNRFlightSegments_PaymentPNRResultId");

            migrationBuilder.RenameColumn(
                name: "paymentPNRResultId",
                table: "PaymentPNRFees",
                newName: "PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRFees_paymentPNRResultId",
                table: "PaymentPNRFees",
                newName: "IX_PaymentPNRFees_PaymentPNRResultId");

            migrationBuilder.RenameColumn(
                name: "paymentPNRResultId",
                table: "PaymentPNRETicketInfos",
                newName: "PaymentPNRResultId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentPNRETicketInfos_paymentPNRResultId",
                table: "PaymentPNRETicketInfos",
                newName: "IX_PaymentPNRETicketInfos_PaymentPNRResultId");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentPNRResultId",
                table: "PaymentPNRTaxs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentPNRResultId",
                table: "PaymentPNRPassengers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentPNRResultId",
                table: "PaymentPNRFlightSegments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentPNRResultId",
                table: "PaymentPNRFees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentPNRResultId",
                table: "PaymentPNRETicketInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "FK_PaymentPNRTaxs_PaymentPNRResults_PaymentPNRResultId",
                table: "PaymentPNRTaxs",
                column: "PaymentPNRResultId",
                principalTable: "PaymentPNRResults",
                principalColumn: "Id");
        }
    }
}
