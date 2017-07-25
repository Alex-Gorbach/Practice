using Journey.DAL.Entities;
using System;
using System.Collections.Generic;

namespace Journey.DAL.Interfaces
{
    // user route management interface
    public interface IClientRouteManager: IDisposable
    {
        // method for creating a new user's route
        void Create(ClientRoute item);
        List<ClientRoute> GetallUsesRoutes(string id);
        ClientRoute GetOneUsesRouteInformation(int id);
    }
}
