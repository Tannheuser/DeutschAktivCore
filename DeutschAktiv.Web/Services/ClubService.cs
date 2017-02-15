using AutoMapper;
using DeutschAktiv.Core.Models;
using DeutschAktiv.Web.ViewModels;

namespace DeutschAktiv.Web.Services
{
    public class ClubService : BaseService<Club, ClubDto>
    {
        public ClubService(IMapper mapper, DataContext context) : base(mapper, context)
        {
        }
    }
}