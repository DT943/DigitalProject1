using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyCandidate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationItems_Candidates_CandidateId",
                table: "EducationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceItems_Candidates_CandidateId",
                table: "ExperienceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItems_Candidates_CandidateId",
                table: "ProjectItems");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "ProjectItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProjectItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "JobPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "ExperienceItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExperienceItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "EducationItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EducationItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Candidates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationItems_Candidates_CandidateId",
                table: "EducationItems",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceItems_Candidates_CandidateId",
                table: "ExperienceItems",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItems_Candidates_CandidateId",
                table: "ProjectItems",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationItems_Candidates_CandidateId",
                table: "EducationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ExperienceItems_Candidates_CandidateId",
                table: "ExperienceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItems_Candidates_CandidateId",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProjectItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "JobPosts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExperienceItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EducationItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Candidates");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Applications");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "ProjectItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "ExperienceItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "EducationItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationItems_Candidates_CandidateId",
                table: "EducationItems",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperienceItems_Candidates_CandidateId",
                table: "ExperienceItems",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItems_Candidates_CandidateId",
                table: "ProjectItems",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id");
        }
    }
}
