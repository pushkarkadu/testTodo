using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyApplication.Roles.Dto;
using MyApplication.Users.Dto;

namespace MyApplication.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
