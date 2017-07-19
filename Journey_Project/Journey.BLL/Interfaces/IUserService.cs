using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Journey.BLL.DTO;
using Journey.BLL.Infrastructure;
using Journey.DAL.Entities;


//Через объекты данного интерфейса уровень представления будет взаимодействовать с уровнем
//доступа к данным.Здесь определены только три метода: Create(создание пользователей),
//Authenticate(аутентификация пользователей) и SetInitialData(установка начальных данных в БД - админа и списка ролей).

namespace Journey.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<OperationDetails> Delete(String Id);
        Task<OperationDetails> Update(String Id);
        List<ApplicationUser> GetAllUsers();
         Task<ClaimsIdentity> Authenticate(UserDTO userDto);

        Task SetInitialData(UserDTO adminDto,List<string> roles);
    }
}
