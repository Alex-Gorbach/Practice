using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Journey.WEB.Models;
using Journey.BLL.DTO;
using System.Security.Claims;
using Journey.BLL.Interfaces;
using Journey.BLL.Infrastructure;
using System.Net;


namespace Journey.WEB.Controllers
{
    public class GoogleMapController : Controller
    {

        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: GoogleMap
        public ActionResult SuccesCreated()
        {
            return View();
        }

        

        [Authorize]
        public ActionResult CreateRoute()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateRoute(CreateRouteModel model)
        {
            if (ModelState.IsValid)
            {
                UserRouteDTO userRouteDto = new UserRouteDTO
                {
                    StartPoint = model.StartPoint,
                    Seats=model.Seats,
                    EndPoint = model.EndPoint,
                    Waypoints =string.Join(",",model.Waypoints),
                    Date = model.Date,
                    UserID = User.Identity.GetUserId()
                };

                OperationDetails operationDetails = await UserService.CreateRoute(userRouteDto);
                if (operationDetails.Succedeed)
                    return View("SuccesCreated");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }

            return View();
        }
    }
}