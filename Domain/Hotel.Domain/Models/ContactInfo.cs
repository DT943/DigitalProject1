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
    public class ContactInfo : BasicEntityWithAuditInfo
    {
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        [MaxLength(50)]
        public string Category { get; set; }
        [MaxLength(50)]
        public string ContactType { get; set; }
        public bool IsPrimary { get; set; } = false;
        [MaxLength(50)]

        public string PhoneNumber { get; set; }
        [MaxLength(50)]

        public string Email {  get; set; }
        public string? Url { get; set; }
        [MaxLength(50)]

        public string ResponsiblePerson { get; set; }
    }
}
