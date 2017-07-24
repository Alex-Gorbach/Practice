using Journey.DAL.Entities;
using System;

namespace Journey.DAL.Interfaces
{
    // user route management interface
    public interface IClientRouteManager: IDisposable
    {
        // method for creating a new user's route
        void Create(ClientRoute item); 
    }
}
