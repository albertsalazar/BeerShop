using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerShop.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isSponsoredBeer",
                table: "Beers",
                newName: "IsSponsoredBeer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsSponsoredBeer",
                table: "Beers",
                newName: "isSponsoredBeer");
        }
    }
}
