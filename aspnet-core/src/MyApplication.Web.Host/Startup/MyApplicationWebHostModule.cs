using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyApplication.Configuration;

namespace MyApplication.Web.Host.Startup
{
    [DependsOn(
       typeof(MyApplicationWebCoreModule))]
    public class MyApplicationWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyApplicationWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyApplicationWebHostModule).GetAssembly());
        }
    }
}
