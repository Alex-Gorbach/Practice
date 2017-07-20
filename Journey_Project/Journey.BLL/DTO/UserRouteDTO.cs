using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.BLL.DTO
{
    class UserRouteDTO
    {
        public string Id { get; set; }
        public string UserID { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string Waypoints { get; set; }
        public DateTime Date { get; set; }
        public int Seat { get; set; }
    }
}
