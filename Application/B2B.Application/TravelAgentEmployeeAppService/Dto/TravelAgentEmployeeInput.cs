using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace B2B.Application.TravelAgentEmployeeAppService.Dto
{
    public class TravelAgentEmployeeCreateDto : IValidatableDto
    {
        [Required]
        [MaxLength(100)]
        public string EmployeeEmail { get; set; }
        [Required]
        [MaxLength(100)]
        public string EmployeeFirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmployeeLastName { get; set; }

        [MaxLength(100)]
        public string? EmployeeRole { get; set; }
        [Required]
        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        public string? UserCode { get; set; }

        [MaxLength(100)]
        public string? ManagerCode { get; set; }

        public int TravelAgentOfficeId { get; set; }
    }


    public class TravelAgentEmployeeUpdateDto : IEntityUpdateDto
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
    }
}


 