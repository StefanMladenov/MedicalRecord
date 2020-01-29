using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

namespace eKarton.Models.SQL
{
    public class MedicalRecordContext:DbContext
    {
        public MedicalRecordContext(DbContextOptions<MedicalRecordContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anamnesis>().HasMany(t => t.Diseases);

            modelBuilder.Entity<Allergy>().Property(p => p.Food)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));

            modelBuilder.Entity<Allergy>().Property(p => p.Other)
           .HasConversion(
           v => JsonConvert.SerializeObject(v),
           v => JsonConvert.DeserializeObject<List<string>>(v));

            modelBuilder.Entity<Patient>()
            .HasIndex(u => u.UniqueCitizensIdentityNumber)
            .IsUnique();
            
            modelBuilder.Entity<Doctor>()
            .HasIndex(u => u.UniqueCitizensIdentityNumber)
            .IsUnique();

            modelBuilder.Entity<MedicalRecord>().HasMany(k => k.Visits);

            modelBuilder.Entity<MedicalRecord>().HasMany(k => k.Images);

            modelBuilder.Entity<MedicalRecord>().HasOne(j => j.FathersMedicalRecord);

            modelBuilder.Entity<MedicalRecord>().HasOne(k => k.MothersMedicalRecord);
        }
        //    modelBuilder.Entity<Lek>().HasKey(m => m.LekID);

        //    //modelBuilder.Entity<Alergen>().HasKey(m => m.AlergenID);

        //    modelBuilder.Entity<Vakcina>().HasKey(m => m.VakcinaID);

        //    modelBuilder.Entity<Osoba>().HasKey(n => n.OsobaID);

        //    modelBuilder.Entity<Bolest>().HasKey(n => n.BolestID);

        //    #region Ustanova

        //    modelBuilder.Entity<Ustanova>().HasKey(n => n.UstanovaID);

        //    modelBuilder.Entity<Ustanova>().HasMany(p => p.Lekari);
        //    #endregion

        //    #region Anamneza

        //    modelBuilder.Entity<Anamneza>().HasKey(n => n.AnamnezaID);

        //    modelBuilder.Entity<Anamneza>().HasOne(p => p.AktuelnaBolest);

        //    modelBuilder.Entity<Anamneza>().HasMany(p => p.PrelezaneBolesti);

        //    modelBuilder.Entity<Anamneza>().HasMany(p => p.PorodicneBolesti);

        //    //modelBuilder.Entity<Anamneza>()

        //    #endregion

        //    #region KartonAlergena 

        //    modelBuilder.Entity<KartonAlergena>().HasKey(p => p.KartonAlergenaID);

        //    modelBuilder.Entity<KartonAlergena>().HasMany(p => p.Lekovi);

        //    #endregion

        //    #region KartonVakcinacije

        //    modelBuilder.Entity<KartonVakcinacije>().HasKey(b => b.KartonVakcinacijeID);

        //    modelBuilder.Entity<KartonVakcinacije>().HasMany(b => b.VakcineLista);

        //    #endregion

        //    #region EKarton

        //    modelBuilder.Entity<EKarton>().HasKey(m => m.KartonID);

        //    modelBuilder.Entity<EKarton>().HasOne(k => k.Pacijent);


        //    modelBuilder.Entity<EKarton>().HasOne(k => k.KartonAlergena);

        //    modelBuilder.Entity<EKarton>().HasOne(k => k.KartonVakcinacije);

        //    modelBuilder.Entity<EKarton>().HasMany(k => k.PreglediLista);

        //    modelBuilder.Entity<EKarton>().HasMany(k => k.SlikeLista);

        //    modelBuilder.Entity<EKarton>().HasOne(k => k.Lekar);

        //    modelBuilder.Entity<EKarton>().HasOne(k => k.Anamneza);

        //    #endregion

        //}
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Image> Images{ get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<VaccinationStatus> VaccinationStatuses { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Anamnesis> Anamnesis { get; set; }
        public DbSet<Institute> Institutes{ get; set; }
    }
}
