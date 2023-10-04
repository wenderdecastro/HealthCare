using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthClinic.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClinicId",
                table: "MedicalAppointment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MedicalAppointment_ClinicId",
                table: "MedicalAppointment",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointment_Clinic_ClinicId",
                table: "MedicalAppointment",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "ClinicId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointment_Clinic_ClinicId",
                table: "MedicalAppointment");

            migrationBuilder.DropIndex(
                name: "IX_MedicalAppointment_ClinicId",
                table: "MedicalAppointment");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "MedicalAppointment");
        }
    }
}
