using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaxMe.Models;
using TaxMeData.Models;

namespace TaxMe.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        #region MyRegion

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel input)
        {
            if (ModelState.IsValid)
            {
                var User = new ApplicationUser
                {
                    UserName = input.Email.Split("@")[0],
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    IsActive = true,
                };

                var result =await _userManager.CreateAsync(User, input.Password);   
                if (result.Succeeded) 
                    return RedirectToAction("SignIn");

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
             }
            return View(input);
        }

        #endregion

    }
}
