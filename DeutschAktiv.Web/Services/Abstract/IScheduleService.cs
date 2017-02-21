using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeutschAktiv.Web.ViewModels;

namespace DeutschAktiv.Web.Services.Abstract
{
    public interface IScheduleService
    {
        IEnumerable<ScheduleItemDto> GetCurrent();
        Task<IEnumerable<ScheduleItemDto>> GetCurrentAsync();
        IEnumerable<ScheduleItemDto> GetForPeriod(DateTime startDate, DateTime endDate);
        Task<IEnumerable<ScheduleItemDto>> GetForPeriodAsync(DateTime startDate, DateTime endDate);
    }
}