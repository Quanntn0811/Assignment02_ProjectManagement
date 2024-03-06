using System.ComponentModel.DataAnnotations;

namespace ProjectManagement_Assignment02.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
