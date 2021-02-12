using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Futbol3.Authorization;

namespace Futbol3
{
    [DependsOn(
        typeof(Futbol3CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class Futbol3ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<Futbol3AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(Futbol3ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
