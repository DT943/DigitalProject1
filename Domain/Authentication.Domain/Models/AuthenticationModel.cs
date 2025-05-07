using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Models
{
    public class AuthenticationModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
    }
    public class AuthenticationModelWithDetailsWithToken : AuthenticationModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Token { get; set; }

        public int NumberOfLogin { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }


    public class AuthenticationModelWithDetailsWithoutTokenAndCode : AuthenticationModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ExpiresOn { get; set; }
        public int NumberOfLogin { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }

    public class AuthenticationModelWithDetails : AuthenticationModel
    {
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

}
