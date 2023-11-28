using Microsoft.AspNetCore.Mvc;
using ProjetPersoAnnuaire.Models;
using ProjetPersoAnnuaire.Services.DepartementService;

namespace ProjetPersoAnnuaire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : Controller
    {
        // Déclaration d'une variable privée pour stocker le service de gestion des deprarterments 
        private readonly IDepartementService _departementService;

        // Constructeur pour le contrôleur, injectant le service de gestion des departements 
        public DepartementController(IDepartementService departmentService)
        {
            _departementService = departmentService;
        }

        // Action pour récupérer tous les departments (GET: api/Departement)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departement>>> GetAllDepartements()
        {
            // Appel à la méthode du service pour récupérer tous les departements 
            var departements = await _departementService.GetAllDepartements();

            // Retourne les sites sous forme de réponse JSON
            return Json(departements);
        }

        // Action pour récupérer un departement par son identifiant (GET: api/Departement/id)
        [HttpGet("{id}")]
        public async Task<ActionResult<Site>> GetDepartementById(int id)
        {
            var departement = await _departementService.GetDepartementById(id);
            if (departement == null)
            {
                return NotFound();
            }

            return Ok(departement);
        }


        // Action pour ajouter un nouveau departement (POST: api/Departement)
        [HttpPost]
        public async Task<ActionResult<int>> AddDepartement(Departement departement)
        {

            var departementId = await _departementService.AddDepartement(departement);

            // Retourne l'ID du nouveau departement ajouté sous forme de réponse OK
            return Ok(departementId);
        }


        // Action pour mettre à jour un departement existant (PUT: api/Departement/id)
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateDepartement(int id, Departement departement)
        {
            // Vérifie si l'ID passé en paramètre correspond à l'ID du departement à mettre à jour
            if (id != departement.DepartementID)
            {
                // Si l'ID ne correspond pas, renvoie une réponse BadRequest
                return BadRequest();
            }
            var updatedDepartementId = await _departementService.UpdateDepartement(departement);

            return Ok(updatedDepartementId);
        }

        // Action pour supprimer un departement par son identifiant (DELETE: api/Departement/id)
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteDepartement(int id)
        {
            var deletedDepartementId = await _departementService.DeleteDepartement(id);
            if (deletedDepartementId == 0)
            {
                return NotFound();
            }
            return Ok(deletedDepartementId);
        }
    }
}
