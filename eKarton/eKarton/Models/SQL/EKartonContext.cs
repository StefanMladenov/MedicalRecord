using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Lek>().HasKey(m => m.LekID);

            modelBuilder.Entity<Alergen>().HasKey(m => m.AlergenID);

            modelBuilder.Entity<Vakcina>().HasKey(m => m.VakcinaID);
            
            modelBuilder.Entity<Osoba>().HasKey(n => n.OsobaID);


            #region KartonAlergena 
            
            modelBuilder.Entity<KartonAlergena>().HasKey(p => p.KartonAlergenaID);

            modelBuilder.Entity<KartonAlergena>().HasMany(p => p.AlergeniLista);

            modelBuilder.Entity<KartonAlergena>().HasMany(p => p.LekoviLista);

            #endregion

            #region KartonVakcinacije

            modelBuilder.Entity<KartonVakcinacije>().HasKey(b => b.KartonVakcinacijeID);

            modelBuilder.Entity<KartonVakcinacije>().HasMany(b => b.VakcineLista);

            #endregion
            
            #region EKarton

            modelBuilder.Entity<EKarton>().HasKey(m => m.KartonID);

            modelBuilder.Entity<EKarton>().HasOne(k => k.Pacijent);
            
            modelBuilder.Entity<EKarton>().HasOne(j => j.KartonOca);
            
            modelBuilder.Entity<EKarton>().HasOne(k => k.KartonMajke);

            modelBuilder.Entity<EKarton>().HasOne(k => k.KartonAlergena);

            modelBuilder.Entity<EKarton>().HasOne(k => k.KartonVakcinacije);

            modelBuilder.Entity<EKarton>().HasMany(k => k.PreglediLista);

            modelBuilder.Entity<EKarton>().HasMany(k => k.SlikeLista);

            modelBuilder.Entity<EKarton>().HasOne(k => k.Lekar);

            #endregion

        }
        public DbSet<EKarton> EKartoniLista { get; set; }
        public DbSet<Slika> SlikeLista { get; set; }
        public DbSet<Osoba> OsobeLista { get; set; }
        public DbSet<KartonVakcinacije> KartoniVakcinacijeLista { get; set; }
        public DbSet<KartonAlergena> KartoniAlergenaLista { get; set; }
        public DbSet<Lek> LekoviLista { get; set; }
        public DbSet<Vakcina> VakcineLista { get; set; }
    }
}
