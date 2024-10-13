using System.ComponentModel.DataAnnotations;

namespace TestAPIWeb.Models
{
    public class Association
    {
        [Key]
        public int Id { get; set; }
        public string IdRNA { get; set; }
        public DateOnly DateCreation { get; set; }
        public DateOnly DatePublication { get; set; }
        public string Titre { get; set; }
        public string? Description { get; set; }
        public int? ObjetSocial1ID { get; set; }
        //public ObjetSocial ObjetSocial1 { get; set; }
        public int? ObjetSocial2ID { get; set; }
        //public ObjetSocial ObjetSocial2 { get; set; }
        public string? Adresse1 { get; set; }
        public string? Adresse2 { get; set; }
        public string? Adresse3 { get; set; }
        public string? CodePostal { get; set;}
        public string? Ville { get; set;}
        public string? SiteWeb { get; set;}
        public char Position { get; set;}
        public DateTime LastUpdate { get; set; }
    }
}
