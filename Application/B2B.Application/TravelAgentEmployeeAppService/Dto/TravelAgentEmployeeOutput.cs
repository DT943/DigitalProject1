using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.TravelAgentEmployeeAppService.Dto
{
    public class TravelAgentEmployeeGetDto
    {
        public int Id { get; set; }
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
    }

    public class TravelAgentEmployeeGetAllDto
    {
        public int Id { get; set; }
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
    }
}
