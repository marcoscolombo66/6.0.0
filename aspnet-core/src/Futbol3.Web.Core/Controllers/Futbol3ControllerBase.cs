using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Futbol3.Controllers
{
    public abstract class Futbol3ControllerBase: AbpController
    {
        protected Futbol3ControllerBase()
        {
            LocalizationSourceName = Futbol3Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
