using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
namespace eKarton.Models.SQL
{
    public class EKartonContext:DbContext
    {
        public EKartonContext(DbContextOptions<EKartonContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anamneza>().HasMany(t => t.Bolesti);

            modelBuilder.Entity<KartonAlergena>().Property(p => p.Hrana)
            .HasConversion(
            v => JsonConvert.SerializeObject(v),
            v => JsonConvert.DeserializeObject<List<string>>(v));

            modelBuilder.Entity<KartonAlergena>().Property(p => p.Ostalo)
           .HasConversion(
           v => JsonConvert.SerializeObject(v),
           v => JsonConvert.DeserializeObject<List<string>>(v));

            modelBuilder.Entity<EKarton>().HasMany(k => k.PreglediLista);

            modelBuilder.Entity<EKarton>().HasMany(k => k.SlikeLista);

            modelBuilder.Entity<EKarton>().HasOne(j => j.KartonOca);

            modelBuilder.Entity<EKarton>().HasOne(k => k.KartonMajke);
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
        public DbSet<EKarton> EKartoni { get; set; }
        public DbSet<Slika> Slike{ get; set; }
        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<Lekar> Lekari { get; set; }
        public DbSet<KartonVakcinacije> KartoniVakcinacije { get; set; }
        public DbSet<KartonAlergena> KartoniAlergena { get; set; }
        public DbSet<Lek> Lekovi { get; set; }
        public DbSet<Vakcina> Vakcine { get; set; }
        public DbSet<Bolest> Bolesti { get; set; }
        public DbSet<Anamneza> Anamneze { get; set; }
        public DbSet<Ustanova> Ustanove{ get; set; }
    }
}
