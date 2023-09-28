using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpecialtyId",
                table: "MedicalSpecialty",
                newName: "MedicalSpecialtyId");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MedicalAppointment",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MedicalAppointment");

            migrationBuilder.RenameColumn(
                name: "MedicalSpecialtyId",
                table: "MedicalSpecialty",
                newName: "SpecialtyId");
        }
    }
}
