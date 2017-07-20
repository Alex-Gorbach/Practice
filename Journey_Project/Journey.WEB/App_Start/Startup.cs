using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Journey.BLL.Services;
using Microsoft.AspNet.Identity;
using Journey.BLL.Interfaces;


[assembly: OwinStartup(typeof(Journey.WEB.App_Start.Startup))]

namespace Journey.WEB.App_Start
{
    public class Startup
    {
        // creates a service for working with services
        IServiceCreator serviceCreator = new ServiceCreator();
    public void Configuration(IAppBuilder app)
    {
            // сервис региструется контекстом OWIN
            app.CreatePerOwinContext<IUserService>(CreateUserService);
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            LoginPath = new PathString("/Account/Login"),
        });
    }

    private IUserService CreateUserService()
    {
        return serviceCreator.CreateUserService("DefaultConnection");
    }
}
}