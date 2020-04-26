using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarton.Migrations
{
    public partial class kkk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Doctors_DoctorFromGuid",
                table: "Instructions");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Doctors_DoctorToGuid",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_DoctorFromGuid",
                table: "Instructions");

            migrationBuilder.DropIndex(
                name: "IX_Instructions_DoctorToGuid",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "DoctorFromGuid",
                table: "Instructions");

            migrationBuilder.DropColumn(
                name: "DoctorToGuid",
                table: "Instructions");

            migrationBuilder.AddColumn<string>(
                name: "SpecializationTo",
                table: "Instructions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecializationTo",
                table: "Instructions");

            migrationBuilder.AddColumn<string>(
                name: "DoctorFromGuid",
                table: "Instructions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorToGuid",
                table: "Instructions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_DoctorFromGuid",
                table: "Instructions",
                column: "DoctorFromGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_DoctorToGuid",
                table: "Instructions",
                column: "DoctorToGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Doctors_DoctorFromGuid",
                table: "Instructions",
                column: "DoctorFromGuid",
                principalTable: "Doctors",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Doctors_DoctorToGuid",
                table: "Instructions",
                column: "DoctorToGuid",
                principalTable: "Doctors",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
