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
    public class TravelAgentApplication : BasicEntity
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

        public ICollection<EmployeeApplication> Employees { get; set; }
    }

    public class EmployeeApplication  
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string EmployeeEmail { get; set; }

        [MaxLength(100)]
        public string Role { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        public int TravelAgentApplicationId { get; set; }

        [ForeignKey(nameof(TravelAgentApplicationId))]
        public TravelAgentApplication TravelAgentApplication { get; set; }
    }

}
