using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.Models;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace B2B.Application.TravelAgentApplicationAppService.Dto
{
  

    public class TravelAgentApplicationCreateDto : IValidatableDto
    {
        [MaxLength(100)]
        public string TravelAgencyName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string AccelAeroUserName { get; set; }

        [MaxLength(100)]
        public string POS { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        public ICollection<EmployeeApplicationCreateDto> Employees { get; set; }
    }

    public class TravelAgentApplicationUpdateDto : IEntityUpdateDto
    {
        [MaxLength(100)]
        public string TravelAgencyName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string AccelAeroUserName { get; set; }

        [MaxLength(100)]
        public string POS { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        public ICollection<EmployeeApplicationUpdateDto> Employees { get; set; }
    }

    public class EmployeeApplicationCreateDto  
    {
        [MaxLength(100)]
        public string EmployeeEmail { get; set; }

        [MaxLength(100)]
        public string Role { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        public int TravelAgentApplicationId { get; set; }
  
    }

    public class EmployeeApplicationUpdateDto
    {
        [MaxLength(100)]
        public string EmployeeEmail { get; set; }

        [MaxLength(100)]
        public string Role { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        public int TravelAgentApplicationId { get; set; }
    }
}
