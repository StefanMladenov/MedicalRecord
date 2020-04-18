using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarton.Migrations
{
    public partial class stefan1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_MedicalRecords_FathersMedicalRecordGuid",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_MedicalRecords_MothersMedicalRecordGuid",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_FathersMedicalRecordGuid",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_MothersMedicalRecordGuid",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "FathersMedicalRecordGuid",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "MothersMedicalRecordGuid",
                table: "MedicalRecords");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FathersMedicalRecordGuid",
                table: "MedicalRecords",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MothersMedicalRecordGuid",
                table: "MedicalRecords",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_FathersMedicalRecordGuid",
                table: "MedicalRecords",
                column: "FathersMedicalRecordGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_MothersMedicalRecordGuid",
                table: "MedicalRecords",
                column: "MothersMedicalRecordGuid",
                unique: true,
                filter: "[MothersMedicalRecordGuid] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_MedicalRecords_FathersMedicalRecordGuid",
                table: "MedicalRecords",
                column: "FathersMedicalRecordGuid",
                principalTable: "MedicalRecords",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_MedicalRecords_MothersMedicalRecordGuid",
                table: "MedicalRecords",
                column: "MothersMedicalRecordGuid",
                principalTable: "MedicalRecords",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
