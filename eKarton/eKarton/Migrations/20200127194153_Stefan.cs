using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKarton.Migrations
{
    public partial class Stefan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Food = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anamnesis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocioEpidemiologicalStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamnesis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institutes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfMedicine = table.Column<string>(nullable: true),
                    Allergic = table.Column<bool>(nullable: false),
                    AllergyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseCode = table.Column<string>(nullable: true),
                    DiseaseName = table.Column<string>(nullable: true),
                    Therapy = table.Column<string>(nullable: true),
                    DiseaseDiscriminator = table.Column<int>(nullable: false),
                    AnamnesisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diseases_Anamnesis_AnamnesisId",
                        column: x => x.AnamnesisId,
                        principalTable: "Anamnesis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    UniqueCitizensIdentityNumber = table.Column<string>(maxLength: 13, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    EMail = table.Column<string>(nullable: true),
                    Specialization = table.Column<string>(nullable: true),
                    InstituteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalTable: "Institutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineName = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    VaccinationDate = table.Column<DateTime>(nullable: false),
                    VaccinationStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccines_VaccinationStatuses_VaccinationStatusId",
                        column: x => x.VaccinationStatusId,
                        principalTable: "VaccinationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(nullable: true),
                    PatientId = table.Column<int>(nullable: true),
                    FathersMedicalRecordId = table.Column<int>(nullable: true),
                    MothersMedicalRecordId = table.Column<int>(nullable: true),
                    AllergyId = table.Column<int>(nullable: true),
                    VaccinationStatusId = table.Column<int>(nullable: true),
                    AnamnesisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Allergies_AllergyId",
                        column: x => x.AllergyId,
                        principalTable: "Allergies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Anamnesis_AnamnesisId",
                        column: x => x.AnamnesisId,
                        principalTable: "Anamnesis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_MedicalRecords_FathersMedicalRecordId",
                        column: x => x.FathersMedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_MedicalRecords_MothersMedicalRecordId",
                        column: x => x.MothersMedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_VaccinationStatuses_VaccinationStatusId",
                        column: x => x.VaccinationStatusId,
                        principalTable: "VaccinationStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ImageType = table.Column<int>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VisitEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    MedicalRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitEntity_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_AnamnesisId",
                table: "Diseases",
                column: "AnamnesisId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_InstituteId",
                table: "Doctors",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UniqueCitizensIdentityNumber",
                table: "Doctors",
                column: "UniqueCitizensIdentityNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_MedicalRecordId",
                table: "Images",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AllergyId",
                table: "MedicalRecords",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AnamnesisId",
                table: "MedicalRecords",
                column: "AnamnesisId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_DoctorId",
                table: "MedicalRecords",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_FathersMedicalRecordId",
                table: "MedicalRecords",
                column: "FathersMedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_MothersMedicalRecordId",
                table: "MedicalRecords",
                column: "MothersMedicalRecordId",
                unique: true,
                filter: "[MothersMedicalRecordId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_VaccinationStatusId",
                table: "MedicalRecords",
                column: "VaccinationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_AllergyId",
                table: "Medicines",
                column: "AllergyId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UniqueCitizensIdentityNumber",
                table: "Patients",
                column: "UniqueCitizensIdentityNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_VaccinationStatusId",
                table: "Vaccines",
                column: "VaccinationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitEntity_MedicalRecordId",
                table: "VisitEntity",
                column: "MedicalRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "VisitEntity");

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
