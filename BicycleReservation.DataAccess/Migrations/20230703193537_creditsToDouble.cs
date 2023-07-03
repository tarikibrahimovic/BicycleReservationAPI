using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class creditsToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Credits",
                table: "Credits",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 116, 249, 29, 26, 101, 31, 243, 194, 190, 199, 205, 156, 56, 213, 51, 195, 26, 158, 54, 137, 232, 9, 78, 28, 104, 29, 44, 218, 226, 206, 146, 186, 67, 122, 148, 91, 5, 15, 71, 96, 132, 105, 238, 57, 123, 9, 57, 35, 219, 163, 39, 235, 105, 38, 33, 251, 199, 15, 81, 7, 235, 216, 220, 81 }, new byte[] { 66, 221, 49, 62, 72, 109, 4, 208, 130, 124, 77, 32, 175, 51, 187, 142, 39, 162, 197, 199, 138, 126, 120, 203, 136, 191, 24, 207, 67, 251, 234, 94, 86, 192, 149, 161, 35, 150, 50, 174, 223, 127, 191, 187, 128, 177, 37, 38, 78, 196, 24, 103, 21, 143, 117, 99, 115, 2, 135, 60, 200, 164, 166, 5, 64, 238, 214, 216, 93, 16, 104, 45, 230, 131, 94, 136, 13, 246, 185, 13, 171, 175, 112, 172, 179, 254, 198, 212, 243, 11, 181, 204, 74, 135, 36, 31, 90, 220, 53, 69, 229, 125, 159, 227, 74, 143, 170, 59, 148, 204, 221, 194, 107, 138, 153, 125, 47, 45, 133, 55, 253, 124, 246, 40, 63, 6, 151, 185 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Credits",
                table: "Credits",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 103, 83, 95, 91, 126, 47, 81, 15, 224, 241, 47, 111, 160, 97, 124, 126, 173, 162, 239, 103, 182, 73, 159, 156, 126, 147, 55, 134, 37, 42, 94, 217, 24, 216, 243, 117, 31, 208, 80, 182, 127, 51, 255, 251, 66, 28, 247, 128, 50, 52, 163, 6, 51, 121, 163, 252, 74, 213, 237, 69, 6, 186, 158, 183 }, new byte[] { 131, 159, 5, 132, 167, 218, 85, 189, 50, 227, 181, 252, 72, 90, 91, 215, 4, 171, 4, 143, 111, 141, 211, 192, 242, 118, 5, 76, 6, 241, 79, 0, 223, 117, 36, 53, 186, 33, 38, 206, 224, 15, 138, 14, 240, 179, 118, 36, 112, 106, 241, 20, 220, 1, 64, 253, 45, 175, 38, 7, 184, 205, 141, 203, 129, 103, 125, 229, 22, 128, 184, 144, 172, 252, 53, 246, 15, 172, 59, 59, 209, 91, 12, 49, 232, 137, 232, 8, 240, 186, 72, 33, 57, 45, 23, 220, 11, 0, 66, 58, 240, 6, 210, 36, 76, 68, 70, 169, 20, 157, 49, 236, 100, 129, 18, 89, 175, 14, 87, 51, 229, 163, 59, 199, 115, 19, 37, 2 } });
        }
    }
}
