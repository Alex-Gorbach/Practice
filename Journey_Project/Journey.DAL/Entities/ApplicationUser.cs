using Microsoft.AspNet.Identity.EntityFramework;

namespace Journey.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
        public virtual ClientRoute ClientRoute { get; set; }
    }
}
