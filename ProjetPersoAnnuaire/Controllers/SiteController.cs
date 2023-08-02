using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ProjetPersoAnnuaire.Models;
using System.Threading.Tasks;
using ProjetPersoAnnuaire.Services.SitesService;

namespace ProjetPersoAnnuaire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : Controller
    {
        private readonly ISiteService _siteService;

        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Site>>> GetAllSites()
        {

            var sites = await _siteService.GetAllSites();
            return Json(sites);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Site>> GetSiteById(int id)
        {
            var site = await _siteService.GetSiteById(id);
            if (site == null)
            {
                return NotFound();
            }

            return Ok(site);
        }


        [HttpPost]
        public async Task<ActionResult<int>> AddSite(Site site)
        {
            var siteId = await _siteService.AddSite(site);
            return Ok(siteId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateSite(int id, Site site)
        {
            if (id != site.SiteID)
            {
                return BadRequest();
            }
            var updatedClientId = await _siteService.UpdateSite(site);
            return Ok(updatedClientId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteSite(int id)
        {
            var deletedSiteId = await _siteService.DeleteSite(id);
            if (deletedSiteId == 0)
            {
                return NotFound();
            }
            return Ok(deletedSiteId);
        }
    }
}
