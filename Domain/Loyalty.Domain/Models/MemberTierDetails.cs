using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class MemberTierDetails : BasicEntity
    {
        [MaxLength(100)]
        public string CIS { get; set; }

        public int? ReversalId { get; set; }

        public string TierId { get; set; } = "Blue";

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? UnitTotal { get; set; }

        public int? TXTotal { get; set; }

        public DateTime? FulfillDate { get; set; } = DateTime.Now;

        public string? TierUpgradeType { get; set; }

        public string? Reason { get; set; }

    }
}
