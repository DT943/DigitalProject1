using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.MemberTierDetailsAppService.Dto
{
    public class MemberTierDetailsCreateDto : IValidatableDto
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
    }

    public class MemberTierDetailsUpdateDto : IEntityUpdateDto
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
    }
}
