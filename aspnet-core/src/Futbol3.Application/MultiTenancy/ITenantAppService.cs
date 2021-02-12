using Abp.Application.Services;
using Futbol3.MultiTenancy.Dto;

namespace Futbol3.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

