using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class bicycleIdInBreakdownChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breakdowns_Bicycles_BicycleId1",
                table: "Breakdowns");

            migrationBuilder.DropIndex(
                name: "IX_Breakdowns_BicycleId1",
                table: "Breakdowns");

            migrationBuilder.DropColumn(
                name: "BicycleId1",
                table: "Breakdowns");

            migrationBuilder.AlterColumn<string>(
                name: "BicycleId",
                table: "Breakdowns",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 55, 92, 82, 60, 230, 231, 45, 253, 154, 175, 148, 67, 234, 205, 99, 47, 30, 148, 164, 216, 219, 21, 230, 200, 24, 189, 241, 157, 215, 179, 104, 78, 183, 126, 123, 67, 20, 141, 165, 179, 37, 153, 6, 86, 150, 64, 194, 52, 118, 82, 239, 146, 2, 234, 145, 173, 176, 61, 164, 210, 55, 46, 99, 60 }, new byte[] { 124, 109, 149, 7, 132, 195, 226, 139, 77, 244, 107, 26, 14, 207, 193, 0, 155, 249, 188, 185, 140, 4, 79, 11, 131, 118, 26, 178, 73, 132, 139, 126, 180, 15, 139, 3, 170, 176, 178, 114, 236, 98, 254, 165, 192, 156, 23, 249, 173, 158, 60, 77, 163, 23, 180, 215, 60, 173, 195, 101, 119, 184, 31, 41, 130, 143, 128, 181, 170, 83, 19, 227, 211, 83, 74, 3, 164, 237, 68, 69, 44, 186, 63, 120, 66, 231, 123, 197, 164, 68, 3, 230, 20, 156, 80, 122, 23, 204, 166, 49, 83, 52, 156, 12, 12, 128, 224, 21, 5, 21, 82, 243, 214, 237, 161, 235, 133, 124, 34, 85, 188, 154, 8, 165, 171, 106, 91, 39 } });

            migrationBuilder.CreateIndex(
                name: "IX_Breakdowns_BicycleId",
                table: "Breakdowns",
                column: "BicycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breakdowns_Bicycles_BicycleId",
                table: "Breakdowns",
                column: "BicycleId",
                principalTable: "Bicycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breakdowns_Bicycles_BicycleId",
                table: "Breakdowns");

            migrationBuilder.DropIndex(
                name: "IX_Breakdowns_BicycleId",
                table: "Breakdowns");

            migrationBuilder.AlterColumn<int>(
                name: "BicycleId",
                table: "Breakdowns",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "BicycleId1",
                table: "Breakdowns",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Breakdowns_Bicycles_BicycleId1",
                table: "Breakdowns",
                column: "BicycleId1",
                principalTable: "Bicycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
