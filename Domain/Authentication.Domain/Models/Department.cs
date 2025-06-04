using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Authentication.Domain.Models
{
    public class Department 
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Code { get; set; }

        [MaxLength(100)]
        public string DepartmentName { get; set; }
        [MaxLength(100)]
        public string? ParentDepartmentName { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [MaxLength(50)]
        public string? ModifiedBy { get; set; }

    }
}
