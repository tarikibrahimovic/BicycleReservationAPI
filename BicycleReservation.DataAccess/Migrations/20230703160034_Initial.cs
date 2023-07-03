using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleReservation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bicycles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LockCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerificationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForgotPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BicycleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfHours = table.Column<int>(type: "int", nullable: true),
                    CostPerHour = table.Column<float>(type: "real", nullable: true),
                    StartStationId = table.Column<int>(type: "int", nullable: true),
                    EndStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_Bicycles_BicycleId",
                        column: x => x.BicycleId,
                        principalTable: "Bicycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Stations_EndStationId",
                        column: x => x.EndStationId,
                        principalTable: "Stations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Records_Stations_StartStationId",
                        column: x => x.StartStationId,
                        principalTable: "Stations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Records_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "ForgotPasswordToken", "ImageUrl", "LastName", "PasswordHash", "PasswordSalt", "Role", "Username", "VerificationToken" },
                values: new object[] { -1, "admin@admin.com", "Admin", null, null, "Admin", new byte[] { 99, 19, 107, 216, 197, 138, 178, 64, 165, 59, 124, 68, 198, 221, 199, 126, 70, 67, 214, 232, 105, 31, 174, 154, 36, 89, 65, 213, 248, 127, 195, 178, 168, 230, 4, 18, 12, 128, 176, 83, 98, 209, 108, 167, 232, 118, 239, 200, 71, 243, 220, 193, 233, 171, 38, 126, 105, 155, 136, 72, 244, 30, 196, 237 }, new byte[] { 64, 108, 169, 92, 83, 161, 66, 200, 92, 157, 250, 49, 45, 210, 72, 57, 142, 168, 188, 39, 17, 54, 23, 215, 183, 133, 206, 113, 11, 222, 183, 232, 63, 35, 167, 153, 24, 112, 227, 173, 199, 217, 103, 55, 252, 117, 75, 234, 220, 70, 98, 167, 161, 227, 28, 113, 124, 125, 66, 68, 127, 91, 248, 85, 95, 241, 248, 48, 132, 35, 234, 148, 46, 7, 86, 197, 10, 44, 7, 115, 53, 6, 40, 147, 216, 129, 97, 155, 206, 149, 6, 20, 153, 158, 53, 69, 195, 29, 153, 70, 185, 54, 229, 248, 202, 254, 188, 15, 80, 210, 217, 85, 50, 236, 20, 98, 40, 119, 102, 233, 206, 240, 61, 130, 14, 131, 223, 113 }, 3, "admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Records_BicycleId",
                table: "Records",
                column: "BicycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_EndStationId",
                table: "Records",
                column: "EndStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_StartStationId",
                table: "Records",
                column: "StartStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserId",
                table: "Records",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "Bicycles");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
