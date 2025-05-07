using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.TravelAgentApplicationAppService.Dto
{ 
    public class TravelAgentApplicationGetDto
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string TravelAgencyName { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string AccelAeroUserName { get; set; }

        [MaxLength(100)]
        public string POS { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        public ICollection<EmployeeApplicationGetDto> Employees { get; set; }
    }


    public class EmployeeApplicationGetDto
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string EmployeeEmail { get; set; }

         public string EmployeeFirstName { get; set; }

         public string EmployeeLastName { get; set; }


        [MaxLength(100)]
        public string Role { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        public int TravelAgentApplicationId { get; set; }
    }

    public class TravelAgentApplicationGetAllDto
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string TravelAgencyName { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string AccelAeroUserName { get; set; }

        [MaxLength(100)]
        public string POS { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        public ICollection<EmployeeApplicationGetDto> Employees { get; set; }
    }
}
