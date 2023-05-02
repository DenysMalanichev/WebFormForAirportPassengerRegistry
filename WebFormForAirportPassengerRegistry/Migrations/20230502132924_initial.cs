using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebFormForAirportPassengerRegistry.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Citizenship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthplace = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: false),
                    Sex = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Residency = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Communication = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Passenge__3214EC07C3489574", x => x.PassengerId);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    TerminalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Terminal__3214EC07DAC12DA3", x => x.TerminalId);
                });

            migrationBuilder.CreateTable(
                name: "Visas",
                columns: table => new
                {
                    VisaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisaType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ValidTill = table.Column<DateTime>(type: "date", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Visas__3214EC072705346A", x => x.VisaId);
                });

            migrationBuilder.CreateTable(
                name: "Searches",
                columns: table => new
                {
                    SearchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSince = table.Column<DateTime>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "date", nullable: true),
                    Sex = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Searches__3214EC07B643ECEC", x => x.SearchId);
                    table.ForeignKey(
                        name: "FK__Searches__Passen__534D60F1",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "PassengerId");
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatsNum = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PlaceOfDeparture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlaceOfArrival = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TerminalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Flights__3214EC07FA2F02A4", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK__Flights__Termina__440B1D61",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "TerminalId");
                });

            migrationBuilder.CreateTable(
                name: "FlightTickets",
                columns: table => new
                {
                    FlightTicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LuggageVolume = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    LuggageWeight = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Class = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    Seat = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: true),
                    VisaId = table.Column<int>(type: "int", nullable: true),
                    PassengerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FlightTi__3214EC073707D734", x => x.FlightTicketId);
                    table.ForeignKey(
                        name: "FK__FlightTic__Fligh__4D94879B",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId");
                    table.ForeignKey(
                        name: "FK__FlightTic__Passe__4F7CD00D",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "PassengerId");
                    table.ForeignKey(
                        name: "FK__FlightTick__Visa__4E88ABD4",
                        column: x => x.VisaId,
                        principalTable: "Visas",
                        principalColumn: "VisaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_TerminalId",
                table: "Flights",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTickets_FlightId",
                table: "FlightTickets",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTickets_PassengerId",
                table: "FlightTickets",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightTickets_VisaId",
                table: "FlightTickets",
                column: "VisaId");

            migrationBuilder.CreateIndex(
                name: "IX_Searches_PassengerId",
                table: "Searches",
                column: "PassengerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightTickets");

            migrationBuilder.DropTable(
                name: "Searches");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Visas");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Terminals");
        }
    }
}
