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
    public class CurrencyValidator : AbstractValidator<IValidatableDto>
    {
        public CurrencyValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(x => ((CurrencyCreateDto)x).CurrencyCode)
                    .NotEmpty().WithMessage("Currency code is required.")
                    .Length(3).WithMessage("Currency code must be 3 characters.");

                RuleFor(x => ((CurrencyCreateDto)x).Name)
                    .NotEmpty().WithMessage("Currency name is required.")
                    .MaximumLength(50).WithMessage("Currency name must not exceed 50 characters.");

                RuleFor(x => ((CurrencyCreateDto)x).Symbol)
                    .MaximumLength(5).WithMessage("Currency symbol must not exceed 5 characters.");


            });



            RuleSet("update", () =>
            {
                RuleFor(x => ((CurrencyUpdateDto)x).CurrencyCode)
                    .NotEmpty().WithMessage("Currency code is required.")
                    .Length(3).WithMessage("Currency code must be 3 characters.");

                RuleFor(x => ((CurrencyUpdateDto)x).Name)
                    .NotEmpty().WithMessage("Currency name is required.")
                    .MaximumLength(50).WithMessage("Currency name must not exceed 50 characters.");

                RuleFor(x => ((CurrencyUpdateDto)x).Symbol)
                    .MaximumLength(5).WithMessage("Currency symbol must not exceed 5 characters.");

            });


        }

    }
}