using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Domain.Models;


namespace Offer.Domain.Models
{
    public class Offer : BasicEntityWithAuditInfo
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public string Type { get; set; }
        public string Segment { get; set; }
        public bool Membership { get; set; }

    }
}
