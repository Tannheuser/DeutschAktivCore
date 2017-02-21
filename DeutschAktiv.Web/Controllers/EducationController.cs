using System.Linq;
using System.Threading.Tasks;
using DeutschAktiv.Web.Services;
using DeutschAktiv.Web.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DeutschAktiv.Web.Controllers
{
    public class EducationController : Controller
    {
        private readonly IClubService _clubService;
        private readonly IScheduleService _scheduleService;
        private readonly CourseService _courseService;

        public EducationController(IClubService clubService, CourseService courseService, IScheduleService scheduleService)
        {
            _clubService = clubService;
            _courseService = courseService;
            _scheduleService = scheduleService;
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
        public async Task<IActionResult> GetSchedule()
        {
            var schedule = await _scheduleService.GetCurrentAsync();
            return View("Schedule", schedule.OrderBy(s => s.Date));
        }
    }
}