using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return await _dbContext.Employes.ToListAsync();
        }

        public async Task<Employe> GetEmployeById(int id)
        {
            return await _dbContext.Employes.FirstOrDefaultAsync(e => e.EmployeID == id);
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

