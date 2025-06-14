using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loyalty.Application.TierDetailsAppService.Dto;

namespace Loyalty.Application.MemberTierDetailsAppService.Dto
{
    public class MemberTierDetailsGetDto
    {
        public int Id { get; set; }
        public int TierId { get; set; } 

        public DateTime? FulfillDate { get; set; } = DateTime.Now;

        public DateTime? EndDate { get; set; }

        public TierDetailsGetDto TierDetails { get; set; }
    }
}
