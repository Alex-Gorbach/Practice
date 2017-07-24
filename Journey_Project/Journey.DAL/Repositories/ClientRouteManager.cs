using Journey.DAL.EF;
using Journey.DAL.Entities;
using Journey.DAL.Interfaces;
using System.Collections.Generic;

namespace Journey.DAL.Repositories
{
    class ClientRouteManager : IClientRouteManager
    {
        public ApplicationContext Database { get; set; }
        public ClientRouteManager(ApplicationContext db)
        {
            Database = db;
        }


        public void Create(ClientRoute item)
        {
            Database.ClientRoutes.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }



    }
}
