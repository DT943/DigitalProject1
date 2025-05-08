using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Event.Domain.Models
{
    public class Event : BasicEntityWithAuditInfo
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? Rank { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [MaxLength(100)]
        public string? Category {  get; set; }

        [MaxLength(100)]
        public string? EventType { get; set; }
         public string? Address { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        [MaxLength(50)]
        public string? Country { get; set; }
        public int? BasePrice {  get; set; }
        public int? TotalCapacity { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

    }
}
