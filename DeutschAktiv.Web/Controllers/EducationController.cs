using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace DeutschAktiv.Web.Controllers
{
    public class EducationController : Controller
    {
        [Route("courses")]
        public IActionResult GetCourses()
        {
            return NotFound();
        }

        [Route("clubs")]
        public IActionResult GetClubs()
        {
            return View("Clubs");
        }

        [Route("masters")]
        public IActionResult GetMasterClasses()
        {
            return View("MasterClasses");
        }

        [Route("schedule")]
        public IActionResult GetSchedule()
        {
            return NotFound();
        }
    }
}