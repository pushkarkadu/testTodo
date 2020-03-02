using System.Threading.Tasks;
using Abp.Application.Services;
using MyApplication.Authorization.Accounts.Dto;

namespace MyApplication.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
