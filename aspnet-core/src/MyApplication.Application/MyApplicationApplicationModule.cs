using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyApplication.Authorization;

namespace MyApplication
{
    [DependsOn(
        typeof(MyApplicationCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyApplicationApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyApplicationAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyApplicationApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
