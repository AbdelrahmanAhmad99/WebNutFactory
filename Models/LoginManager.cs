using System.ComponentModel.DataAnnotations;

namespace WebNutFactory.Models
{
    public class LoginManager
    {
        [Key]
        public int LoginManagerID { get; set; }
        [Required]
        public string? UserName {  get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
