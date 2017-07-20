using Journey.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace Journey.DAL.Identity
{
    // This class will manage users: add them to the database and authenticate.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            :base(store)
        {

        }
    }
}
