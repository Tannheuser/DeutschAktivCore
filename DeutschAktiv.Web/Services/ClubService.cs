﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeutschAktiv.Core.Constant;
using DeutschAktiv.Core.Models;
using DeutschAktiv.Web.Services.Abstract;
using DeutschAktiv.Web.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DeutschAktiv.Web.Services
{
    public class ClubService : BaseService<Club, ClubDto>, IClubService
    {
        public ClubService(IMapper mapper, DataContext context) : base(mapper, context)
        {

        }

        public IEnumerable<ClubDto> GetClubs()
        {
            var clubs = Context.Clubs.Where(c => c.Enabled && c.Type == ClubType.Club);
            return MapToViewModel(clubs);
        }

        public async Task<IEnumerable<ClubDto>> GetClubsAsync()
        {
            var clubs = await Context.Clubs.Where(c => c.Enabled && c.Type == ClubType.Club).ToListAsync();
            return MapToViewModel(clubs);
        }

        public IEnumerable<ClubDto> GetMasterClasses()
        {
            var masterClasses = Context.Clubs.Where(c => c.Enabled && c.Type == ClubType.MasterClass);
            return MapToViewModel(masterClasses);
        }

        public async Task<IEnumerable<ClubDto>> GetMasterClassesAsync()
        {
            var masterClasses = await Context.Clubs.Where(c => c.Enabled && c.Type == ClubType.MasterClass).ToListAsync();
            return MapToViewModel(masterClasses);
        }
    }
}