using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class creditsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credits_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 103, 83, 95, 91, 126, 47, 81, 15, 224, 241, 47, 111, 160, 97, 124, 126, 173, 162, 239, 103, 182, 73, 159, 156, 126, 147, 55, 134, 37, 42, 94, 217, 24, 216, 243, 117, 31, 208, 80, 182, 127, 51, 255, 251, 66, 28, 247, 128, 50, 52, 163, 6, 51, 121, 163, 252, 74, 213, 237, 69, 6, 186, 158, 183 }, new byte[] { 131, 159, 5, 132, 167, 218, 85, 189, 50, 227, 181, 252, 72, 90, 91, 215, 4, 171, 4, 143, 111, 141, 211, 192, 242, 118, 5, 76, 6, 241, 79, 0, 223, 117, 36, 53, 186, 33, 38, 206, 224, 15, 138, 14, 240, 179, 118, 36, 112, 106, 241, 20, 220, 1, 64, 253, 45, 175, 38, 7, 184, 205, 141, 203, 129, 103, 125, 229, 22, 128, 184, 144, 172, 252, 53, 246, 15, 172, 59, 59, 209, 91, 12, 49, 232, 137, 232, 8, 240, 186, 72, 33, 57, 45, 23, 220, 11, 0, 66, 58, 240, 6, 210, 36, 76, 68, 70, 169, 20, 157, 49, 236, 100, 129, 18, 89, 175, 14, 87, 51, 229, 163, 59, 199, 115, 19, 37, 2 } });

            migrationBuilder.CreateIndex(
                name: "IX_Credits_UserId",
                table: "Credits",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credits");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 99, 19, 107, 216, 197, 138, 178, 64, 165, 59, 124, 68, 198, 221, 199, 126, 70, 67, 214, 232, 105, 31, 174, 154, 36, 89, 65, 213, 248, 127, 195, 178, 168, 230, 4, 18, 12, 128, 176, 83, 98, 209, 108, 167, 232, 118, 239, 200, 71, 243, 220, 193, 233, 171, 38, 126, 105, 155, 136, 72, 244, 30, 196, 237 }, new byte[] { 64, 108, 169, 92, 83, 161, 66, 200, 92, 157, 250, 49, 45, 210, 72, 57, 142, 168, 188, 39, 17, 54, 23, 215, 183, 133, 206, 113, 11, 222, 183, 232, 63, 35, 167, 153, 24, 112, 227, 173, 199, 217, 103, 55, 252, 117, 75, 234, 220, 70, 98, 167, 161, 227, 28, 113, 124, 125, 66, 68, 127, 91, 248, 85, 95, 241, 248, 48, 132, 35, 234, 148, 46, 7, 86, 197, 10, 44, 7, 115, 53, 6, 40, 147, 216, 129, 97, 155, 206, 149, 6, 20, 153, 158, 53, 69, 195, 29, 153, 70, 185, 54, 229, 248, 202, 254, 188, 15, 80, 210, 217, 85, 50, 236, 20, 98, 40, 119, 102, 233, 206, 240, 61, 130, 14, 131, 223, 113 } });
        }
    }
}
