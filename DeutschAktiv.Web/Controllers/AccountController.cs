using System.Threading.Tasks;
using DeutschAktiv.Core.Models;
using DeutschAktiv.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace DeutschAktiv.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountDto account)
        {
            if (ModelState.IsValid)
            {
                var status = await _signInManager.PasswordSignInAsync(account.UserName, account.Password, false, false);
                if (status == SignInResult.Success)
                {
                    return RedirectToAction("Index", "Home", new {area = ""});
                }

                ModelState.AddModelError(string.Empty, "Неверное имя пользователя или пароль");
            }

            return View(account);
        }
    }
}