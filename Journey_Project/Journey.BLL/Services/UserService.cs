using Journey.BLL.DTO;
using Journey.BLL.Infrastructure;
using Journey.DAL.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Journey.BLL.Interfaces;
using Journey.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System;

namespace Journey.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Update(string Id)
        {
            ApplicationUser user = await Database.UserManager.FindByIdAsync(Id);
            var result = await Database.UserManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new OperationDetails(true, "Succes", "");
            }
            else
            {
                return new OperationDetails(false, "Failed", "");

            }

        }


        public   List<UserDTO> GetAllUsersInformation()
        {
            //Tuning Automaper
            Mapper.Initialize(cfg => cfg.CreateMap<ApplicationUser, UserDTO>()
             .ForMember("Id", opt => opt.MapFrom(c => c.ClientProfile.Id))
            .ForMember("Name", opt => opt.MapFrom(c => c.ClientProfile.Name))
            .ForMember("Password", opt => opt.MapFrom(c => c.PasswordHash))
            .ForMember("Lastname", opt => opt.MapFrom(src => src.ClientProfile.Lastname)));

            //Matching
            var u = Mapper.Map<IEnumerable<ApplicationUser>, List<UserDTO>>(Database.UserManager.Users.ToList());

            return u;
        }




        public async Task<OperationDetails> Delete(string Id)
        {
            ApplicationUser user =  Database.UserManager.FindById(Id);
           
            var result =  Database.UserManager.Delete(user);
              await Database.SaveAsync();
            if (result.Succeeded)
            {
                return new OperationDetails(true, "User deleteв", "");
            }
            else
            {
                return new OperationDetails(false, "Error removing user", "");

            }
            
     
        }


        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // add a role
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // create client profile
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Lastname = userDto.Lastname, Name = userDto.Name };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }


    
        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // Find the user
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            //Authorize it and return the object ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user,DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }


        //Initial initialization DB
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }


        public void Dispose()
        {
            Database.Dispose();
        }

        public Task<OperationDetails> Create(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDetails> Delete(UserDTO userDto)
        {
            throw new NotImplementedException();
        }


        public async Task<OperationDetails> CreateRoute(UserRouteDTO userRouteDto)
        {
          
          
                // create client route
                ClientRoute clientRoute = new ClientRoute {
                   
                    StartPoint = userRouteDto.StartPoint,
                    EndPoint = userRouteDto.EndPoint,
                    Waypoints= userRouteDto.Waypoints.ToString(),
                    UserID = userRouteDto.UserID,
                    Date = userRouteDto.Date,
                    Seats= userRouteDto.Seats
                };
                Database.ClientRouteManager.Create(clientRoute);
                await Database.SaveAsync();
                return new OperationDetails(true, "Route successfully created", "");
            
        }


        public async Task<OperationDetails> DeleteRoute(string Id)
        {
            ApplicationUser route = Database.UserManager.FindById(Id);

            var result = Database.UserManager.Delete(route);
            await Database.SaveAsync();
            if (result.Succeeded)
            {
                return new OperationDetails(true, "User deleteв", "");
            }
            else
            {
                return new OperationDetails(false, "Error removing user", "");

            }


        }


        public async Task<OperationDetails> UpdateRoute(string Id)
        {
            ApplicationUser route = Database.UserManager.FindById(Id);

            var result = Database.UserManager.Delete(route);
            await Database.SaveAsync();
            if (result.Succeeded)
            {
                return new OperationDetails(true, "User deleteв", "");
            }
            else
            {
                return new OperationDetails(false, "Error removing user", "");

            }


        }

        public List<UserRouteDTO> GetAllRouteInformation(string id)
        {

           
            //Tuning Automaper
            Mapper.Initialize(cfg => cfg.CreateMap<ClientRoute, UserRouteDTO>()
             .ForMember("StartPoint", opt => opt.MapFrom(c => c.StartPoint))
            .ForMember("EndPoint", opt => opt.MapFrom(c => c.EndPoint))
            .ForMember("Date", opt => opt.MapFrom(c => c.Date))
            .ForMember("Waypoints", opt => opt.MapFrom(src => src.Waypoints)));
            //Matching
            var u = Mapper.Map<IEnumerable<ClientRoute>, List<UserRouteDTO>>(Database.ClientRouteManager.GetallUsesRoutes(id));
            return u;
        }
        

        public UserRouteDTO GetDetailsForRoute(int id)
        {

           
            //Tuning Automaper
            Mapper.Initialize(cfg => cfg.CreateMap<ClientRoute, UserRouteDTO>()
             .ForMember("StartPoint", opt => opt.MapFrom(c => c.StartPoint))
            .ForMember("EndPoint", opt => opt.MapFrom(c => c.EndPoint))
            .ForMember("Date", opt => opt.MapFrom(c => c.Date))
            .ForMember("Waypoints", opt => opt.MapFrom(src => src.Waypoints)));
            //Matching
            var u = Mapper.Map<ClientRoute, UserRouteDTO>(Database.ClientRouteManager.GetOneUsesRouteInformation(id));
            return u;
        }

    }

    
}
