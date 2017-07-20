using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Journey.BLL.DTO;
using Journey.BLL.Infrastructure;
using Journey.DAL.Entities;


// Through the objects of this interface, the presentation layer will interact with the level
// access to data. Only three methods are defined here: Create (creating users),
// Authenticate (user authentication) and SetInitialData (setting the initial data in the DB - admin and the list of roles).

namespace Journey.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<OperationDetails> Delete(String Id);
        Task<OperationDetails> Update(String Id);
        List<UserDTO> GetAllUsersInformation();
         Task<ClaimsIdentity> Authenticate(UserDTO userDto);

        Task SetInitialData(UserDTO adminDto,List<string> roles);
    }
}
