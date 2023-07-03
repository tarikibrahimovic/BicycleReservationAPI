using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class BoljeMnogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Naziv",
                table: "Bicycles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 118, 105, 13, 206, 62, 214, 106, 196, 52, 86, 37, 218, 50, 82, 10, 226, 187, 35, 213, 87, 250, 194, 113, 8, 146, 132, 141, 251, 115, 83, 124, 72, 105, 153, 18, 155, 239, 175, 249, 107, 12, 40, 160, 8, 139, 26, 148, 245, 137, 207, 32, 173, 25, 217, 167, 113, 193, 13, 111, 83, 72, 150, 191, 155 }, new byte[] { 76, 26, 174, 242, 94, 53, 226, 209, 34, 105, 39, 220, 156, 54, 156, 29, 117, 175, 98, 229, 124, 66, 124, 155, 21, 89, 173, 31, 161, 66, 189, 128, 59, 80, 235, 32, 46, 46, 87, 134, 18, 84, 180, 248, 99, 248, 8, 130, 178, 85, 238, 147, 166, 129, 168, 245, 211, 36, 74, 52, 117, 60, 32, 182, 123, 68, 134, 240, 191, 45, 153, 100, 31, 31, 145, 166, 170, 32, 152, 189, 141, 80, 89, 35, 245, 197, 214, 80, 38, 118, 124, 9, 17, 36, 111, 121, 135, 231, 55, 206, 53, 63, 142, 130, 196, 96, 215, 54, 52, 174, 180, 130, 144, 201, 239, 82, 4, 157, 55, 166, 97, 26, 3, 237, 37, 98, 243, 210 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Naziv",
                table: "Bicycles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 47, 245, 140, 243, 134, 215, 90, 29, 193, 103, 226, 234, 118, 21, 212, 114, 150, 37, 75, 145, 171, 209, 43, 216, 141, 205, 0, 194, 5, 52, 56, 77, 114, 143, 149, 99, 5, 194, 156, 249, 106, 148, 182, 6, 31, 164, 111, 141, 60, 105, 236, 161, 216, 135, 33, 127, 9, 233, 34, 176, 17, 246, 147, 87 }, new byte[] { 87, 43, 140, 98, 99, 22, 78, 13, 198, 32, 245, 25, 226, 203, 187, 254, 148, 228, 188, 197, 58, 241, 155, 135, 45, 197, 69, 206, 79, 106, 213, 111, 212, 157, 59, 131, 196, 215, 60, 100, 110, 12, 5, 209, 161, 35, 30, 204, 213, 120, 79, 143, 162, 103, 147, 82, 221, 159, 166, 140, 229, 234, 14, 163, 206, 166, 162, 20, 131, 92, 38, 104, 253, 141, 241, 244, 93, 40, 236, 103, 92, 50, 99, 237, 173, 238, 123, 33, 214, 84, 65, 12, 139, 151, 75, 147, 217, 139, 188, 83, 93, 133, 138, 99, 78, 158, 126, 183, 244, 127, 97, 72, 109, 163, 236, 181, 200, 27, 128, 140, 200, 207, 161, 199, 36, 240, 171, 163 } });
        }
    }
}
