using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

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
            return NotFound("COntacts not implemented yet");
        }
    }
}