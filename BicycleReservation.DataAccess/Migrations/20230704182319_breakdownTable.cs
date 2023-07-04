using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class breakdownTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breakdowns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResolvedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BicycleId = table.Column<int>(type: "int", nullable: false),
                    BicycleId1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakdowns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breakdowns_Bicycles_BicycleId1",
                        column: x => x.BicycleId1,
                        principalTable: "Bicycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 183, 78, 53, 122, 54, 99, 207, 93, 236, 124, 155, 192, 233, 131, 217, 43, 31, 166, 93, 7, 97, 8, 60, 54, 56, 81, 221, 186, 112, 251, 242, 180, 159, 158, 88, 112, 9, 67, 59, 14, 90, 174, 198, 180, 134, 213, 243, 59, 120, 246, 223, 140, 74, 89, 252, 122, 205, 76, 60, 44, 128, 0, 224, 92 }, new byte[] { 160, 87, 23, 103, 69, 218, 235, 248, 220, 122, 6, 144, 8, 0, 9, 126, 52, 74, 141, 10, 26, 183, 22, 189, 36, 67, 12, 44, 107, 102, 111, 230, 64, 26, 190, 95, 207, 178, 58, 184, 242, 121, 98, 82, 172, 49, 144, 206, 198, 92, 141, 208, 72, 206, 93, 120, 128, 170, 231, 127, 175, 55, 57, 129, 231, 108, 120, 182, 6, 247, 85, 167, 137, 19, 45, 27, 13, 35, 9, 137, 158, 59, 168, 3, 250, 237, 244, 132, 209, 222, 28, 70, 17, 146, 55, 25, 132, 132, 1, 38, 220, 3, 234, 54, 149, 106, 199, 253, 89, 24, 188, 206, 115, 65, 4, 189, 115, 38, 38, 113, 201, 45, 230, 63, 87, 232, 11, 76 } });

            migrationBuilder.CreateIndex(
                name: "IX_Breakdowns_BicycleId1",
                table: "Breakdowns",
                column: "BicycleId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breakdowns");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 239, 166, 226, 42, 30, 105, 37, 153, 11, 80, 202, 69, 150, 8, 176, 243, 23, 125, 147, 251, 215, 196, 183, 225, 96, 42, 128, 247, 29, 96, 187, 177, 182, 47, 85, 15, 94, 247, 3, 63, 170, 14, 181, 60, 158, 224, 104, 84, 56, 43, 156, 236, 222, 76, 51, 166, 113, 17, 97, 109, 9, 181, 182, 200 }, new byte[] { 7, 105, 20, 249, 120, 132, 252, 117, 158, 13, 10, 79, 59, 15, 55, 77, 171, 116, 84, 39, 66, 207, 174, 4, 73, 101, 243, 125, 184, 19, 167, 43, 28, 132, 72, 22, 217, 203, 13, 190, 239, 202, 123, 80, 171, 138, 96, 210, 7, 133, 36, 134, 210, 42, 16, 82, 44, 34, 126, 9, 235, 162, 139, 227, 206, 196, 10, 238, 136, 180, 122, 34, 33, 211, 97, 113, 50, 200, 7, 219, 88, 82, 252, 129, 59, 229, 235, 113, 148, 61, 151, 172, 132, 151, 234, 30, 102, 225, 43, 87, 41, 49, 101, 59, 208, 14, 192, 121, 21, 222, 217, 209, 209, 35, 67, 111, 8, 6, 232, 150, 139, 194, 9, 89, 171, 154, 11, 71 } });
        }
    }
}
