using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Hotel.Domain.Models
{
    public class Contract : BasicEntityWithAuditInfo
    {
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public string? ContractFileUrl { get; set; }

        [MaxLength(100)]
        public string? ContractFileCode { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


    }
}
