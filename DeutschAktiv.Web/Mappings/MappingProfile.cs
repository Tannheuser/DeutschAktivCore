using AutoMapper;
using DeutschAktiv.Core.Models;
using DeutschAktiv.Web.ViewModels;

namespace DeutschAktiv.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Club, ClubDto>();
        }
    }
}