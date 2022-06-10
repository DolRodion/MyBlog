using Microsoft.AspNetCore.Identity;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.Application.Params;
using System;
using System.Threading.Tasks;

namespace MyBlog.Application.Services
{
    public class AccountService : IAccountService
    {
        /// <summary>
        /// Метод для авторизации
        /// </summary>
        public bool Autorization(FormAuthorizationParams formAuthorizationParams)
        {
            if (formAuthorizationParams.Email == "dolrodion@gmail.com" && formAuthorizationParams.Password == "rodion")
            { 
                return true;
            }
            else
            {
                throw new Exception("Неверные данные для входа");
            };
        }
    }
}
