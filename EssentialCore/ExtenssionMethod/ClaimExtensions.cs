using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCore.ExtenssionMethod
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claimCollection, string email)
        {
            claimCollection.Add(new Claim(ClaimTypes.Email, email));
        }

        public static void AddUser_Id(this ICollection<Claim> claimCollection, int User_Id)
        {
            claimCollection.Add(new Claim(ClaimTypes.NameIdentifier, User_Id.ToString()));
        }

        public static void AddFullName(this ICollection<Claim> claimCollection, string fullName)
        {
            claimCollection.Add(new Claim(ClaimTypes.Name, fullName));
        }

        public static void AddUserName(this ICollection<Claim> claimCollection, string userName)
        {
            claimCollection.Add(new Claim(ClaimTypes.Name, userName));
        }

 
    }
}
