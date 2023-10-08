using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRental.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalCostPerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalRentalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "IsAvailable", "RentalCostPerMonth", "Type" },
                values: new object[,]
                {
                    { new Guid("23c9e7a3-170f-45f6-a425-0f39241f05de"), "Cyber city, Gurugram", true, 10000m, "1BHK" },
                    { new Guid("4a558851-79ff-489e-bec3-2a512723a367"), "Budhha Colony, Patna", true, 15000m, "2BHK" },
                    { new Guid("e81065ab-1cfd-464a-92f7-5a7301ed943a"), "Habibganj, Bhopal", true, 22000m, "3BHK" },
                    { new Guid("f7f8b1ff-4c72-4925-8b17-892afd8b008a"), "Andrews Ganj, South Delhi", true, 20000m, "2BHK" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("28524ca4-3cf3-41fe-89a2-1db8bb141f97"), "admin2@mail.com", true, "Admin2", "Admin@123" },
                    { new Guid("7cb4f235-9d85-4fe0-8426-8341116c5831"), "sana@mail.com", false, "Sana", "Sana@123" },
                    { new Guid("e45cd3bf-4f06-468f-9326-80309bde66d0"), "admin1@mail.com", true, "Admin1", "Admin@123" },
                    { new Guid("f6531df2-077f-433e-a3bd-7e512b998f83"), "rohan@mail.com", false, "Rohan", "Rohan@123" },
                    { new Guid("f680c07a-5423-44c9-8f18-bb35d7d9e2be"), "aman@mail.com", false, "Aman", "Aman@123" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_HouseId",
                table: "Rentals",
                column: "HouseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
