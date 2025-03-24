using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Dtos
{
    public class AddUserDto
    {
        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }

        public string? Role {  get; set; }
        public string? Department { get; set; }

        public bool IsActive { get; set; }

    }
}
