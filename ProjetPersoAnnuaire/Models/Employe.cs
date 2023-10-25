using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetPersoAnnuaire.Models
{
    public class Employe
    {
        public int EmployeID { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? TelephoneFixe { get; set; }
        public string? TelephonePortable { get; set; }
        public string? Email { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Erreur lors de la saisie du champ SiteId.")]
        public int SiteID { get; set; }

        [JsonIgnore]
        [ForeignKey("SiteID")]
        public virtual Site? Site { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Erreur lors de la saisie du champ DepartementId.")]
        public int DepartementID { get; set; }

        [JsonIgnore]
        [ForeignKey("DepartementID")]
        public virtual Departement? Departement { get; set; }

        [NotMapped]
        public string? EmployeSite { get { return Site?.Ville; } }

        [NotMapped]
        public string? EmployeDepartement { get { return Departement?.NomDepartement; } }



    }
}
