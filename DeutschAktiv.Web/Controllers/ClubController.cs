﻿using System.Threading.Tasks;
using DeutschAktiv.Web.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DeutschAktiv.Web.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubService _clubService;

        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [Route("clubs")]
        public async Task<IActionResult> GetClubs()
        {
            var clubs = await _clubService.GetClubsAsync();
            return View("ClubList", clubs);
        }

        [Route("masters")]
        public async Task<IActionResult> GetMasterClasses()
        {
            var masterClasses = await _clubService.GetMasterClassesAsync();
            return View("MasterClassList", masterClasses);
        }
    }
}