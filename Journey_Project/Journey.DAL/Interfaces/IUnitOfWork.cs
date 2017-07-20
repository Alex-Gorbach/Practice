using Journey.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace Journey.DAL.Interfaces
{
    // The UnitOfWork object will contain links to the managers
    // users and roles, as well as the user's repository.
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
