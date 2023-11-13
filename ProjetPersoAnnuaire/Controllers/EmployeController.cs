using Microsoft.AspNetCore.Mvc;
using ProjetPersoAnnuaire.Models;
using ProjetPersoAnnuaire.Services.EmployeService;

namespace ProjetPersoAnnuaire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : Controller
    {

        private readonly IEmployeService _employeService;

        public EmployeController(IEmployeService employeService)
        {
            _employeService = employeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employe>>> GetAllEmployes()
        {

            var employes = await _employeService.GetAllEmployes();
            return Json(employes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> GetEmployeById(int id)
        {
            var employe = await _employeService.GetEmployeById(id);
            if (employe == null)
            {
                return NotFound();
            }

            return Ok(employe);
        }


        [HttpPost]
        public async Task<ActionResult<int>> AddEmploye(Employe employe)
        {
            var employeId = await _employeService.AddEmploye(employe);
            return Ok(employeId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateEmploye(int id, Employe employe)
        {
            if (id != employe.EmployeID)
            {
                return BadRequest();
            }
            var updatedEmployeId = await _employeService.UpdateEmploye(employe);
            return Ok(updatedEmployeId);
        }


        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employe>>> SearchEmploye([FromQuery] string? nom = null, [FromQuery] string? site = null, [FromQuery] string? departement = null)
        {
            var employes = await _employeService.SearchEmploye(nom, site, departement);
            return Json(employes);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteEmploye(int id)
        {
            var deletedEmployeId = await _employeService.DeleteEmploye(id);
            if (deletedEmployeId == 0)
            {
                return NotFound();
            }
            return Ok(deletedEmployeId);
        }
    }
}
