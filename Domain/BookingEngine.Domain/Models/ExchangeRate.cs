using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Domain.Models;

namespace BookingEngine.Domain.Models
{
    public class ExchangeRate : BasicEntityWithAuditAndFakeDelete
    {
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Rate { get; set; }

        public DateTime UpdatesAt { get; set; }

        public string FromCurrency { get; set; }

        public string ToCurrency { get; set; }
    }

}
