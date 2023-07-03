using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeletedStation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Stations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 117, 177, 229, 204, 250, 202, 252, 32, 160, 60, 9, 62, 226, 247, 212, 37, 211, 83, 38, 240, 104, 73, 12, 40, 26, 133, 57, 253, 227, 38, 111, 119, 51, 125, 96, 112, 10, 157, 168, 55, 45, 96, 117, 74, 240, 181, 209, 254, 216, 148, 169, 45, 56, 246, 2, 254, 236, 213, 136, 172, 97, 144, 92, 190 }, new byte[] { 132, 27, 190, 135, 41, 178, 195, 233, 29, 163, 17, 9, 201, 119, 206, 135, 244, 159, 207, 4, 204, 168, 106, 249, 23, 178, 191, 189, 52, 108, 29, 111, 253, 195, 80, 83, 86, 4, 82, 163, 109, 41, 41, 234, 170, 49, 55, 206, 240, 9, 182, 93, 226, 191, 45, 133, 76, 161, 70, 86, 233, 149, 162, 101, 254, 208, 99, 3, 148, 151, 87, 231, 41, 68, 210, 174, 98, 112, 101, 160, 124, 209, 155, 64, 202, 84, 179, 40, 136, 61, 160, 116, 223, 140, 141, 255, 174, 59, 64, 54, 96, 132, 105, 21, 54, 168, 197, 177, 122, 78, 160, 72, 5, 123, 28, 235, 233, 171, 54, 233, 19, 73, 176, 162, 125, 84, 38, 4 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Stations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 116, 249, 29, 26, 101, 31, 243, 194, 190, 199, 205, 156, 56, 213, 51, 195, 26, 158, 54, 137, 232, 9, 78, 28, 104, 29, 44, 218, 226, 206, 146, 186, 67, 122, 148, 91, 5, 15, 71, 96, 132, 105, 238, 57, 123, 9, 57, 35, 219, 163, 39, 235, 105, 38, 33, 251, 199, 15, 81, 7, 235, 216, 220, 81 }, new byte[] { 66, 221, 49, 62, 72, 109, 4, 208, 130, 124, 77, 32, 175, 51, 187, 142, 39, 162, 197, 199, 138, 126, 120, 203, 136, 191, 24, 207, 67, 251, 234, 94, 86, 192, 149, 161, 35, 150, 50, 174, 223, 127, 191, 187, 128, 177, 37, 38, 78, 196, 24, 103, 21, 143, 117, 99, 115, 2, 135, 60, 200, 164, 166, 5, 64, 238, 214, 216, 93, 16, 104, 45, 230, 131, 94, 136, 13, 246, 185, 13, 171, 175, 112, 172, 179, 254, 198, 212, 243, 11, 181, 204, 74, 135, 36, 31, 90, 220, 53, 69, 229, 125, 159, 227, 74, 143, 170, 59, 148, 204, 221, 194, 107, 138, 153, 125, 47, 45, 133, 55, 253, 124, 246, 40, 63, 6, 151, 185 } });
        }
    }
}
