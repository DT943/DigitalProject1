using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Dtos
{
    public class CreateDepartmentDto
    {
        [MaxLength(100)]
        public string DepartmentName { get; set; }
        [MaxLength(100)]
        public string? ParentDepartmentName { get; set; }
    }

}
