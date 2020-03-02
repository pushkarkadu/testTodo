using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyApplication.Configuration.Dto;

namespace MyApplication.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MyApplicationAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
