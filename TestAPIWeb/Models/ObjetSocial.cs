using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPIWeb.Models
{
    public class ObjetSocial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjetSocialID { get; set; }
        public string? ObjetSocialLib { get; set; }
        public int ObjetSocialParentID { get; set; }
        public string? ObjetSocialParentLib { get; set; }

        //public ICollection<Association> AssociationsLien1 { get; set; }
        //public ICollection<Association> AssociationsLien2 { get; set; }
    }
}
