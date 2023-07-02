using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class renamingPasswordSalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassswordSalt",
                table: "Users",
                newName: "PasswordSalt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordSalt",
                table: "Users",
                newName: "PassswordSalt");
        }
    }
}
