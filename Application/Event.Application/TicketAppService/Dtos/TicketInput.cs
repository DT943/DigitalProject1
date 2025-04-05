using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Event.Application.TicketAppService.Dtos
{
     public class TicketCreateDto : IValidatableDto
     {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? AvailableForSales { get; set; }
        public int EventId { get; set; }
     }

    public class TicketUpdateDto : IEntityUpdateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? AvailableForSales { get; set; }
        public int EventId { get; set; }
    }
}
