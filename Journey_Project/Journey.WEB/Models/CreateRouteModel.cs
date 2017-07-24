using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Journey.WEB.Models
{
    public class CreateRouteModel
    {
        [Required]
        public string StartPoint { get; set; }
        [Required]
        public string EndPoint { get; set; }
        [Required]
        public int Seats { get; set; }
        [Required]
        public List<string> Waypoints { get; set;}

        [Required]
        public DateTime Date { get; set; }

    }
}