using System.Threading.Tasks;
using MyApplication.Configuration.Dto;

namespace MyApplication.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
