using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.Migrations
{
    /// <inheritdoc />
    public partial class initb2b : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "B2B");

            migrationBuilder.CreateTable(
                name: "TravelAgentOffices",
                schema: "B2B",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TravelAgentNameISA = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    AgencyName = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    FirstEmail = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SecoundEmail = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    POS = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Governate = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    VideoFileCode = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    VideoFileUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ImageFileCode = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ImageFileUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PdfFileCode = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    PdfFileUrl = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UserCode = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ManagerCode = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    SYD = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    SYP = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgentOffices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelAgentOffices",
                schema: "B2B");
        }
    }
}
