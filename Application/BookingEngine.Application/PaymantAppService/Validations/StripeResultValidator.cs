using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PaymantAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.PaymantAppService.Validations
{
    public class StripeResultValidator : AbstractValidator<IValidatableDto>
    {
        public StripeResultValidator()
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
