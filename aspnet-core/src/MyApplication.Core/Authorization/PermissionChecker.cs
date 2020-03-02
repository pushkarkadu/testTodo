using Abp.Authorization;
using MyApplication.Authorization.Roles;
using MyApplication.Authorization.Users;

namespace MyApplication.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
