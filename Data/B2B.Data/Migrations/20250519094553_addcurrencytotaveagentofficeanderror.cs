using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace B2B.Data.Migrations
{
    /// <inheritdoc />
    public partial class addcurrencytotaveagentofficeanderror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirArabia");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "TravelAgentPOS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PNRDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PNR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PNRDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PNRDetails_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PNRDetails_ReservationId",
                table: "PNRDetails",
                column: "ReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PNRDetails");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "TravelAgentPOS");

            migrationBuilder.CreateTable(
                name: "AirArabia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    PNR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirArabia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirArabia_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirArabia_ReservationId",
                table: "AirArabia",
                column: "ReservationId");
        }
    }
}
