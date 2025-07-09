using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingEngine.Data.Migrations
{
    /// <inheritdoc />
    public partial class pos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "POS",
                table: "OTAUsers");

            migrationBuilder.AddColumn<int>(
                name: "POSId",
                table: "OTAUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OTAUsers_POSId",
                table: "OTAUsers",
                column: "POSId");

            migrationBuilder.AddForeignKey(
                name: "FK_OTAUsers_POSs_POSId",
                table: "OTAUsers",
                column: "POSId",
                principalTable: "POSs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OTAUsers_POSs_POSId",
                table: "OTAUsers");

            migrationBuilder.DropIndex(
                name: "IX_OTAUsers_POSId",
                table: "OTAUsers");

            migrationBuilder.DropColumn(
                name: "POSId",
                table: "OTAUsers");

            migrationBuilder.AddColumn<string>(
                name: "POS",
                table: "OTAUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
