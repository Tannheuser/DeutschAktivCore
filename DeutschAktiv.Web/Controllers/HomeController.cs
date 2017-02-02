using Microsoft.AspNetCore.Mvc;

namespace DeutschAktiv.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("home")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("contacts")]
        public IActionResult Contacts()
        {
            return View();
        }

        [Route("error/{code?}")]
        public IActionResult Error(string code)
        {
            return code == "404" ? View("404") : View();
        }
    }
}