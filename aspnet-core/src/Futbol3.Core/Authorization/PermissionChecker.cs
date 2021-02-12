using Abp.Authorization;
using Futbol3.Authorization.Roles;
using Futbol3.Authorization.Users;

namespace Futbol3.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
