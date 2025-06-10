using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class addmemberredemptiontransactiondetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberTransactionRedemptionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedemptionDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    RedemptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTransactionRedemptionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberTransactionRedemptionDetails_MemberAccrualTransactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "MemberAccrualTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberTransactionRedemptionDetails_MemberRedemptionTransactions_RedemptionId",
                        column: x => x.RedemptionId,
                        principalTable: "MemberRedemptionTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberTransactionRedemptionDetails_RedemptionId",
                table: "MemberTransactionRedemptionDetails",
                column: "RedemptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTransactionRedemptionDetails_TransactionId",
                table: "MemberTransactionRedemptionDetails",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberTransactionRedemptionDetails");
        }
    }
}
