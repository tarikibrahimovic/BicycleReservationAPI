using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class isActiveUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "IsActive", "PasswordHash", "PasswordSalt" },
                values: new object[] { true, new byte[] { 47, 120, 80, 96, 224, 47, 80, 102, 250, 143, 224, 254, 136, 54, 86, 44, 9, 100, 155, 202, 194, 25, 143, 151, 238, 146, 244, 37, 149, 198, 225, 144, 109, 74, 196, 211, 113, 114, 146, 232, 20, 107, 222, 14, 233, 196, 205, 62, 133, 80, 119, 8, 65, 13, 161, 144, 104, 176, 121, 93, 208, 197, 167, 102 }, new byte[] { 7, 241, 106, 38, 166, 17, 31, 215, 105, 164, 231, 198, 195, 194, 80, 213, 241, 171, 42, 171, 120, 96, 19, 210, 253, 72, 182, 233, 96, 79, 145, 245, 192, 73, 224, 255, 29, 49, 115, 214, 111, 68, 74, 175, 71, 32, 78, 142, 80, 197, 26, 147, 61, 182, 145, 34, 10, 132, 106, 48, 139, 82, 118, 246, 36, 214, 124, 195, 142, 34, 102, 67, 6, 23, 52, 115, 143, 37, 4, 188, 42, 80, 86, 170, 162, 164, 21, 137, 149, 100, 181, 141, 128, 94, 29, 15, 107, 52, 31, 155, 226, 148, 36, 252, 75, 63, 202, 85, 75, 182, 249, 215, 48, 253, 211, 185, 102, 86, 65, 97, 110, 14, 157, 42, 198, 9, 175, 33 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 116, 249, 29, 26, 101, 31, 243, 194, 190, 199, 205, 156, 56, 213, 51, 195, 26, 158, 54, 137, 232, 9, 78, 28, 104, 29, 44, 218, 226, 206, 146, 186, 67, 122, 148, 91, 5, 15, 71, 96, 132, 105, 238, 57, 123, 9, 57, 35, 219, 163, 39, 235, 105, 38, 33, 251, 199, 15, 81, 7, 235, 216, 220, 81 }, new byte[] { 66, 221, 49, 62, 72, 109, 4, 208, 130, 124, 77, 32, 175, 51, 187, 142, 39, 162, 197, 199, 138, 126, 120, 203, 136, 191, 24, 207, 67, 251, 234, 94, 86, 192, 149, 161, 35, 150, 50, 174, 223, 127, 191, 187, 128, 177, 37, 38, 78, 196, 24, 103, 21, 143, 117, 99, 115, 2, 135, 60, 200, 164, 166, 5, 64, 238, 214, 216, 93, 16, 104, 45, 230, 131, 94, 136, 13, 246, 185, 13, 171, 175, 112, 172, 179, 254, 198, 212, 243, 11, 181, 204, 74, 135, 36, 31, 90, 220, 53, 69, 229, 125, 159, 227, 74, 143, 170, 59, 148, 204, 221, 194, 107, 138, 153, 125, 47, 45, 133, 55, 253, 124, 246, 40, 63, 6, 151, 185 } });
        }
    }
}
