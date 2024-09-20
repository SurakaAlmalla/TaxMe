using System.ComponentModel.DataAnnotations;

namespace TaxMe.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "FirstName is reqired")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "FirstName is Required")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email is LastName")]
        [EmailAddress(ErrorMessage = "Invalid Format For Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"^(?=(.*[A-Z]){1,})(?=(.*[a-z]){1,})(?=(.*\d){1,})(?=(.*[\W_]){1,}).{6,}$")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [Compare(nameof(Password), ErrorMessage = "Confirm Password DosNot Match Password")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Required ToAgree")]
        public bool IsAgree { get; set;}
    }
}
