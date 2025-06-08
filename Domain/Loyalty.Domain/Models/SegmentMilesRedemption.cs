using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace Loyalty.Domain.Models
{
    public class SegmentMilesRedemption : BasicEntity
    {
        [MaxLength(10)]
        public string Origin { get; set; }

        [MaxLength(10)]
        public string Destination { get; set; }

        [MaxLength(10)]
        public string COS { get; set; }

        public int RedemptionValue { get; set; }

    }
}