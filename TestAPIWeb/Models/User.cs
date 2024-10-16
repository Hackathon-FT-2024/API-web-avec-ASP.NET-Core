using System.ComponentModel.DataAnnotations;

namespace TestAPIWeb.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
