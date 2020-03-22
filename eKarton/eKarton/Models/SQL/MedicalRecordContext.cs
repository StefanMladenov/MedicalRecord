using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace eKarton.Models.SQL
{
    public class MedicalRecordContext : DbContext
    {
        public MedicalRecordContext(DbContextOptions<MedicalRecordContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Allergy

            modelBuilder.Entity<Allergy>().Property(p => p.Food)
            .HasConversion(
            v => JsonConvert.SerializeObject(v), // lambda expression 
            v => JsonConvert.DeserializeObject<List<string>>(v));

            #endregion

            modelBuilder.Entity<Anamnesis>().HasMany(t => t.Diseases);

           

            modelBuilder.Entity<Allergy>().Property(p => p.Other)
           .HasConversion(
           v => JsonConvert.SerializeObject(v),
           v => JsonConvert.DeserializeObject<List<string>>(v));

            modelBuilder.Entity<Allergy>().HasMany(x => x.Medicines);

            modelBuilder.Entity<VaccinationStatus>().HasMany(x => x.Vaccines);

            modelBuilder.Entity<Institute>().HasMany(x => x.Doctors);
            
            modelBuilder.Entity<Patient>()
            .HasIndex(u => u.UniqueCitizensIdentityNumber)
            .IsUnique();


            modelBuilder.Entity<Doctor>()
            .HasIndex(u => u.UniqueCitizensIdentityNumber)
            .IsUnique();

            #region MedicalRecord

            modelBuilder.Entity<MedicalRecord>().HasMany(k => k.Images);

            modelBuilder.Entity<MedicalRecord>().HasOne(j => j.FathersMedicalRecord);

            modelBuilder.Entity<MedicalRecord>().HasOne(k => k.MothersMedicalRecord);

            modelBuilder.Entity<MedicalRecord>().HasOne(j => j.Doctor);

            modelBuilder.Entity<MedicalRecord>().HasOne(k => k.Patient);

            modelBuilder.Entity<MedicalRecord>().Property(p => p.Visits)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));

            #endregion
        }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<VaccinationStatus> VaccinationStatuses { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Anamnesis> Anamnesis { get; set; }
        public DbSet<Institute> Institutes { get; set; }
    }
}
