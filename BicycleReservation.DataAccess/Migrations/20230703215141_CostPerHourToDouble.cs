using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CostPerHourToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "CostPerHour",
                table: "Records",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 56, 240, 91, 29, 6, 139, 120, 251, 29, 37, 205, 126, 1, 223, 49, 230, 109, 194, 210, 111, 58, 137, 54, 118, 114, 76, 249, 45, 53, 26, 242, 196, 194, 136, 48, 212, 239, 107, 86, 77, 189, 208, 127, 223, 112, 10, 254, 205, 13, 74, 110, 127, 175, 205, 248, 42, 33, 90, 201, 34, 22, 66, 30, 176 }, new byte[] { 209, 135, 44, 98, 216, 31, 149, 243, 146, 192, 37, 123, 90, 138, 20, 138, 176, 116, 172, 67, 175, 204, 197, 128, 139, 36, 24, 204, 27, 144, 176, 239, 108, 131, 177, 37, 236, 211, 191, 130, 121, 188, 218, 178, 28, 83, 74, 212, 209, 4, 228, 238, 79, 232, 131, 200, 32, 70, 154, 190, 111, 99, 16, 40, 210, 237, 200, 105, 20, 15, 92, 140, 247, 247, 40, 84, 217, 114, 237, 49, 29, 122, 224, 71, 231, 169, 71, 144, 229, 208, 90, 141, 159, 79, 146, 62, 63, 58, 160, 10, 129, 209, 127, 2, 194, 210, 249, 53, 133, 178, 249, 192, 233, 92, 54, 38, 234, 9, 153, 234, 193, 127, 220, 153, 124, 93, 127, 78 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "CostPerHour",
                table: "Records",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 233, 252, 199, 246, 218, 29, 228, 57, 234, 34, 202, 102, 2, 75, 199, 186, 249, 18, 131, 60, 95, 11, 27, 72, 79, 211, 224, 242, 140, 134, 49, 208, 33, 114, 245, 185, 76, 97, 93, 21, 91, 91, 164, 98, 166, 198, 212, 133, 173, 59, 73, 217, 83, 58, 175, 127, 73, 217, 91, 195, 175, 116, 126, 15 }, new byte[] { 208, 217, 156, 91, 83, 172, 3, 34, 3, 87, 217, 33, 38, 120, 66, 192, 195, 216, 155, 146, 68, 153, 117, 176, 158, 81, 178, 198, 170, 188, 253, 174, 47, 186, 124, 253, 199, 165, 223, 226, 182, 99, 47, 76, 21, 93, 49, 74, 79, 166, 132, 230, 186, 242, 97, 68, 45, 16, 56, 191, 52, 140, 254, 90, 63, 222, 12, 123, 56, 247, 245, 178, 67, 246, 175, 166, 112, 0, 82, 149, 60, 237, 49, 125, 150, 40, 28, 209, 182, 202, 53, 167, 206, 0, 227, 42, 86, 100, 188, 255, 94, 13, 216, 86, 85, 226, 19, 28, 69, 98, 139, 150, 19, 27, 78, 244, 146, 16, 95, 75, 43, 49, 23, 167, 167, 176, 7, 47 } });
        }
    }
}
