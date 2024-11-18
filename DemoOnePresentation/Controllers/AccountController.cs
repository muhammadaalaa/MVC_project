using DAL.Models;
using DemoOnePresentation.helper;
using DemoOnePresentation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DemoOnePresentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<applicationUser> _userManager;
        private readonly SignInManager<applicationUser> _signInManager;

        public AccountController(UserManager<applicationUser> userManager, SignInManager<applicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #region regerter
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(regesterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new applicationUser()
                {
                    UserName = model.Email.Split("@")[0],
                    Email = model.Email,
                    IsAgreed = model.IsAgreed,
                    FName = model.FirstName,
                    LName = model.Lastname,

                };
                var result = await _userManager.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    return RedirectToAction("login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {

                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        #endregion
        #region login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(loginViewMode model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var res = await _userManager.CheckPasswordAsync(user, model.password);

                    if (res)
                    {
                        var loginresult = await _signInManager.PasswordSignInAsync(user, model.password, model.remmberMe, false);
                        if (loginresult.Succeeded) return RedirectToAction("index", "home");


                    }
                    else

                        ModelState.AddModelError(string.Empty, "password is not correct");


                }
                else
                    ModelState.AddModelError(string.Empty, "email is not exist");


            }
            return View();
        }
        #endregion
        #region SignOut

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        #endregion
        #region ForgetPassword
        public IActionResult ForgetPassword()
        {
            return View();
        }
        #endregion

        public async Task<IActionResult> sendEmail(ForgetpasswordView model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var ResetPasswordLink = Url.Action("RessetPassword", "Account", new { email = user.Email, token }, Request.Scheme);
                    var Email = new Email
                    {
                        Subject = "Reset Password",
                        To = model.Email,
                        Body = ResetPasswordLink
                    };
                    EmailSetting.SendEmail(Email);
                    return RedirectToAction(nameof(CheckYouInBox));
                }


                else return View("ForgetPassword", model);

            }

            else return View("ForgetPassword", model);
        }
        public IActionResult CheckYouInBox()
        {
            return View();
        }
        public IActionResult Ressetpassword(string email, string token)
        {
            TempData["email"] = email; TempData["token"] = token;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ressetpassword(RessetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                string email = TempData["email"] as string;
                string token = TempData["token"] as string;

                var user = await _userManager.FindByEmailAsync(email);
                var res = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
                if (res.Succeeded) return RedirectToAction(nameof(Login));
                else
                    foreach (var err in res.Errors)
                        ModelState.AddModelError(string.Empty, err.Description);
            }
            return View();
        }
    }
}
