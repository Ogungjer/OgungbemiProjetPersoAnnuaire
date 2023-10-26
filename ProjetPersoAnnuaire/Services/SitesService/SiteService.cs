using Microsoft.EntityFrameworkCore;
using ProjetPersoAnnuaire.Context;
using ProjetPersoAnnuaire.Models;


namespace ProjetPersoAnnuaire.Services.SitesService
{
    public class SiteService : ISiteService
    {
        private readonly DataContextAnnuaire _dbContext;

        public SiteService(DataContextAnnuaire dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Site>> GetAllSites()
        {
            return await _dbContext.Sites.ToListAsync();
        }

        public async Task<Site> GetSiteById(int id)
        {
            return await _dbContext.Sites.FirstOrDefaultAsync(s => s.SiteID == id);
        }


        //public async Task<int> AddSite(Site site)
        //{
        //    // Vérifier si aucun employé n'est associé à ce site
            
        //    if (!(_dbContext.Employes.Any(e => e.SiteID == site.SiteID)) && (!(_dbContext.Employes.Any(e => e.EmployeSite == site.Ville))))
        //    {
        //        _dbContext.Sites.Add(site);
        //        await _dbContext.SaveChangesAsync();
        //        return site.SiteID;

        //    }
        //    return -1;

        //}

        public async Task<int> AddSite(Site site)
        {
            // Recherche le site correspondant au nom donné
            var existingSite = await _dbContext.Sites
                .FirstOrDefaultAsync(s => s.Ville == site.Ville);

            if (existingSite != null)
            {
                // Le site existe déjà, vérifiez s'il y a des employés affectés à ce site
                if (!_dbContext.Employes.Any(e => e.SiteID == existingSite.SiteID))
                {
                    // Aucun employé n'est affecté à ce site
                    existingSite.Ville = site.Ville;
                    await _dbContext.SaveChangesAsync();
                    return existingSite.SiteID;
                }
                else
                {
                    throw new Exception("Un ou plusieurs salariés sont déjà affectés à ce site.");
                }
            }
            else
            {
                // Le site n'existe pas, ajoutez-le
                _dbContext.Sites.Add(site);
                await _dbContext.SaveChangesAsync();
                return site.SiteID;
            }
        }



        public async Task<int> UpdateSite(Site site)
        {
            // Vérifier si aucun employé n'est associé à ce departement
            if (!_dbContext.Employes.Any(e => e.SiteID == site.SiteID))
            { 
                _dbContext.Entry(site).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return site.SiteID;

            }
            throw new Exception("Un ou plusieurs salariés sont déjà affectés à ce site.");

        }

        public async Task<int> DeleteSite(int id)
        {
            var site = await _dbContext.Sites.FindAsync(id);
            if (site == null)
            {
                return 0;
            }

            if (!_dbContext.Employes.Any(e => e.SiteID == site.SiteID))
            {
                _dbContext.Sites.Remove(site);
                await _dbContext.SaveChangesAsync();
                return site.SiteID;

            }
            throw new Exception("Un ou plusieurs salariés sont déjà affectés à ce site.");


        }
    }

}

