using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BranchesManagement.Domain.Models
{
    public class Branch : BasicEntityWithAuditInfo
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public string Location { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        public string EmailAddress { get; set; }

        public string OfficeHours { get; set; }
    }
}
