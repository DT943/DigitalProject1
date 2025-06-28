using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.AirPortAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.AirPortAppService.Validations
{
    public class AirPortValidator : AbstractValidator<IValidatableDto>
    {

        public AirPortValidator() {


            RuleSet("create", () =>
            {
                When(x => x is AirPortCreateDto, () =>
                {
                    RuleFor(x => ((AirPortCreateDto)x).IATACode)
                        .NotEmpty().WithMessage("IATA Code is required.")
                        .Length(3, 10).WithMessage("IATA Code must be between 3 and 10 characters.");

                    RuleFor(x => ((AirPortCreateDto)x).AirPortTranslations)
                        .NotNull().WithMessage("Translations are required.")
                        .Must(translations => translations != null && translations.Any())
                        .WithMessage("At least one translation is required.");

                    RuleForEach(x => ((AirPortCreateDto)x).AirPortTranslations)
                        .SetValidator(new AirPortTranslationValidator());
                });
            });

            RuleSet("update", () =>
            {
                When(x => x is AirPortUpdateDto, () =>
                {
                    RuleFor(x => ((AirPortUpdateDto)x).IATACode)
                        .NotEmpty().WithMessage("IATA Code is required.")
                        .Length(3, 10).WithMessage("IATA Code must be between 3 and 10 characters.");

                    RuleFor(x => ((AirPortUpdateDto)x).AirPortTranslations)
                        .NotNull().WithMessage("Translations are required.")
                        .Must(translations => translations != null && translations.Any())
                        .WithMessage("At least one translation is required.");

                    RuleForEach(x => ((AirPortUpdateDto)x).AirPortTranslations)
                        .SetValidator(new AirPortTranslationValidator());
                });
            });


        }
    }
}
