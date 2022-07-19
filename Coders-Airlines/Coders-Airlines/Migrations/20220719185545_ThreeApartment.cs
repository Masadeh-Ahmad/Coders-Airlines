using Microsoft.EntityFrameworkCore.Migrations;

namespace Coders_Airlines.Migrations
{
    public partial class ThreeApartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "ID", "City", "Description", "IsAvailable", "RentalCost", "Thumbnail" },
                values: new object[] { 1, "Amman", "Three bedrooms and two pathrooms with full view of Apdalli Towers in the middle of Amman", true, 500.0, null });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "ID", "City", "Description", "IsAvailable", "RentalCost", "Thumbnail" },
                values: new object[] { 2, "Amman", "Two master bedrooms and two teraes in the DownTowm of Amman", true, 700.0, null });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "ID", "City", "Description", "IsAvailable", "RentalCost", "Thumbnail" },
                values: new object[] { 3, "Paris", "Four bedrooms, two of them are masters and two indivisual pathrooms with full view of Evil Tower in the middle of Paris", true, 1500.0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
