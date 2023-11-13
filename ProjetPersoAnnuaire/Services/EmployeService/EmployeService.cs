using Microsoft.EntityFrameworkCore;
using ProjetPersoAnnuaire.Context;
using ProjetPersoAnnuaire.Models;


namespace ProjetPersoAnnuaire.Services.EmployeService
{
    public class EmployeService : IEmployeService
    {
        private readonly DataContextAnnuaire _dbContext;

        public EmployeService(DataContextAnnuaire dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employe>> GetAllEmployes()
        {
            return await _dbContext.Employes.Include(s => s.Site).Include(d => d.Departement).ToListAsync();
            
        }

        public async Task<Employe> GetEmployeById(int id)
        {
            return await _dbContext.Employes.Include(s => s.Site).Include(d => d.Departement).FirstOrDefaultAsync(e => e.EmployeID == id);
        }


        public async Task<int> AddEmploye(Employe employe)
        {
            _dbContext.Employes.Add(employe);
            await _dbContext.SaveChangesAsync();
            return employe.EmployeID;
        }

        public async Task<int> UpdateEmploye(Employe employe)
        {
            _dbContext.Entry(employe).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return employe.EmployeID;
        }


        
        public async Task<IEnumerable<Employe>> SearchEmploye(string? nom = null, string? site = null, string? departement = null)
        {
            var query = _dbContext.Employes.Include(s => s.Site).Include(d => d.Departement).AsQueryable();

            if (!string.IsNullOrEmpty(nom))
            {
                query = query.Where(e => e.Nom.Contains(nom) || e.Prenom.Contains(nom));
            }

            if (!string.IsNullOrEmpty(site))
            {
                query = query.Where(e => e.Site.Ville.Contains(site));
            }

            if (!string.IsNullOrEmpty(departement))
            {
                query = query.Where(e => e.Departement.NomDepartement.Contains(departement));
            }

            return await query.ToListAsync();
        }
        


        public async Task<int> DeleteEmploye(int id)
        {
            var employe = await _dbContext.Employes.FindAsync(id);
            if (employe == null)
            {
                return 0;
            }

            _dbContext.Employes.Remove(employe);
            await _dbContext.SaveChangesAsync();
            return employe.EmployeID;
        }
    }

}

