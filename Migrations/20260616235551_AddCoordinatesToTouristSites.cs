using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CamerounWonders.API.Migrations
{
    /// <inheritdoc />
    public partial class AddCoordinatesToTouristSites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "TouristSites",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "TouristSites",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "TouristSites");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "TouristSites");
        }
    }
}
