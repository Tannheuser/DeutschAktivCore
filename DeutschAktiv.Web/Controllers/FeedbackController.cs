﻿using System.Threading.Tasks;
using DeutschAktiv.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeutschAktiv.Web.Controllers
{
    public class FeedbackController : Controller
    {
        [Route("enrol")]
        public IActionResult Enrol()
        {
            return View();
        }

        [Route("enrol")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enrol([FromForm]ClientMessageDto message)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home", new {area = ""});
            }

            return View(message);
        }
    }
}