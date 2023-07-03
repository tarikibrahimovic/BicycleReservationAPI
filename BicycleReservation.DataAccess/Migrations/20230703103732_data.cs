using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "ForgotPasswordToken", "ImageUrl", "LastName", "PasswordHash", "PasswordSalt", "Role", "Username", "VerificationToken" },
                values: new object[] { -1, "admin@admin.com", "Admin", null, null, "Admin", new byte[] { 47, 245, 140, 243, 134, 215, 90, 29, 193, 103, 226, 234, 118, 21, 212, 114, 150, 37, 75, 145, 171, 209, 43, 216, 141, 205, 0, 194, 5, 52, 56, 77, 114, 143, 149, 99, 5, 194, 156, 249, 106, 148, 182, 6, 31, 164, 111, 141, 60, 105, 236, 161, 216, 135, 33, 127, 9, 233, 34, 176, 17, 246, 147, 87 }, new byte[] { 87, 43, 140, 98, 99, 22, 78, 13, 198, 32, 245, 25, 226, 203, 187, 254, 148, 228, 188, 197, 58, 241, 155, 135, 45, 197, 69, 206, 79, 106, 213, 111, 212, 157, 59, 131, 196, 215, 60, 100, 110, 12, 5, 209, 161, 35, 30, 204, 213, 120, 79, 143, 162, 103, 147, 82, 221, 159, 166, 140, 229, 234, 14, 163, 206, 166, 162, 20, 131, 92, 38, 104, 253, 141, 241, 244, 93, 40, 236, 103, 92, 50, 99, 237, 173, 238, 123, 33, 214, 84, 65, 12, 139, 151, 75, 147, 217, 139, 188, 83, 93, 133, 138, 99, 78, 158, 126, 183, 244, 127, 97, 72, 109, 163, 236, 181, 200, 27, 128, 140, 200, 207, 161, 199, 36, 240, 171, 163 }, 3, "admin", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
