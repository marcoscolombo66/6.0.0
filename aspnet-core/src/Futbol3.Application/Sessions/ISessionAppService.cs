using System.Threading.Tasks;
using Abp.Application.Services;
using Futbol3.Sessions.Dto;

namespace Futbol3.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
