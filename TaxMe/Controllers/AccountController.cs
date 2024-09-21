using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaxMe.Models;
using TaxMeData.Models;

namespace TaxMe.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #region SignUp

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

        #region Login
        public IActionResult LogIn()
        { return View(); }

        [HttpPost]
        public async  Task<IActionResult> LogIn(LogInViewModel input)
        {
            if (ModelState.IsValid)
            {
                var User= await _userManager.FindByNameAsync(input.Email);
                if (User is not null)
                {
                    if (await _userManager.CheckPasswordAsync(User, input.Password))
                    {
                        var result = await _signInManager.PasswordSignInAsync(User, input.Password, input.RememberMe, true);
                        if (result.Succeeded)
                            return RedirectToAction("Index","Home");

                       
                    }
                }
                ModelState.AddModelError("", "Incorect Email or Password");
                return View(input);
            }
            return View(input);
        }

        #endregion

        public new async Task<IActionResult> SignOut()
        { 
        await _signInManager.SignOutAsync();
            return RedirectToAction( nameof(LogIn));
        }

        public IActionResult ForgetPassword()
        { return View(); }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPassWordModel input )
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(input.Email);
                if (user is not null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var url = Url.Action("ReetPassword", "Account", new { email = input.Email, Token = token }, Request.Scheme);
                }

            }
            
            return View(); }
    }
}
