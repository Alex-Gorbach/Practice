using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Journey.DAL.Entities
{
    public class ClientRoute
    {
        [Key]
        public int Id { get; set; }

        public string UserID { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public string Waypoints { get; set; }
        public DateTime Date { get; set; }
        public int Seats { get; set; }

       

    }
}
