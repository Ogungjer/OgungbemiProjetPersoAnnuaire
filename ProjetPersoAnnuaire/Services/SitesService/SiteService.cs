﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public async Task<int> AddSite(Site site)
        {
            _dbContext.Sites.Add(site);
            await _dbContext.SaveChangesAsync();
            return site.SiteID;
        }

        public async Task<int> UpdateSite(Site site)
        {
            _dbContext.Entry(site).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return site.SiteID;
        }

        public async Task<int> DeleteSite(int id)
        {
            var site = await _dbContext.Sites.FindAsync(id);
            if (site == null)
            {
                return 0;
            }

            _dbContext.Sites.Remove(site);
            await _dbContext.SaveChangesAsync();
            return site.SiteID;
        }
    }

}

