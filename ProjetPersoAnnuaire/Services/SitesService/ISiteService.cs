using ProjetPersoAnnuaire.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ProjetPersoAnnuaire.Services.SitesService

{
    public interface ISiteService
    {
        Task<IEnumerable<Site>> GetAllSites();
        Task<Site> GetSiteById(int id);
        Task<int> AddSite(Site site);
        Task<int> UpdateSite(Site site);
        Task<int> DeleteSite(int id);

    }
}
