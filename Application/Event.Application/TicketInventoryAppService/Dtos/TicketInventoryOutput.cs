using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Domain.Models;

namespace Event.Application.TicketInventoryAppService.Dtos
{ 
    public class TicketInventoryGetDto
    {
        public string TicketNumber { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string PaymentTransaction { get; set; }
        public DateTime TicketIssueDate { get; set; }

        public int TicketId { get; set; }
    }

    public class TicketInventoryGetAllDto
    {
        public string TicketNumber { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string PaymentTransaction { get; set; }
        public DateTime TicketIssueDate { get; set; }

        public int TicketId { get; set; }
    }
}
