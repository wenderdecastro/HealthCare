using System.ComponentModel.DataAnnotations;

namespace HealthClinic.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The 'Email' field is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The 'Password' field is required.")]
        public string Password { get; set; }
    }
}
