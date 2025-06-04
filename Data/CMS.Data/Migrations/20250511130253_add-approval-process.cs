using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class addapprovalprocess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pages");

            migrationBuilder.AddColumn<string>(
                name: "ApprovalStatus",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedUserCode",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AwaitingApprovalUserCode",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "ApprovedUserCode",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "AwaitingApprovalUserCode",
                table: "Pages");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
