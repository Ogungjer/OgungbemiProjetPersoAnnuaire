﻿using ProjetPersoAnnuaire.Models;


namespace ProjetPersoAnnuaire.Services.DepartementService

{
    public interface IDepartementService
    {
        Task<IEnumerable<Departement>> GetAllDepartements();
        Task<Departement> GetDepartementById(int id);
        Task<int> AddDepartement(Departement departement);
        Task<int> UpdateDepartement(Departement departement);
        Task<int> DeleteDepartement(int id);
    }
}
