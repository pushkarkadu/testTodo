using System.Threading.Tasks;
using Abp.Application.Services;
using MyApplication.Sessions.Dto;

namespace MyApplication.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
