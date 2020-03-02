using Abp.Application.Services;
using MyApplication.MultiTenancy.Dto;

namespace MyApplication.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

