using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Loyalty.Domain.Models;

namespace Loyalty.Application.MemberRedemptionTransactions.Dto
{
    public class MemberRedemptionTransactionsGetDto
    {
        public int Id { get; set; }


        [MaxLength(100)]
        public string CIS { get; set; }
        [MaxLength(50)]

        public string? PartnerId { get; set; }

        public int? CertificateNum { get; set; }

        public int? Sequence { get; set; }

        public int UsedMiles { get; set; }

        public DateTime? AwardDate { get; set; }

        public DateTime? UsedDate { get; set; }

        [MaxLength(5)]
        public string? FlightClass { get; set; }

        [MaxLength(5)]
        public string? Origin { get; set; }

        [MaxLength(5)]
        public string? Destination { get; set; }

        public ICollection<MemberTransactionRedemptionDetailsGetDto> MemberTransactionRedemptionDetails { get; set; }
    }

    public class MemberTransactionRedemptionDetailsGetDto
    {
        public int Id { get; set; }

        public DateTime RedemptionDate { get; set; } = DateTime.Now;

        public int RedemptionValue { get; set; }

        [ForeignKey(nameof(TransactionId))]
        public MemberAccrualTransactionsGetDto Transaction { get; set; } 
        public int TransactionId { get; set; }

        public int RedemptionId { get; set; }
    }
}
