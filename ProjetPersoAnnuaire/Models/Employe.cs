namespace ProjetPersoAnnuaire.Models
{
    public class Employe
    {
        public int EmployeID { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string?  TelephoneFixe { get; set; }
        public string? TelephonePortable { get; set; }
        public string? Email { get; set; }
        public int SiteID { get; set; }
        public int DepartementID { get; set; }
        public virtual Site? Site { get; set; }
        public virtual Departement? Departement { get; set; }


    }
}
