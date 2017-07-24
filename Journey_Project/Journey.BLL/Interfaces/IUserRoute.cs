using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Journey.BLL.DTO;
using Journey.BLL.Infrastructure;
using Journey.DAL.Entities;

namespace Journey.BLL.Interfaces
{
    public interface IUserRoute : IDisposable
    {
        Task<OperationDetails> Create(UserRouteDTO userRouteDto);
        Task<OperationDetails> Delete(UserRouteDTO userRouteDto);
        Task<OperationDetails> Update(UserRouteDTO userRouteDto);





        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
