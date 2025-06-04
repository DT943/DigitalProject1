using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Loyalty.Data.Migrations
{
    /// <inheritdoc />
    public partial class changememberdemoghraphyandprofile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CIS",
                table: "MemberTierDetails");

            migrationBuilder.AddColumn<int>(
                name: "MemberDemographicsAndProfileId",
                table: "MemberTierDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MemberTierDetails_MemberDemographicsAndProfileId",
                table: "MemberTierDetails",
                column: "MemberDemographicsAndProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTierDetails_TierId",
                table: "MemberTierDetails",
                column: "TierId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberTierDetails_MemberDemographicsAndProfiles_MemberDemographicsAndProfileId",
                table: "MemberTierDetails",
                column: "MemberDemographicsAndProfileId",
                principalTable: "MemberDemographicsAndProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberTierDetails_TierDetails_TierId",
                table: "MemberTierDetails",
                column: "TierId",
                principalTable: "TierDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberTierDetails_MemberDemographicsAndProfiles_MemberDemographicsAndProfileId",
                table: "MemberTierDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberTierDetails_TierDetails_TierId",
                table: "MemberTierDetails");

            migrationBuilder.DropIndex(
                name: "IX_MemberTierDetails_MemberDemographicsAndProfileId",
                table: "MemberTierDetails");

            migrationBuilder.DropIndex(
                name: "IX_MemberTierDetails_TierId",
                table: "MemberTierDetails");

            migrationBuilder.DropColumn(
                name: "MemberDemographicsAndProfileId",
                table: "MemberTierDetails");

            migrationBuilder.AddColumn<string>(
                name: "CIS",
                table: "MemberTierDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
