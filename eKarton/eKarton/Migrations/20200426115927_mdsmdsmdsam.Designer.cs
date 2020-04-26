﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eKarton.Models.SQL;

namespace eKarton.Migrations
{
    [DbContext(typeof(MedicalRecordContext))]
    [Migration("20200426115927_mdsmdsmdsam")]
    partial class mdsmdsmdsam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eKarton.Models.SQL.Allergy", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Food")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Analysis", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AnalysisType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageType")
                        .HasColumnType("int");

                    b.Property<string>("MedicalRecordGuid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Guid");

                    b.HasIndex("MedicalRecordGuid");

                    b.ToTable("Analysis");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Anamnesis", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SocioEpidemiologicalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.ToTable("Anamnesis");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Disease", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnamnesisGuid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiseaseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiseaseDiscriminator")
                        .HasColumnType("int");

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Therapy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("AnamnesisGuid");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Doctor", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniqueCitizensIdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.HasKey("Guid");

                    b.HasIndex("UniqueCitizensIdentityNumber")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Instruction", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageType")
                        .HasColumnType("int");

                    b.Property<string>("MedicalRecordGuid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SpecializationTo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("MedicalRecordGuid");

                    b.ToTable("Instructions");
                });

            modelBuilder.Entity("eKarton.Models.SQL.MedicalRecord", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AllergyGuid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AnamnesisGuid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DoctorGuid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientGuid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VaccinationStatusGuid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VisitGuids")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("AllergyGuid");

                    b.HasIndex("AnamnesisGuid");

                    b.HasIndex("DoctorGuid");

                    b.HasIndex("PatientGuid");

                    b.HasIndex("VaccinationStatusGuid");

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Medicine", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Allergic")
                        .HasColumnType("bit");

                    b.Property<string>("AllergyGuid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameOfMedicine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("AllergyGuid");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Patient", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FathersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("HealthInsuranceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("MothersName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfInsurance")
                        .HasColumnType("int");

                    b.Property<string>("UniqueCitizensIdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.HasKey("Guid");

                    b.HasIndex("UniqueCitizensIdentityNumber")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Snapshot", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BodyPart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ImageType")
                        .HasColumnType("int");

                    b.Property<string>("MedicalRecordGuid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SnapshotType")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.HasIndex("MedicalRecordGuid");

                    b.ToTable("Snapshots");
                });

            modelBuilder.Entity("eKarton.Models.SQL.VaccinationStatus", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.ToTable("VaccinationStatuses");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Vaccine", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("VaccinationStatusGuid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VaccineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VaccineSerialMark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("VaccinationStatusGuid");

                    b.ToTable("Vaccines");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Analysis", b =>
                {
                    b.HasOne("eKarton.Models.SQL.MedicalRecord", null)
                        .WithMany("Analysis")
                        .HasForeignKey("MedicalRecordGuid");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Disease", b =>
                {
                    b.HasOne("eKarton.Models.SQL.Anamnesis", null)
                        .WithMany("Diseases")
                        .HasForeignKey("AnamnesisGuid");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Instruction", b =>
                {
                    b.HasOne("eKarton.Models.SQL.MedicalRecord", null)
                        .WithMany("Instructions")
                        .HasForeignKey("MedicalRecordGuid");
                });

            modelBuilder.Entity("eKarton.Models.SQL.MedicalRecord", b =>
                {
                    b.HasOne("eKarton.Models.SQL.Allergy", "Allergy")
                        .WithMany()
                        .HasForeignKey("AllergyGuid");

                    b.HasOne("eKarton.Models.SQL.Anamnesis", "Anamnesis")
                        .WithMany()
                        .HasForeignKey("AnamnesisGuid");

                    b.HasOne("eKarton.Models.SQL.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorGuid");

                    b.HasOne("eKarton.Models.SQL.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eKarton.Models.SQL.VaccinationStatus", "VaccinationStatus")
                        .WithMany()
                        .HasForeignKey("VaccinationStatusGuid");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Medicine", b =>
                {
                    b.HasOne("eKarton.Models.SQL.Allergy", null)
                        .WithMany("Medicines")
                        .HasForeignKey("AllergyGuid");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Snapshot", b =>
                {
                    b.HasOne("eKarton.Models.SQL.MedicalRecord", null)
                        .WithMany("Snapshots")
                        .HasForeignKey("MedicalRecordGuid");
                });

            modelBuilder.Entity("eKarton.Models.SQL.Vaccine", b =>
                {
                    b.HasOne("eKarton.Models.SQL.VaccinationStatus", null)
                        .WithMany("Vaccines")
                        .HasForeignKey("VaccinationStatusGuid");
                });
#pragma warning restore 612, 618
        }
    }
}
