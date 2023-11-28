using System.Text.Json.Serialization;

namespace ProjetPersoAnnuaire.Models
{
    public class Departement
    {
        public int DepartementID { get; set; }
        public string? NomDepartement { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employe>? Employes { get; set; }
    }
}
