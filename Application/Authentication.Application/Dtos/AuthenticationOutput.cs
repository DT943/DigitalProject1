using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Dtos
{
    public class AuthenticationGetDto
    {
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ManagerCode { get; set; }

        public string Email { get; set; }

        public int NumberOfLogIn { get; set; }

        [MaxLength(50)]
        public string? Department { get; set; }

        public DateTime? LastLogIn { get; set; }

        public IEnumerable<string> Roles { get; set; }
        public List<string> Status { get; set; }
        public string Reason { get; set; }

    }

    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

}
