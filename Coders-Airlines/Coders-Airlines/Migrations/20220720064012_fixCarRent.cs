using Microsoft.EntityFrameworkCore.Migrations;

namespace Coders_Airlines.Migrations
{
    public partial class fixCarRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRentals_AspNetUsers_UserId",
                table: "CarRentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarRentals",
                table: "CarRentals");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CarRentals",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CarRentals",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarRentals",
                table: "CarRentals",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_CarID",
                table: "CarRentals",
                column: "CarID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRentals_AspNetUsers_UserId",
                table: "CarRentals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRentals_AspNetUsers_UserId",
                table: "CarRentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarRentals",
                table: "CarRentals");

            migrationBuilder.DropIndex(
                name: "IX_CarRentals_CarID",
                table: "CarRentals");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CarRentals");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CarRentals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarRentals",
                table: "CarRentals",
                columns: new[] { "CarID", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarRentals_AspNetUsers_UserId",
                table: "CarRentals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
