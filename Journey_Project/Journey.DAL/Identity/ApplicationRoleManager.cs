using Journey.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Journey.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
                    : base(store)
        { }
    }
}
