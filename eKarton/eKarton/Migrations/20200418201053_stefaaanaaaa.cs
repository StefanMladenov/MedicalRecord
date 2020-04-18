using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarton.Migrations
{
    public partial class stefaaanaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_PatientGuid",
                table: "MedicalRecords");

            migrationBuilder.AlterColumn<string>(
                name: "PatientGuid",
                table: "MedicalRecords",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_PatientGuid",
                table: "MedicalRecords",
                column: "PatientGuid",
                principalTable: "Patients",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Patients_PatientGuid",
                table: "MedicalRecords");

            migrationBuilder.AlterColumn<string>(
                name: "PatientGuid",
                table: "MedicalRecords",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Patients_PatientGuid",
                table: "MedicalRecords",
                column: "PatientGuid",
                principalTable: "Patients",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
