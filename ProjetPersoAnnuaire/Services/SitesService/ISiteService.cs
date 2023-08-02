using ProjetPersoAnnuaire.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ProjetPersoAnnuaire.Services.SitesService

{
    public interface ISiteService
    {
        Task<IEnumerable<Site>> GetAllSites();
        Task<Site> GetSiteById(int id);
        Task<int> AddSite(Site hero);
        Task<int> UpdateSite(Site hero);
        Task<int> DeleteSite(int id);

    }
}
