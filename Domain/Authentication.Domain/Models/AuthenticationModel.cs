using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Models
{
    public class AuthenticationModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public int NumberOfLogin { get; set; }

        public string? ManagerCode { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }


    public class AuthenticationModelWithClaims
    {
        public  bool Valid { get; set; }
        public IEnumerable<ClaimModel> Claims { get; set; }
    }

    public class ClaimModel
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }


    public class DecryptedToken
    {
        public string email { get; set; }
        public string password { get; set;}
        public string decryptedToken { get; set; }
    }
}
