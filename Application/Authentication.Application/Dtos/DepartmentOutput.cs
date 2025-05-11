using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Dtos
{
    public class DepartmentGetDto
    {

        [MaxLength(100)]
        public string Code { get; set; }

        [MaxLength(100)]
        public string DepartmentName { get; set; }
        [MaxLength(100)]
        public string? ParentDepartmentName { get; set; }

    }
    public class DepartmentFakeDeleteDto
    {
        public string Code { get; set; }

        public bool IsDeleted { get; set; }
    }

}
