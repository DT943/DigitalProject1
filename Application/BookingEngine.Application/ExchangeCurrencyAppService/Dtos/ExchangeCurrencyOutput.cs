using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Domain.Models;
using Infrastructure.Domain.Models;

namespace BookingEngine.Application.ExchangeCurrencyAppService.Dtos
{
    public class CurrencyGetDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(5)]
        public string Symbol { get; set; }



    }

    public class ExchangeRateGetDto
    {
        public int Id { get; set; }

        [Required]
        public decimal Rate { get; set; }
        public DateTime UpdatesAt { get; set; }

        public string FromCurrency { get; set; }

        public string ToCurrency { get; set; }



    }
}




