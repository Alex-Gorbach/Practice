using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Journey.WEB.Controllers
{
    public class GoogleMapController : Controller
    {
        // GET: GoogleMap
        public ActionResult Index()
        {
            return View();
        }
        
    
        [Authorize]
        public ActionResult Create_Route()
        {
            return View();
        }
    }
}