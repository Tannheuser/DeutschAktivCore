using AutoMapper;
using DeutschAktiv.Core.Models;
using DeutschAktiv.Web.ViewModels;

namespace DeutschAktiv.Web.Services
{
    public class CourseService : BaseService<Course, CourseDto>
    {
        public CourseService(IMapper mapper, DataContext context) : base(mapper, context)
        {
        }
    }
}