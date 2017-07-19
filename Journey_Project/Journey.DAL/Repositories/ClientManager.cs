using Journey.DAL.EF;
using Journey.DAL.Entities;
using Journey.DAL.Interfaces;
using System.Collections.Generic;

namespace Journey.DAL.Repositories
{
    class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile Item)
        {
         
            Database.ClientProfiles.Add(Item);
            Database.SaveChanges();
        }


        



  

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
