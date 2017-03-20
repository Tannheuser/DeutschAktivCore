using System.Threading.Tasks;
using DeutschAktiv.Core.Models;
using DeutschAktiv.Web.ViewModels;
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

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(AccountDto account)
        {
            _logger.LogWarning(account.UserName);
            var status = await _signInManager.PasswordSignInAsync(account.UserName, account.Password, false, false);
            if (status == SignInResult.Success)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            return View(account);
        }
    }
}