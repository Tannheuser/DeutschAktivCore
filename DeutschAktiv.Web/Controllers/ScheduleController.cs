using System.Linq;
using System.Threading.Tasks;
using DeutschAktiv.Web.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DeutschAktiv.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [Route("schedule")]
        public async Task<IActionResult> GetSchedule()
        {
            var schedule = await _scheduleService.GetCurrentAsync();
            return View("ScheduleList", schedule.OrderBy(s => s.Date));
        }
    }
}