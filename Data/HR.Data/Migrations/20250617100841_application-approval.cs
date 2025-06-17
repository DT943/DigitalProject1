using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Data.Migrations
{
    /// <inheritdoc />
    public partial class applicationapproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "JobPosts");

            migrationBuilder.AddColumn<string>(
                name: "ApprovalStatus",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedUserCode",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AwaitingApprovalUserCode",
                table: "JobPosts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "ApprovedUserCode",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "AwaitingApprovalUserCode",
                table: "JobPosts");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "JobPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
