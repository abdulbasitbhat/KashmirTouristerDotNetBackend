using System.ComponentModel.DataAnnotations;

namespace KashmiriTourister.Models.Entity
{
    public class Login
    {
        [Key]
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public string name { get; set; }
        public string[] collection { get; set; }
    }
}
