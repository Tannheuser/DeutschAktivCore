using System.Threading.Tasks;
using DeutschAktiv.Web.Services;
using DeutschAktiv.Web.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DeutschAktiv.Web.Controllers
{
    public class EducationController : Controller
    {
        private readonly IClubService _clubService;
        private readonly CourseService _courseService;

        public EducationController(IClubService clubService, CourseService courseService)
        {
            _clubService = clubService;
            _courseService = courseService;
        }

        [Route("courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetAllAsync();
            return View("Courses", courses);
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