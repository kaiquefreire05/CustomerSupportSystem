﻿using CustomerSupportSystem.Enums;
using CustomerSupportSystem.Helper.Interfaces;
using CustomerSupportSystem.Models;
using Newtonsoft.Json;

namespace CustomerSupportSystem.Helper
{
    public class SessionService : ISessionService
    {
        // Dependencie Injection
        private readonly IHttpContextAccessor _contextAccessor;

        public SessionService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void CreateUserSession(UserModel user)
        {
            var userJson = JsonConvert.SerializeObject(user);
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            _contextAccessor.HttpContext.Session.SetString("loggedUserSession", userJson);
        }

        public int? GetUserId()
        {
            var user = GetUserSession();
            return user?.Id;
        }

        public UserModel GetUserSession()
        {
            #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            var userLogged = _contextAccessor.HttpContext.Session.GetString("loggedUserSession");
            if (string.IsNullOrEmpty(userLogged))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserModel>(userLogged);
        }

        public RoleEnum GetUserRole()
        {
            var user = GetUserSession();
            return user.Role;
        }

        public void RemoveUserSession()
        {
            _contextAccessor.HttpContext.Session.Remove("loggedUserSession");
        }
    }
}