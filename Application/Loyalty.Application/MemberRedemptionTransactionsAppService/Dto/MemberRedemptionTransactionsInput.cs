using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace Loyalty.Application.MemberRedemptionTransactions.Dto
{
    public class MemberRedemptionTransactionsCreateDto : IValidatableDto
    {

        [MaxLength(100)]
        public string CIS { get; set; }
        [MaxLength(50)]

        public string? PartnerId { get; set; }

        public int? CertificateNum { get; set; }

        public int? Sequence { get; set; }

        public int UsedMiles { get; set; }

        public DateTime? AwardDate { get; set; }

        public DateTime? UsedDate { get; set; }


    }


    public class MemberRedemptionTransactionsUpdateDto : IEntityUpdateDto
    {
        [MaxLength(100)]
        public string CIS { get; set; }
        [MaxLength(50)]

        public string? PartnerId { get; set; }

        public int? CertificateNum { get; set; }

        public int? Sequence { get; set; }

        public int UsedMiles { get; set; }

        public DateTime? AwardDate { get; set; }

        public DateTime? UsedDate { get; set; }

    }
}
