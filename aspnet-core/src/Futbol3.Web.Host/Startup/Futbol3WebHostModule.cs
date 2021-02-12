using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Futbol3.Configuration;

namespace Futbol3.Web.Host.Startup
{
    [DependsOn(
       typeof(Futbol3WebCoreModule))]
    public class Futbol3WebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public Futbol3WebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Futbol3WebHostModule).GetAssembly());
        }
    }
}
