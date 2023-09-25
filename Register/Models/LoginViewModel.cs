using System.ComponentModel.DataAnnotations;

namespace Register.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email ")]
        [Required(ErrorMessage = "Email is required")]
        
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
