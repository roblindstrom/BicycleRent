using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace bicyclerent.data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<double>(type: "float", nullable: false),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Bicycles",
                columns: table => new
                {
                    BicycleId = table.Column<double>(type: "float", nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false),
                    BicycleBrand = table.Column<int>(type: "int", nullable: false),
                    BicycleSize = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycles", x => x.BicycleId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInformation",
                columns: table => new
                {
                    Customer_AdressID = table.Column<double>(type: "float", nullable: false),
                    PersonalID = table.Column<double>(type: "float", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInformation", x => x.Customer_AdressID);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookedBicycle = table.Column<double>(type: "float", nullable: false),
                    CustomerWithBooking = table.Column<double>(type: "float", nullable: false),
                    BookingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => new { x.BookedBicycle, x.CustomerWithBooking });
                    table.ForeignKey(
                        name: "FK_Bookings_Bicycles_BookedBicycle",
                        column: x => x.BookedBicycle,
                        principalTable: "Bicycles",
                        principalColumn: "BicycleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_CustomerInformation_CustomerWithBooking",
                        column: x => x.CustomerWithBooking,
                        principalTable: "CustomerInformation",
                        principalColumn: "Customer_AdressID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInformationAddresses",
                columns: table => new
                {
                    Customer_AddressID = table.Column<double>(type: "float", nullable: false),
                    AddressID = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInformationAddresses", x => new { x.AddressID, x.Customer_AddressID });
                    table.ForeignKey(
                        name: "FK_CustomerInformationAddresses_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerInformationAddresses_CustomerInformation_Customer_AddressID",
                        column: x => x.Customer_AddressID,
                        principalTable: "CustomerInformation",
                        principalColumn: "Customer_AdressID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerWithBooking",
                table: "Bookings",
                column: "CustomerWithBooking");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInformationAddresses_Customer_AddressID",
                table: "CustomerInformationAddresses",
                column: "Customer_AddressID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CustomerInformationAddresses");

            migrationBuilder.DropTable(
                name: "Bicycles");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CustomerInformation");
        }
    }
}
