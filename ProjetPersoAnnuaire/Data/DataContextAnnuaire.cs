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

        public DbSet<Site> Sites { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Employe> Employes { get; set; }

    }
}
