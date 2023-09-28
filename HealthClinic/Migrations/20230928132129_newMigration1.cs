using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class newMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessHours",
                table: "Clinic");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ClosingTime",
                table: "Clinic",
                type: "TIME",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "OpeningTime",
                table: "Clinic",
                type: "TIME",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingTime",
                table: "Clinic");

            migrationBuilder.DropColumn(
                name: "OpeningTime",
                table: "Clinic");

            migrationBuilder.AddColumn<string>(
                name: "BusinessHours",
                table: "Clinic",
                type: "VARCHAR(10)",
                nullable: false,
                defaultValue: "");
        }
    }
}
