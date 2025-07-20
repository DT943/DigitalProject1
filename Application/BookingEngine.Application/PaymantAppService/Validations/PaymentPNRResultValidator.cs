using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.PaymantAppService.Validations
{
    public class PaymentPNRResultValidator : AbstractValidator<IValidatableDto>
    {
        public PaymentPNRResultValidator()
        {

            RuleSet("create", () =>
            {
            });

            RuleSet("update", () =>
            {
            });

        }

    }
}
