using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaseStudy.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearlyPrice = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicianName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianPhone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    City = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    State = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProduct",
                columns: table => new
                {
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProduct", x => new { x.CustomersCustomerId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_CustomerProduct_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { "A", "United States" },
                    { "B", "Mexico" },
                    { "C", "Canada" },
                    { "D", "United Kingdom" },
                    { "E", "Australia" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductCode", "ProductName", "ReleaseDate", "YearlyPrice" },
                values: new object[,]
                {
                    { 1, "TRNY10", "Tournament Master 1.0", new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), 4.9900000000000002 },
                    { 2, "LEAG10", "League Scheduler 1.0", new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), 4.9900000000000002 },
                    { 3, "LEAGD10", "League Scheduler Deluxe 1.0", new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), 7.9900000000000002 },
                    { 4, "DRAFT10", "Draft Manager 1.0", new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), 4.9900000000000002 },
                    { 5, "TEAM10", "Team Manager 1.0", new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), 4.9900000000000002 },
                    { 6, "TRNY20", "Tournament Master 2.0", new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), 5.9900000000000002 },
                    { 7, "DRAFT20", "Draft Manager 2.0", new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Local), 5.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "TechnicianEmail", "TechnicianName", "TechnicianPhone" },
                values: new object[,]
                {
                    { -1, "", "", "" },
                    { 1, "alison@sportsprosoftware.com", "Alison Diaz", "800-555-0443" },
                    { 2, "awilson@sportsprosoftware.com", "Andrew Wilson", "800-555-0449" },
                    { 3, "gfiori@sportsprosoftware.com", "Gina Fiori", "800-555-0459" },
                    { 4, "gunter@sportsprosoftware.com", "Gunter Wendt", "800-555-0400" },
                    { 5, "jason@sportsprosoftware.com", "Jason Lee", "800-555-0444" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "CountryId", "EmailAddress", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "123 Spooner Street", "San Francisco", "A", "kanthoni@pge.com", "Kaitlyn", "Anthoni", "970-331-1691", "63141", "California" },
                    { 2, "123 Spooner Street", "Washington", "A", "ania@mma.nidc.com", "Ania", "Irvin", "970-331-1691", "63141", "California" },
                    { 3, "123 Spooner Street", "Mission Viejo", "B", null, "Gonzalo", "Keeton", "970-331-1691", "63141", "California" },
                    { 4, "123 Spooner Street", "Sacramento", "A", "amauro@yahoo.org", "Anton", "Mauro", "970-331-1691", "63141", "California" },
                    { 5, "123 Spooner Street", "Fresno", "A", "kmayte@fresno.ca.gov", "Kendall", "Mayte", "970-331-1691", "63141", "California" },
                    { 6, "123 Spooner Street", "Los Angeles", "A", "kenzie@mma.jobtrak.com", "Kenzie", "Quinn", "970-331-1691", "63141", "California" },
                    { 7, "123 Spooner Street", "Fresno", "A", "marvin@expedata.com", "Marvin", "Quintin", null, "63141", "California" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "CustomerId", "DateClosed", "DateOpened", "Description", "ProductId", "TechnicianId", "Title" },
                values: new object[,]
                {
                    { 1, 5, null, new DateTime(2023, 4, 21, 13, 17, 29, 308, DateTimeKind.Local).AddTicks(1281), "Program fails with error code 510, unable to open database.", 2, 4, "Error launching program" },
                    { 2, 2, null, new DateTime(2023, 4, 21, 13, 17, 29, 308, DateTimeKind.Local).AddTicks(1284), "Program fails with error code 510, unable to open database.", 7, 1, "Could not install" },
                    { 3, 3, null, new DateTime(2023, 4, 21, 13, 17, 29, 308, DateTimeKind.Local).AddTicks(1288), "Program fails with error code 510, unable to open database.", 1, 3, "Error launching program" },
                    { 4, 5, null, new DateTime(2023, 4, 21, 13, 17, 29, 308, DateTimeKind.Local).AddTicks(1291), "Program fails with error code 510, unable to open database.", 4, 2, "Program keeps crashing" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProduct_ProductsProductId",
                table: "CustomerProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CustomerId",
                table: "Incidents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ProductId",
                table: "Incidents",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechnicianId",
                table: "Incidents",
                column: "TechnicianId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProduct");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
