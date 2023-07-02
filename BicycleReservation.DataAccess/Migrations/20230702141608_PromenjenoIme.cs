using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class PromenjenoIme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Naziv",
                table: "Stations",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Stations",
                newName: "Naziv");
        }
    }
}
