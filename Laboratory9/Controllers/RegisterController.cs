using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Laboratory9.Entities;

namespace Laboratory9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private LinkContext context = new LinkContext();
        [HttpGet]
        public async Task<string> GetAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
                return "Укажите имя";
            else if (string.IsNullOrEmpty(password))
                return "Укажите пароль";
            if (context.Users.Any(usr => usr.Username == username))
                return "Данное имя пользователя уже занято";
            UserInfo newUser = new UserInfo()
            {
                Username = username,
                PasswordHash = Crypto.HashPassword(password)
            };
            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();
            return $"Пользователь \"{username}\" с паролем \"{password}\" создан";
        }
    }
}
