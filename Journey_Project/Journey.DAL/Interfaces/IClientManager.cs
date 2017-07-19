using Journey.DAL.Entities;
using System;

namespace Journey.DAL.Interfaces
{
    //интерфейс управления профилями пользователей 
    public interface IClientManager : IDisposable
    {
        //метод создания нового профиля пользователя
        void Create(ClientProfile item);


       
    }
}
