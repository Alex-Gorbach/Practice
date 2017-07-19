using Journey.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace Journey.DAL.Interfaces
{
    //Объект UnitOfWork будет содержать ссылки на менеджеры 
    //пользователей и ролей, а также на репозиторий пользователей.
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
