using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Futbol3.EntityFrameworkCore;
using Futbol3.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Futbol3.Web.Tests
{
    [DependsOn(
        typeof(Futbol3WebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class Futbol3WebTestModule : AbpModule
    {
        public Futbol3WebTestModule(Futbol3EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Futbol3WebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(Futbol3WebMvcModule).Assembly);
        }
    }
}