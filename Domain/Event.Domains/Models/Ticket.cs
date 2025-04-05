using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Event.Domain.Models
{
    public class Ticket : BasicEntityWithAuditInfo
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public int? Price {  get; set; }

        public int? Quantity { get; set; }

        public bool? AvailableForSales { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        public Event Event { get; set; }

    }
}
