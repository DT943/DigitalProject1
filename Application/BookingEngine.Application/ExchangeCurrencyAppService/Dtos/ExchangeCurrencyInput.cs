using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.BasicDto;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.ExchangeCurrencyAppService.Dtos
{
    public class CurrencyCreateDto : IValidatableDto
    {

        [Required]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(5)]
        public string Symbol { get; set; }

    }
    public class ExchangeRateCreateDto: IValidatableDto
    {

        [Required]
        public decimal Rate { get; set; }
        public DateTime UpdatesAt { get; set; } = DateTime.UtcNow;

        public string FromCurrency { get; set; }

        public string ToCurrency { get; set; }


    }
    public class CurrencyUpdateDto : IEntityUpdateDto
    {

        [Required]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(5)]
        public string Symbol { get; set; }


    }
    public class ExchangeRateUpdateDto: IEntityUpdateDto
    {

        [Required]
        public decimal Rate { get; set; }
        public DateTime UpdatesAt { get; set; } = DateTime.UtcNow;

        public string FromCurrency { get; set; }

        public string ToCurrency { get; set; }


    }


}
