using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedBicycleColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Naziv",
                table: "Bicycles",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 239, 166, 226, 42, 30, 105, 37, 153, 11, 80, 202, 69, 150, 8, 176, 243, 23, 125, 147, 251, 215, 196, 183, 225, 96, 42, 128, 247, 29, 96, 187, 177, 182, 47, 85, 15, 94, 247, 3, 63, 170, 14, 181, 60, 158, 224, 104, 84, 56, 43, 156, 236, 222, 76, 51, 166, 113, 17, 97, 109, 9, 181, 182, 200 }, new byte[] { 7, 105, 20, 249, 120, 132, 252, 117, 158, 13, 10, 79, 59, 15, 55, 77, 171, 116, 84, 39, 66, 207, 174, 4, 73, 101, 243, 125, 184, 19, 167, 43, 28, 132, 72, 22, 217, 203, 13, 190, 239, 202, 123, 80, 171, 138, 96, 210, 7, 133, 36, 134, 210, 42, 16, 82, 44, 34, 126, 9, 235, 162, 139, 227, 206, 196, 10, 238, 136, 180, 122, 34, 33, 211, 97, 113, 50, 200, 7, 219, 88, 82, 252, 129, 59, 229, 235, 113, 148, 61, 151, 172, 132, 151, 234, 30, 102, 225, 43, 87, 41, 49, 101, 59, 208, 14, 192, 121, 21, 222, 217, 209, 209, 35, 67, 111, 8, 6, 232, 150, 139, 194, 9, 89, 171, 154, 11, 71 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Bicycles",
                newName: "Naziv");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 47, 120, 80, 96, 224, 47, 80, 102, 250, 143, 224, 254, 136, 54, 86, 44, 9, 100, 155, 202, 194, 25, 143, 151, 238, 146, 244, 37, 149, 198, 225, 144, 109, 74, 196, 211, 113, 114, 146, 232, 20, 107, 222, 14, 233, 196, 205, 62, 133, 80, 119, 8, 65, 13, 161, 144, 104, 176, 121, 93, 208, 197, 167, 102 }, new byte[] { 7, 241, 106, 38, 166, 17, 31, 215, 105, 164, 231, 198, 195, 194, 80, 213, 241, 171, 42, 171, 120, 96, 19, 210, 253, 72, 182, 233, 96, 79, 145, 245, 192, 73, 224, 255, 29, 49, 115, 214, 111, 68, 74, 175, 71, 32, 78, 142, 80, 197, 26, 147, 61, 182, 145, 34, 10, 132, 106, 48, 139, 82, 118, 246, 36, 214, 124, 195, 142, 34, 102, 67, 6, 23, 52, 115, 143, 37, 4, 188, 42, 80, 86, 170, 162, 164, 21, 137, 149, 100, 181, 141, 128, 94, 29, 15, 107, 52, 31, 155, 226, 148, 36, 252, 75, 63, 202, 85, 75, 182, 249, 215, 48, 253, 211, 185, 102, 86, 65, 97, 110, 14, 157, 42, 198, 9, 175, 33 } });
        }
    }
}
