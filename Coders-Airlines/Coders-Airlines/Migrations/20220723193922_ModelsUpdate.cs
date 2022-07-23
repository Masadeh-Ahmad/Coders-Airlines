using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Coders_Airlines.Migrations
{
    public partial class ModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentRentals_AspNetUsers_UserId",
                table: "ApartmentRentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentRentals",
                table: "ApartmentRentals");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "To",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarRentals",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "SeatsLeft",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "NumOfSeats",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ApartmentRentals",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ApartmentRentals",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentRentals",
                table: "ApartmentRentals",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightID",
                table: "Bookings",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentRentals_ApartmentID",
                table: "ApartmentRentals",
                column: "ApartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentRentals_AspNetUsers_UserId",
                table: "ApartmentRentals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentRentals_AspNetUsers_UserId",
                table: "ApartmentRentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_FlightID",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentRentals",
                table: "ApartmentRentals");

            migrationBuilder.DropIndex(
                name: "IX_ApartmentRentals_ApartmentID",
                table: "ApartmentRentals");

            migrationBuilder.DropColumn(
                name: "SeatsLeft",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "NumOfSeats",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ApartmentRentals");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CarRentals",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ApartmentRentals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                columns: new[] { "FlightID", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentRentals",
                table: "ApartmentRentals",
                columns: new[] { "ApartmentID", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentRentals_AspNetUsers_UserId",
                table: "ApartmentRentals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
