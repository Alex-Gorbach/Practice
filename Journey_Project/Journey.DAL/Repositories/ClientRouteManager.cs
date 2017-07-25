using Journey.DAL.EF;
using Journey.DAL.Entities;
using Journey.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Journey.DAL.Repositories
{
    class ClientRouteManager : IClientRouteManager
    {
        public ApplicationContext Database { get; set; }
        public ClientRouteManager(ApplicationContext db)
        {
            Database = db;
        }


        public List<ClientRoute> GetallUsesRoutes(string id)
        {
            var d= Database.ClientRoutes.Where(x =>x.UserID == id).ToList();
            return d;
        }
        public ClientRoute GetOneUsesRouteInformation(int id)
        {
           
            
               var d = Database.ClientRoutes.Where(x => x.Id == id).ToList();
            ClientRoute route = new ClientRoute {
                Date = d[0].Date,
                Seats=d[0].Seats,
                StartPoint=d[0].StartPoint,
                EndPoint=d[0].EndPoint,
                Waypoints=d[0].Waypoints,
            };
            return route;
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
