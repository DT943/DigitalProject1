using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class StripeResult : BasicEntity
    {
        public string SessionId { get; set; }
        public string PaymentStatus { get; set; } 
        public string Pnr { get; set; } 

        public string? CustomerId { get; set; } 
        public string? CustomerEmail { get; set; }

        public string? PaymentIntentId { get; set; }
        public string? PaymentMethodId { get; set; }

        public long AmountTotal { get; set; } 
        public string? Currency { get; set; } 

        public string? Mode { get; set; } 
        public string? Status { get; set; }
        public string? SystemPaymentState { get; set; }

        public DateTime? ExpiresAt { get; set; } 
        public string? MetadataJson { get; set; }

        public DateTime CreationTime { get; set; } 

    }

}
