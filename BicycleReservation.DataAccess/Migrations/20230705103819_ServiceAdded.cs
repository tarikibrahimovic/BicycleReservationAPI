using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ServiceAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BicycleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Bicycles_BicycleId",
                        column: x => x.BicycleId,
                        principalTable: "Bicycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_Users_UserId",
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
                values: new object[] { new byte[] { 202, 39, 53, 62, 214, 90, 142, 97, 227, 254, 62, 67, 11, 86, 64, 42, 178, 207, 198, 91, 227, 161, 35, 125, 24, 86, 91, 30, 66, 55, 146, 139, 202, 103, 105, 144, 22, 45, 232, 74, 190, 139, 237, 38, 185, 18, 163, 211, 104, 238, 238, 151, 35, 21, 7, 25, 73, 30, 59, 156, 160, 248, 188, 78 }, new byte[] { 138, 159, 24, 32, 202, 229, 37, 75, 198, 195, 56, 131, 211, 150, 57, 77, 205, 92, 93, 67, 124, 183, 181, 159, 22, 28, 173, 191, 82, 61, 18, 57, 251, 186, 204, 65, 30, 178, 171, 243, 156, 224, 182, 76, 86, 35, 130, 133, 186, 165, 134, 178, 116, 147, 17, 161, 186, 91, 100, 249, 175, 48, 207, 163, 168, 135, 194, 26, 8, 75, 160, 97, 189, 198, 89, 80, 112, 189, 173, 173, 245, 167, 1, 11, 178, 11, 8, 216, 12, 205, 16, 43, 161, 110, 56, 157, 135, 164, 148, 2, 92, 190, 51, 133, 72, 175, 221, 67, 28, 136, 163, 222, 84, 26, 77, 67, 222, 90, 156, 204, 227, 154, 149, 96, 159, 66, 116, 200 } });

            migrationBuilder.CreateIndex(
                name: "IX_Services_BicycleId",
                table: "Services",
                column: "BicycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId",
                table: "Services",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 55, 92, 82, 60, 230, 231, 45, 253, 154, 175, 148, 67, 234, 205, 99, 47, 30, 148, 164, 216, 219, 21, 230, 200, 24, 189, 241, 157, 215, 179, 104, 78, 183, 126, 123, 67, 20, 141, 165, 179, 37, 153, 6, 86, 150, 64, 194, 52, 118, 82, 239, 146, 2, 234, 145, 173, 176, 61, 164, 210, 55, 46, 99, 60 }, new byte[] { 124, 109, 149, 7, 132, 195, 226, 139, 77, 244, 107, 26, 14, 207, 193, 0, 155, 249, 188, 185, 140, 4, 79, 11, 131, 118, 26, 178, 73, 132, 139, 126, 180, 15, 139, 3, 170, 176, 178, 114, 236, 98, 254, 165, 192, 156, 23, 249, 173, 158, 60, 77, 163, 23, 180, 215, 60, 173, 195, 101, 119, 184, 31, 41, 130, 143, 128, 181, 170, 83, 19, 227, 211, 83, 74, 3, 164, 237, 68, 69, 44, 186, 63, 120, 66, 231, 123, 197, 164, 68, 3, 230, 20, 156, 80, 122, 23, 204, 166, 49, 83, 52, 156, 12, 12, 128, 224, 21, 5, 21, 82, 243, 214, 237, 161, 235, 133, 124, 34, 85, 188, 154, 8, 165, 171, 106, 91, 39 } });
        }
    }
}
