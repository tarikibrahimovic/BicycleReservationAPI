using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class isGoogle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGoogle",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "IsGoogle", "PasswordHash", "PasswordSalt" },
                values: new object[] { false, new byte[] { 208, 5, 23, 181, 192, 215, 128, 0, 131, 91, 232, 32, 199, 57, 222, 82, 184, 139, 107, 198, 93, 94, 170, 195, 214, 128, 188, 11, 134, 61, 113, 80, 215, 21, 253, 156, 232, 209, 147, 229, 68, 78, 181, 100, 123, 126, 178, 245, 84, 232, 235, 202, 130, 204, 27, 193, 233, 102, 213, 229, 137, 40, 29, 252 }, new byte[] { 7, 227, 69, 217, 121, 83, 117, 13, 217, 63, 33, 95, 37, 206, 3, 73, 59, 127, 82, 28, 206, 36, 163, 176, 92, 110, 86, 71, 65, 14, 92, 161, 51, 206, 183, 114, 247, 177, 10, 218, 58, 7, 245, 52, 115, 152, 177, 27, 29, 20, 107, 239, 198, 48, 87, 249, 4, 169, 45, 132, 179, 59, 91, 55, 252, 136, 200, 189, 220, 40, 82, 9, 217, 136, 92, 199, 77, 135, 110, 11, 192, 151, 116, 80, 96, 31, 233, 147, 36, 242, 227, 39, 236, 243, 254, 192, 197, 183, 72, 193, 136, 84, 255, 237, 248, 173, 179, 44, 121, 250, 192, 25, 106, 120, 114, 89, 215, 4, 160, 172, 72, 50, 223, 132, 254, 124, 21, 227 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGoogle",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 202, 39, 53, 62, 214, 90, 142, 97, 227, 254, 62, 67, 11, 86, 64, 42, 178, 207, 198, 91, 227, 161, 35, 125, 24, 86, 91, 30, 66, 55, 146, 139, 202, 103, 105, 144, 22, 45, 232, 74, 190, 139, 237, 38, 185, 18, 163, 211, 104, 238, 238, 151, 35, 21, 7, 25, 73, 30, 59, 156, 160, 248, 188, 78 }, new byte[] { 138, 159, 24, 32, 202, 229, 37, 75, 198, 195, 56, 131, 211, 150, 57, 77, 205, 92, 93, 67, 124, 183, 181, 159, 22, 28, 173, 191, 82, 61, 18, 57, 251, 186, 204, 65, 30, 178, 171, 243, 156, 224, 182, 76, 86, 35, 130, 133, 186, 165, 134, 178, 116, 147, 17, 161, 186, 91, 100, 249, 175, 48, 207, 163, 168, 135, 194, 26, 8, 75, 160, 97, 189, 198, 89, 80, 112, 189, 173, 173, 245, 167, 1, 11, 178, 11, 8, 216, 12, 205, 16, 43, 161, 110, 56, 157, 135, 164, 148, 2, 92, 190, 51, 133, 72, 175, 221, 67, 28, 136, 163, 222, 84, 26, 77, 67, 222, 90, 156, 204, 227, 154, 149, 96, 159, 66, 116, 200 } });
        }
    }
}
