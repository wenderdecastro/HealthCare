using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class AddMigratontest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBack_User_UserId",
                table: "FeedBack");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "FeedBack",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_FeedBack_UserId",
                table: "FeedBack",
                newName: "IX_FeedBack_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBack_Patient_PatientId",
                table: "FeedBack",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBack_Patient_PatientId",
                table: "FeedBack");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "FeedBack",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FeedBack_PatientId",
                table: "FeedBack",
                newName: "IX_FeedBack_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBack_User_UserId",
                table: "FeedBack",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
