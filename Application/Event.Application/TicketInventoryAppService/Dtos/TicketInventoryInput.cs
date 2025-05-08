using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Domain.Models;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Event.Application.TicketInventoryAppService.Dtos
{
    public class TicketInventoryCreateDto : IValidatableDto
    {
        public string TicketNumber { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string PaymentTransaction { get; set; }
        public DateTime TicketIssueDate { get; set; }

        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }

    public class TicketInventoryUpdateDto : IEntityUpdateDto
    {
        public string TicketNumber { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string PaymentTransaction { get; set; }
        public DateTime TicketIssueDate { get; set; }

        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }


    public class TicketInventoryBuyDto 
    {
         public string UserName { get; set; }
         public string PaymentTransaction { get; set; }
         public int TicketId { get; set; }
         public int Quantity { get; set; } 
    }
}
