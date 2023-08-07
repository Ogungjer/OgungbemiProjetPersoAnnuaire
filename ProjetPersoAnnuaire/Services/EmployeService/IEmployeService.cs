using ProjetPersoAnnuaire.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ProjetPersoAnnuaire.Services.EmployeService
{
    public interface IEmployeService
    {
        Task<IEnumerable<Employe>> GetAllEmployes();
        Task<Employe> GetEmployeById(int id);
        Task<int> AddEmploye(Employe employe);
        Task<int> UpdateEmploye(Employe employe);
        Task<int> DeleteEmploye(int id);
    }
}


