using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Journey.WEB.Models;
using Journey.BLL.DTO;
using System.Security.Claims;
using Journey.BLL.Interfaces;
using Journey.BLL.Infrastructure;
using System.Net;
using Journey.DAL.Entities;

namespace Journey.WEB.Controllers
{
    public class AccountController : Controller
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

        public ActionResult Login()
        {
            List<UserDTO> users = new List<UserDTO>();
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if(ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if(claim==null)
                {
                    ModelState.AddModelError("", "Неверный логин и пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    },claim);
                return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }








        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if(ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Lastname = model.Lastname,
                    Name = model.Name,
                    Role = "user"
                };
                
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
        public ActionResult HelloWorld()
        {
            ViewData["Message"] = "Hello World!";
            return View();
        }

        public new ActionResult Profile()
        {
            
            return View();
        }
        [Authorize(Roles = "admin")]

        public  ActionResult Administration()
        {
            List<UserDTO> users = UserService.GetAllUsersInformation();
            
            return View(users);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            OperationDetails operationDetails = await UserService.Delete(id);
            if (operationDetails.Succedeed)
            {
                return View("SuccesDeleted");
            }
            else
            {
                ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                return View("Administration");
            }
              
        }


        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "someemail@mail.ru",
                UserName = "someemail@mail.ru",
                Password = "123qwe",
                Name = "John",
                Lastname = "Doe",
                Role = "admin",
            },new List<string> { "user","admin"});
        }

      
    }
}