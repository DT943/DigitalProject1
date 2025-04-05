using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Domain.Models;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Event.Application.EventAppService.Dtos
{
    public class EventCreateDto : IValidatableDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? Rank { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Category { get; set; }
        public string? EventType { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? BasePrice { get; set; }
        public int? TotalCapacity { get; set; }
     }

    public class EventUpdateDto : IEntityUpdateDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? Rank { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Category { get; set; }
        public string? EventType { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? BasePrice { get; set; }
        public int? TotalCapacity { get; set; }
    }

}
