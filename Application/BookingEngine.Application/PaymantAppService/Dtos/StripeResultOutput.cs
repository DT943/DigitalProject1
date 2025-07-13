using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingEngine.Application.PaymantAppService.Dtos
{
    public class StripeResultGetDto
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public string PaymentStatus { get; set; }
        public string Pnr { get; set; }

        public string? CustomerId { get; set; }
        public string? CustomerEmail { get; set; }

        public string? PaymentIntentId { get; set; }
        public string? PaymentMethodId { get; set; }
        public string SystemPaymentState { get; set; }


        public long AmountTotal { get; set; }
        public string? Currency { get; set; }

        public string? Mode { get; set; }
        public string? Status { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string? MetadataJson { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
