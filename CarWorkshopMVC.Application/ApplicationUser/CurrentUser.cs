using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshopMVC.Application.ApplicationUser
{
    public class CurrentUser
    {
        public CurrentUser(string id, string email, IEnumerable<string> roles)
        {
            Id = id;
            Email = email;
            Roles = roles;
        }

        public string  Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }
    }
}
