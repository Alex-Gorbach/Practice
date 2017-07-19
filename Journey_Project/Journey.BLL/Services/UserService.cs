﻿using Journey.BLL.DTO;
using Journey.BLL.Infrastructure;
using Journey.DAL.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Journey.BLL.Interfaces;
using Journey.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
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


        public   List<ApplicationUser> GetAllUsers()
        {
           
            List<ApplicationUser> users = Database.UserManager.Users.ToList();
            
       
            return users;
        }


        public async Task<OperationDetails> Delete(string Id)
        {
            ApplicationUser user =  Database.UserManager.FindById(Id);
           
            var result =  Database.UserManager.Delete(user);
              await Database.SaveAsync();
            if (result.Succeeded)
            {
                return new OperationDetails(true, "Пользователь Удален", "");
            }
            else
            {
                return new OperationDetails(false, "Ошибка удаления пользователя", "");

            }
            
     
        }


        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Name };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
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
            // находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }


        //начальная инициализация бд
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

    }

    
}