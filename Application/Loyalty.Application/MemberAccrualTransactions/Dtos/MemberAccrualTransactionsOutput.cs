using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.Application.MemberAccrualTransactions.Dtos
{
    public class MemberAccrualTransactionsGetDto
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string CIS { get; set; }
        [MaxLength(100)]
        public string PartnerCode { get; set; }
        public DateTime LoadDate { get; set; }
        public DateOnly TravelDate { get; set; }
        public string Description { get; set; }
        public int? Base { get; set; }
        public int? Bonus { get; set; }
        public DateTime? ActDate { get; set; }
        public float? ActValue { get; set; }
        public int? ReversalId { get; set; }
        public int? TierId { get; set; }
        public string? LoadType { get; set; }
        public DateTime? STMTDate { get; set; }
        public string? ActInvNumber { get; set; }
        public DateTime? INVDate { get; set; }
        public int? STMTNo { get; set; }
        public int? INVNo { get; set; }


        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string? FlightClass { get; set; }
        public string? BookClass { get; set; }
        public string? FlightNumber { get; set; }
        public string? TicketNumber { get; set; }
        public int? CouponNumber { get; set; }
        public string? CarrierCode { get; set; }

        public string? PNR { get; set; }
        public int? PaidAmountInUsd { get; set; }

    }
}
