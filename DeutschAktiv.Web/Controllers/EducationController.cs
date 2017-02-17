using System.Threading.Tasks;
using DeutschAktiv.Web.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DeutschAktiv.Web.Controllers
{
    public class EducationController : Controller
    {
        protected readonly IClubService _clubService;

        public EducationController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [Route("courses")]
        public IActionResult GetCourses()
        {
            return View("Courses");
        }

        [Route("clubs")]
        public async Task<IActionResult> GetClubs()
        {
            var clubs = await _clubService.GetClubsAsync();
            return View("Clubs", clubs);
        }

        [Route("masters")]
        public async Task<IActionResult> GetMasterClasses()
        {
            var masterClasses = await _clubService.GetMasterClassesAsync();
            return View("MasterClasses", masterClasses);
        }

        [Route("schedule")]
        public IActionResult GetSchedule()
        {
            return View("Schedule");
        }
    }
}