using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Journey.DAL.Entities;

namespace Journey.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionStrings) : base("DefaultConnection") { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}