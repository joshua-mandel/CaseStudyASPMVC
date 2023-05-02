using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseStudy.Migrations
{
    /// <inheritdoc />
    public partial class Updatesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Technicians_TechnicianId",
                table: "Incidents");

            migrationBuilder.AlterColumn<int>(
                name: "TechnicianId",
                table: "Incidents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 1,
                column: "DateOpened",
                value: new DateTime(2023, 4, 21, 15, 0, 58, 589, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                column: "DateOpened",
                value: new DateTime(2023, 4, 21, 15, 0, 58, 589, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 3,
                column: "DateOpened",
                value: new DateTime(2023, 4, 21, 15, 0, 58, 589, DateTimeKind.Local).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 4,
                column: "DateOpened",
                value: new DateTime(2023, 4, 21, 15, 0, 58, 589, DateTimeKind.Local).AddTicks(7726));

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Technicians_TechnicianId",
                table: "Incidents",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "TechnicianId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Technicians_TechnicianId",
                table: "Incidents");

            migrationBuilder.AlterColumn<int>(
                name: "TechnicianId",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 1,
                column: "DateOpened",
                value: new DateTime(2023, 4, 21, 13, 19, 35, 110, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                column: "DateOpened",
                value: new DateTime(2023, 4, 21, 13, 19, 35, 110, DateTimeKind.Local).AddTicks(7839));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 3,
                column: "DateOpened",
                value: new DateTime(2023, 4, 21, 13, 19, 35, 110, DateTimeKind.Local).AddTicks(7842));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 4,
                column: "DateOpened",
                value: new DateTime(2023, 4, 21, 13, 19, 35, 110, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Technicians_TechnicianId",
                table: "Incidents",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "TechnicianId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
