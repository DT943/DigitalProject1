using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Event.Domain.Models
{
    public class TicketInventory : BasicEntityWithAuditInfo
    {

        public string TicketNumber { get; set; }
        public string UserName {  get; set; }
        public string Status { get; set; }
        public string PaymentTransaction { get; set; }
        public DateTime TicketIssueDate { get; set; }

        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

    }
}
