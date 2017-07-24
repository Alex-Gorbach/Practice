using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Journey.DAL.Entities
{
    public class ClientRoute
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public string UserID { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public List<string> Waypoints { get; set; }
        public DateTime Date { get; set; }
        public int Seats { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}
