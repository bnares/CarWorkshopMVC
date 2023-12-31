﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.ApplicationUser
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public CurrentUser? GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("Context user is not present");
            }
            if (user.Identity==null||!user.Identity.IsAuthenticated) return null;
            var id = user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(x => x.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(c=>c.Type==ClaimTypes.Role).Select(c=>c.Value).ToList();
            return new CurrentUser(id, email, roles);
        }
    }
}
