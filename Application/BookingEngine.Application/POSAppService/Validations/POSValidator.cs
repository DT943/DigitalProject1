using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.POSAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.POSAppService.Validations
{
    public class POSValidator : AbstractValidator<IValidatableDto>
    {

        public POSValidator()
        {


            RuleSet("create", () =>
            {
                When(x => x is POSCreateDto, () =>
                {
                    RuleFor(x => ((POSCreateDto)x).POSCode)
                        .NotEmpty().WithMessage("POS Code is required.")
                        .Length(1, 10).WithMessage("IATA Code must be between 1 and 10 characters.");

                    RuleFor(x => ((POSCreateDto)x).POSTranslations)
                        .NotNull().WithMessage("Translations are required.")
                        .Must(translations => translations != null && translations.Any())
                        .WithMessage("At least one translation is required.");

                    RuleForEach(x => ((POSCreateDto)x).POSTranslations)
                        .SetValidator(new POSTranslationValidator());
                });
            });

            RuleSet("update", () =>
            {
                When(x => x is POSUpdateDto, () =>
                {
                    RuleFor(x => ((POSUpdateDto)x).POSCode)
                        .NotEmpty().WithMessage("POS Code is required.")
                        .Length(1, 10).WithMessage("POS Code must be between 1 and 10 characters.");

                    RuleFor(x => ((POSUpdateDto)x).POSTranslations)
                        .NotNull().WithMessage("Translations are required.")
                        .Must(translations => translations != null && translations.Any())
                        .WithMessage("At least one translation is required.");

                    RuleForEach(x => ((POSUpdateDto)x).POSTranslations)
                        .SetValidator(new POSTranslationValidator());
                });
            });


        }
    }
}
