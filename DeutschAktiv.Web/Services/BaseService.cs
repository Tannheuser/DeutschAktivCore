using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DeutschAktiv.Core.Models;
using DeutschAktiv.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DeutschAktiv.Web.Services
{
    public class BaseService<M, Vm> where M : BaseItem where Vm : BaseDto
    {
        protected readonly IMapper Mapper;
        protected readonly DataContext Context;

        protected BaseService(IMapper mapper, DataContext context)
        {
            Mapper = mapper;
            Context = context;
        }

        public IEnumerable<Vm> GetAll()
        {
            return Mapper.Map<IEnumerable<M>, IEnumerable<Vm>>(Context.Set<M>());
        }

        public async Task<IEnumerable<Vm>> GetAllAsync()
        {
            var model = await Context.Set<M>().ToListAsync();
            return Mapper.Map<IEnumerable<M>, IEnumerable<Vm>>(model);
        }
    }
}