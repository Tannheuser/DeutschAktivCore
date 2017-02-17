using System.Collections.Generic;
using System.Threading.Tasks;
using DeutschAktiv.Web.ViewModels;

namespace DeutschAktiv.Web.Services.Abstract
{
    public interface IClubService
    {
        IEnumerable<ClubDto> GetClubs();
        Task<IEnumerable<ClubDto>> GetClubsAsync();
        IEnumerable<ClubDto> GetMasterClasses();
        Task<IEnumerable<ClubDto>> GetMasterClassesAsync();
    }
}