using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace B2B.Domain.Models
{
    public class TravelAgentEmployee : BasicEntityWithAuditInfo
    {
        [Required]
        [MaxLength(100)]
        public string EmployeeEmail { get; set; }


        [MaxLength(100)]
        public string? EmployeeRole { get; set; }
        [Required]
        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        public string UserCode { get; set; }

        [MaxLength(100)]
        public string ManagerCode { get; set; }

        public int TravelAgentOfficeId { get; set; }
        [ForeignKey("TravelAgentOfficeId")]
        public TravelAgentOffice TravelAgentOffice { get; set; }


    }
}
