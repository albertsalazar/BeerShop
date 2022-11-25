using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerShop.Migrations
{
    /// <inheritdoc />
    public partial class sponsoredBeersAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl",
                table: "Beers");

            migrationBuilder.AddColumn<bool>(
                name: "isSponsoredBeer",
                table: "Beers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSponsoredBeer",
                table: "Beers");

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl",
                table: "Beers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
