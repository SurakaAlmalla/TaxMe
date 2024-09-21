using System.ComponentModel.DataAnnotations;

namespace TaxMe.Models
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Email is LastName")]
        [EmailAddress(ErrorMessage = "Invalid Format For Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }

        public bool  RememberMe { get; set; }

    }
}
