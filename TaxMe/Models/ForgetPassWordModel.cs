using System.ComponentModel.DataAnnotations;

namespace TaxMe.Models
{
    public class ForgetPassWordModel
    {

        [Required(ErrorMessage = "Email is LastName")]
        [EmailAddress(ErrorMessage = "Invalid Format For Email")]
        public string Email { get; set; }

     
    }
}
