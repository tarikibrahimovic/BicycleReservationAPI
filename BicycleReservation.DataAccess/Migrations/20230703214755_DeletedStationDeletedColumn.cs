using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DeletedStationDeletedColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Stations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 233, 252, 199, 246, 218, 29, 228, 57, 234, 34, 202, 102, 2, 75, 199, 186, 249, 18, 131, 60, 95, 11, 27, 72, 79, 211, 224, 242, 140, 134, 49, 208, 33, 114, 245, 185, 76, 97, 93, 21, 91, 91, 164, 98, 166, 198, 212, 133, 173, 59, 73, 217, 83, 58, 175, 127, 73, 217, 91, 195, 175, 116, 126, 15 }, new byte[] { 208, 217, 156, 91, 83, 172, 3, 34, 3, 87, 217, 33, 38, 120, 66, 192, 195, 216, 155, 146, 68, 153, 117, 176, 158, 81, 178, 198, 170, 188, 253, 174, 47, 186, 124, 253, 199, 165, 223, 226, 182, 99, 47, 76, 21, 93, 49, 74, 79, 166, 132, 230, 186, 242, 97, 68, 45, 16, 56, 191, 52, 140, 254, 90, 63, 222, 12, 123, 56, 247, 245, 178, 67, 246, 175, 166, 112, 0, 82, 149, 60, 237, 49, 125, 150, 40, 28, 209, 182, 202, 53, 167, 206, 0, 227, 42, 86, 100, 188, 255, 94, 13, 216, 86, 85, 226, 19, 28, 69, 98, 139, 150, 19, 27, 78, 244, 146, 16, 95, 75, 43, 49, 23, 167, 167, 176, 7, 47 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
