using ProjetPersoAnnuaire.Models;


namespace ProjetPersoAnnuaire.Services.EmployeService
{
    public interface IEmployeService
    {
        Task<IEnumerable<Employe>> GetAllEmployes();
        Task<Employe> GetEmployeById(int id);
        Task<int> AddEmploye(Employe employe);
        Task<int> UpdateEmploye(Employe employe);
        Task<IEnumerable<Employe>> SearchEmploye(string? nom = null, string? site = null, string? departement = null);
        Task<int> DeleteEmploye(int id);
    }
}


