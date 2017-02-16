using System.Collections.Generic;
using System.Threading.Tasks;
using DeutschAktiv.Web.Services;
using DeutschAktiv.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeutschAktiv.Web.ViewComponents
{
    [ViewComponent(Name="ClubTiles")]
    public class ClubTiles : ViewComponent
    {
        private readonly ClubService _service;

        public ClubTiles(ClubService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clubs = await GetClubsAsync();
            return View(clubs);
        }

        private Task<IEnumerable<ClubDto>> GetClubsAsync()
        {
            return _service.GetAllAsync();
        }
    }
}