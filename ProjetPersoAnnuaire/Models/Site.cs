using System.Text.Json.Serialization;

namespace ProjetPersoAnnuaire.Models
{
    public class Site
    {
        public int SiteID { get; set; }
        public string? Ville { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employe>? Employes { get; set; }
    }
}
