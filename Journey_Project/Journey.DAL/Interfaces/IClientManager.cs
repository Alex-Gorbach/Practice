using Journey.DAL.Entities;
using System;

namespace Journey.DAL.Interfaces
{
    // user profile management interface
    public interface IClientManager : IDisposable
    {
        // method for creating a new user profile
        void Create(ClientProfile item);


       
    }
}
