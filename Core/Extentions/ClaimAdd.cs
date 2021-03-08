using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extentions
{
    public static class ClaimAdd
    {
        public static void AddId(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddMail(this ICollection<Claim> claims, string Email)
        {
            claims.Add(new Claim(ClaimTypes.Email, Email));
        }

        public static void AddFullName(this ICollection<Claim> claims, string FirstName, string LastName)
        {
            claims.Add(new Claim(ClaimTypes.Name, FirstName+ " "+ LastName));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
