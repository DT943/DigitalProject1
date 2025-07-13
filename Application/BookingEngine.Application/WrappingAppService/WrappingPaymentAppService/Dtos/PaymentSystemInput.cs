using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.WrappingAppService.WrappingPaymentAppService.Dtos
{
    public class PaymentSystemCreateDto : IValidatableDto
    {

        public string TransactionIdentifier { get; set; }

        public string PNR { get; set; }

        public long Balance { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string CompanyName { get; set; }

    }
}
