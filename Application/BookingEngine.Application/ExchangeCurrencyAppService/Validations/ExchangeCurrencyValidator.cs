using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.ExchangeCurrencyAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.ExchangeCurrencyAppService.Validations
{
    public class ExchangeCurrencyValidator : AbstractValidator<IValidatableDto>
    {
        public ExchangeCurrencyValidator()
        {
            RuleSet("create", () =>
            {

                RuleFor(x => ((ExchangeRateCreateDto)x).Rate)
                    .GreaterThan(0).WithMessage("Exchange rate must be greater than zero.");


                RuleFor(x => ((ExchangeRateCreateDto)x).FromCurrency)
                    .NotNull().WithMessage("FromCurrency is required.")
                    .Length(3).WithMessage("Currency code must be 3 characters.");

                RuleFor(x => ((ExchangeRateCreateDto)x).ToCurrency)
                    .NotNull().WithMessage("ToCurrency is required.")
                     .Length(3).WithMessage("Currency code must be 3 characters.");

            });

            

            RuleSet("update", () =>
            {



                RuleFor(x => ((ExchangeRateUpdateDto)x).Rate)
                    .GreaterThan(0).WithMessage("Exchange rate must be greater than zero.");

                RuleFor(x => ((ExchangeRateUpdateDto)x).FromCurrency)
                    .NotNull().WithMessage("FromCurrency is required.").Length(3).WithMessage("Currency code must be 3 characters.");
                

                RuleFor(x => ((ExchangeRateUpdateDto)x).ToCurrency)
                    .NotNull().WithMessage("ToCurrency is required.").Length(3).WithMessage("Currency code must be 3 characters.");


            });


        }

    }

}