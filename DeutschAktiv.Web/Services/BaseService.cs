using System.Collections.Generic;
using AutoMapper;
using DeutschAktiv.Core.Models;
using DeutschAktiv.Web.ViewModels;

namespace DeutschAktiv.Web.Services
{
    public class BaseService<T, Dt> where T: BaseItem where Dt : BaseDto
    {
        protected readonly IMapper Mapper;
        protected readonly DataContext Context;

        protected BaseService(IMapper mapper, DataContext context)
        {
            Mapper = mapper;
            Context = context;
        }

        public IEnumerable<Dt> GetAll()
        {
            return Mapper.Map<IEnumerable<T>, IEnumerable<Dt>>(Context.Set<T>());
        }
    }
}