using Microsoft.EntityFrameworkCore.Migrations;

namespace Coders_Airlines.Migrations
{
    public partial class updateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumOfBags",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "NumOfBags",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumOfBags",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "NumOfBags",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
