using System.Threading.Tasks;
using Abp.Application.Services;
using Futbol3.Authorization.Accounts.Dto;

namespace Futbol3.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
