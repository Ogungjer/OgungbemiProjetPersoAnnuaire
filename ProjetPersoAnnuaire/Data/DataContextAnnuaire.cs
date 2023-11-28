using Microsoft.EntityFrameworkCore;
using ProjetPersoAnnuaire.Models;

namespace ProjetPersoAnnuaire.Context
{
    public class DataContextAnnuaire : DbContext
    {

        public DataContextAnnuaire(DbContextOptions<DataContextAnnuaire> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string DB_NAME = "AnnuaireEntreprise";
            const string SERVER_NAME = "ZENBOOK13\\SQLEXPRESS";
            const string connectionString = $"Server={SERVER_NAME};Database={DB_NAME};Trusted_Connection=True;TrustServerCertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //relations pour Employe
            modelBuilder.Entity<Employe>()
                .HasOne(e => e.Site)
                .WithMany(s => s.Employes)
                .HasForeignKey(e => e.SiteID);

            modelBuilder.Entity<Employe>()
                .HasOne(e => e.Departement)
                .WithMany(d => d.Employes)
                .HasForeignKey(e => e.DepartementID);
        }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Employe> Employes { get; set; }

    }
}
