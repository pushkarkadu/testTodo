using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyApplication.Controllers
{
    public abstract class MyApplicationControllerBase: AbpController
    {
        protected MyApplicationControllerBase()
        {
            LocalizationSourceName = MyApplicationConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
