using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetPersoAnnuaire.Context;
using ProjetPersoAnnuaire.Models;


namespace ProjetPersoAnnuaire.Services.DepartementService
{
    public class DepartementService : IDepartementService
    {

        // Déclaration d'une variable privée pour stocker le contexte de base de données
        private readonly DataContextAnnuaire _dbContext;


        // Constructeur pour le service, injectant le contexte de base de données
        public DepartementService(DataContextAnnuaire dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Departement>> GetAllDepartements()
        {
            // Utilisation de Entity Framework Core pour obtenir tous les départements de la base de données
            return await _dbContext.Departements.ToListAsync();
        }

        public async Task<Departement> GetDepartementById(int id)
        {
            // La méthode FirstOrDefaultAsync renvoie le premier département qui correspond à l'ID ou null s'il n'y en a pas
            return await _dbContext.Departements.FirstOrDefaultAsync(d => d.DepartementID == id);
        }


        public async Task<int> AddDepartement(Departement departement)
        {


            if (!_dbContext.Employes.Any(d => d.DepartementID == departement.DepartementID))
            {

                // Ajoute le département au contexte de base de données
                _dbContext.Departements.Add(departement);

                // Enregistre les modifications de manière asynchrone dans la base de données
                await _dbContext.SaveChangesAsync();

                // Retourne l'ID du nouveau département ajouté
                return departement.DepartementID;

            }
            return -1;
        }

        public async Task<int> UpdateDepartement(Departement departement)
        {

            if (!_dbContext.Employes.Any(d => d.DepartementID == departement.DepartementID))
            {
                // Utilisation de Entity Framework Core pour marquer l'entité département comme modifiée dans le contexte de base de données
                _dbContext.Entry(departement).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();

                return departement.DepartementID;
            }
            return -1;
                
        }

        public async Task<int> DeleteDepartement(int id)
        {
            var departement = await _dbContext.Departements.FindAsync(id);
            if (departement == null)
            {
                return 0;
            }

            if (!_dbContext.Employes.Any(d => d.DepartementID == departement.DepartementID))
            {
                _dbContext.Departements.Remove(departement);

                await _dbContext.SaveChangesAsync();

                return departement.DepartementID;

            }
            return -1;
               
        }
    }

}










