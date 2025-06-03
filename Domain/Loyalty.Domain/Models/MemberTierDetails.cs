using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class MemberTierDetails :BasicEntity
    {

        public int MemberDemographicsAndProfileId { get; set; }

        public int? ReversalId { get; set; }

        public int TierId { get; set; } 

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? UnitTotal { get; set; }

        public int? TXTotal { get; set; }

        public DateTime? FulfillDate { get; set; } = DateTime.Now;

        public string? TierUpgradeType { get; set; }

        public string? Reason { get; set; }
        [ForeignKey(nameof(MemberDemographicsAndProfileId))]
        public MemberDemographicsAndProfile memberDemographicsAndProfile { get; set; }


        [ForeignKey(nameof(TierId))]
        public TierDetails TierDetails { get; set; }

        [MaxLength(4000)]
        public string? QrCode { get; set; }
    }
}
