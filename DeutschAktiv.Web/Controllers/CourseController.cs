using System.Threading.Tasks;
using DeutschAktiv.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeutschAktiv.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [Route("courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseService.GetAllAsync();
            return View("CourseList", courses);
        }
    }
}