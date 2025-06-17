using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyCandidateUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ExperienceItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExperienceItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ExperienceItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExperienceItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ExperienceItems");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "ExperienceItems");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "EducationItems");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EducationItems");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "EducationItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EducationItems");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "EducationItems");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EducationItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ProjectItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ProjectItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProjectItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProjectItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ProjectItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ProjectItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ExperienceItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ExperienceItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ExperienceItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExperienceItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ExperienceItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "ExperienceItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "EducationItems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "EducationItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "EducationItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EducationItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "EducationItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EducationItems",
                type: "datetime2",
                nullable: true);
        }
    }
}
