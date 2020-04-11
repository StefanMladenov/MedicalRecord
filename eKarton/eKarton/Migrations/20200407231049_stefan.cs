using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarton.Migrations
{
    public partial class stefan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Food = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Anamnesis",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    SocioEpidemiologicalStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamnesis", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    UniqueCitizensIdentityNumber = table.Column<string>(maxLength: 13, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    EMail = table.Column<string>(nullable: true),
                    FathersName = table.Column<string>(nullable: true),
                    MothersName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    HealthInsuranceNumber = table.Column<int>(nullable: false),
                    TypeOfInsurance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationStatuses",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationStatuses", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    NameOfMedicine = table.Column<string>(nullable: false),
                    Allergic = table.Column<bool>(nullable: false),
                    AllergyGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Medicines_Allergies_AllergyGuid",
                        column: x => x.AllergyGuid,
                        principalTable: "Allergies",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DiseaseCode = table.Column<string>(nullable: false),
                    DiseaseName = table.Column<string>(nullable: false),
                    Therapy = table.Column<string>(nullable: true),
                    DiseaseDiscriminator = table.Column<int>(nullable: false),
                    AnamnesisGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Diseases_Anamnesis_AnamnesisGuid",
                        column: x => x.AnamnesisGuid,
                        principalTable: "Anamnesis",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    UniqueCitizensIdentityNumber = table.Column<string>(maxLength: 13, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    EMail = table.Column<string>(nullable: true),
                    Specialization = table.Column<string>(nullable: true),
                    InstituteGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Doctors_Institutes_InstituteGuid",
                        column: x => x.InstituteGuid,
                        principalTable: "Institutes",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    VaccineSerialMark = table.Column<string>(nullable: false),
                    VaccineName = table.Column<string>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    VaccinationStatusGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Vaccines_VaccinationStatuses_VaccinationStatusGuid",
                        column: x => x.VaccinationStatusGuid,
                        principalTable: "VaccinationStatuses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DoctorGuid = table.Column<string>(nullable: true),
                    PatientGuid = table.Column<string>(nullable: true),
                    FathersMedicalRecordGuid = table.Column<string>(nullable: true),
                    MothersMedicalRecordGuid = table.Column<string>(nullable: true),
                    AllergyGuid = table.Column<string>(nullable: true),
                    VaccinationStatusGuid = table.Column<string>(nullable: true),
                    VisitGuids = table.Column<string>(nullable: true),
                    AnamnesisGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Allergies_AllergyGuid",
                        column: x => x.AllergyGuid,
                        principalTable: "Allergies",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Anamnesis_AnamnesisGuid",
                        column: x => x.AnamnesisGuid,
                        principalTable: "Anamnesis",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Doctors_DoctorGuid",
                        column: x => x.DoctorGuid,
                        principalTable: "Doctors",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_MedicalRecords_FathersMedicalRecordGuid",
                        column: x => x.FathersMedicalRecordGuid,
                        principalTable: "MedicalRecords",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_MedicalRecords_MothersMedicalRecordGuid",
                        column: x => x.MothersMedicalRecordGuid,
                        principalTable: "MedicalRecords",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Patients_PatientGuid",
                        column: x => x.PatientGuid,
                        principalTable: "Patients",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_VaccinationStatuses_VaccinationStatusGuid",
                        column: x => x.VaccinationStatusGuid,
                        principalTable: "VaccinationStatuses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Analysis",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    SnapshotType = table.Column<int>(nullable: false),
                    MedicalRecordGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analysis", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Analysis_MedicalRecords_MedicalRecordGuid",
                        column: x => x.MedicalRecordGuid,
                        principalTable: "MedicalRecords",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    InstituteGuid = table.Column<string>(nullable: true),
                    DoctorFromGuid = table.Column<string>(nullable: true),
                    DoctorToGuid = table.Column<string>(nullable: true),
                    MedicalRecordGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Instructions_Doctors_DoctorFromGuid",
                        column: x => x.DoctorFromGuid,
                        principalTable: "Doctors",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructions_Doctors_DoctorToGuid",
                        column: x => x.DoctorToGuid,
                        principalTable: "Doctors",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructions_Institutes_InstituteGuid",
                        column: x => x.InstituteGuid,
                        principalTable: "Institutes",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructions_MedicalRecords_MedicalRecordGuid",
                        column: x => x.MedicalRecordGuid,
                        principalTable: "MedicalRecords",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Snapshots",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    BodyPart = table.Column<string>(nullable: true),
                    SnapshotType = table.Column<int>(nullable: false),
                    MedicalRecordGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snapshots", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Snapshots_MedicalRecords_MedicalRecordGuid",
                        column: x => x.MedicalRecordGuid,
                        principalTable: "MedicalRecords",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analysis_MedicalRecordGuid",
                table: "Analysis",
                column: "MedicalRecordGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_AnamnesisGuid",
                table: "Diseases",
                column: "AnamnesisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_InstituteGuid",
                table: "Doctors",
                column: "InstituteGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UniqueCitizensIdentityNumber",
                table: "Doctors",
                column: "UniqueCitizensIdentityNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_DoctorFromGuid",
                table: "Instructions",
                column: "DoctorFromGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_DoctorToGuid",
                table: "Instructions",
                column: "DoctorToGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_InstituteGuid",
                table: "Instructions",
                column: "InstituteGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Instructions_MedicalRecordGuid",
                table: "Instructions",
                column: "MedicalRecordGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AllergyGuid",
                table: "MedicalRecords",
                column: "AllergyGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AnamnesisGuid",
                table: "MedicalRecords",
                column: "AnamnesisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_DoctorGuid",
                table: "MedicalRecords",
                column: "DoctorGuid");

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

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientGuid",
                table: "MedicalRecords",
                column: "PatientGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_VaccinationStatusGuid",
                table: "MedicalRecords",
                column: "VaccinationStatusGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_AllergyGuid",
                table: "Medicines",
                column: "AllergyGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UniqueCitizensIdentityNumber",
                table: "Patients",
                column: "UniqueCitizensIdentityNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Snapshots_MedicalRecordGuid",
                table: "Snapshots",
                column: "MedicalRecordGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_VaccinationStatusGuid",
                table: "Vaccines",
                column: "VaccinationStatusGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analysis");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Snapshots");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Anamnesis");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "VaccinationStatuses");

            migrationBuilder.DropTable(
                name: "Institutes");
        }
    }
}
