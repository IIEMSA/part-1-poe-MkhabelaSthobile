using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventEaseApp.Migrations
{
    /// <inheritdoc />
    public partial class RenameTablesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event__Venue_VenueID",
                table: "Event_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venue",
                table: "Venue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event_",
                table: "Event_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking",
                table: "Booking");

            migrationBuilder.RenameTable(
                name: "Venue",
                newName: "Venue_");

            migrationBuilder.RenameTable(
                name: "Event_",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "Booking",
                newName: "Booking_");

            migrationBuilder.RenameIndex(
                name: "IX_Event__VenueID",
                table: "Event",
                newName: "IX_Event_VenueID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venue_",
                table: "Venue_",
                column: "VenueID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "EventID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking_",
                table: "Booking_",
                column: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Venue__VenueID",
                table: "Event",
                column: "VenueID",
                principalTable: "Venue_",
                principalColumn: "VenueID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Venue__VenueID",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Venue_",
                table: "Venue_");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Booking_",
                table: "Booking_");

            migrationBuilder.RenameTable(
                name: "Venue_",
                newName: "Venue");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Event_");

            migrationBuilder.RenameTable(
                name: "Booking_",
                newName: "Booking");

            migrationBuilder.RenameIndex(
                name: "IX_Event_VenueID",
                table: "Event_",
                newName: "IX_Event__VenueID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Venue",
                table: "Venue",
                column: "VenueID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event_",
                table: "Event_",
                column: "EventID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Booking",
                table: "Booking",
                column: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event__Venue_VenueID",
                table: "Event_",
                column: "VenueID",
                principalTable: "Venue",
                principalColumn: "VenueID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
