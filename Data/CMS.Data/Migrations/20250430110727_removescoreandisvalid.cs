using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class removescoreandisvalid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "CustomForms");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "CustomForms");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSubmissionDate",
                table: "CustomForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumberofSubmistion",
                table: "CustomForms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastSubmissionDate",
                table: "CustomForms");

            migrationBuilder.DropColumn(
                name: "NumberofSubmistion",
                table: "CustomForms");

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "CustomForms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "CustomForms",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
