using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Application.TicketInventoryAppService.Dtos;
using Event.Domain.Models;

namespace Event.Application.TicketAppService.Dtos
{
    public class TicketGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? AvailableForSales { get; set; }
        public int EventId { get; set; }
        public int SoldTicketCount { get; set; }
    }

    public class TicketGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? AvailableForSales { get; set; }
        public int EventId { get; set; }
        public int SoldTicketCount { get; set; }
    }
}
