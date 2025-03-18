using System;
using System.Collections.Generic;
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
        public string PhoneNumber { get; set; }
        public string Email {  get; set; }
        public string  ResponsiblePerson {  get; set; }
    }
}
