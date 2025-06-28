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
    public class AirPortTranslationValidator : AbstractValidator<IValidatableDto>
    {
        public AirPortTranslationValidator()
        {
            RuleSet("create", () =>
            {
                When(x => x is AirPortTranslationCreateDto, () =>
                {
                    RuleFor(x => ((AirPortTranslationCreateDto)x).LanguageCode)
                        .NotEmpty().WithMessage("Language code is required.");

                    RuleFor(x => ((AirPortTranslationCreateDto)x).City)
                        .NotEmpty().WithMessage("City is required.")
                        .MaximumLength(100);

                    RuleFor(x => ((AirPortTranslationCreateDto)x).Country)
                        .NotEmpty().WithMessage("Country is required.")
                        .MaximumLength(100);

                    RuleFor(x => ((AirPortTranslationCreateDto)x).AirPortName)
                        .NotEmpty().WithMessage("Airport name is required.")
                        .MaximumLength(150);
                });
            });

            RuleSet("update", () =>
            {
                When(x => x is AirPortTranslationUpdateDto, () =>
                {
                    RuleFor(x => ((AirPortTranslationUpdateDto)x).LanguageCode)
                        .NotEmpty().WithMessage("Language code is required.");

                    RuleFor(x => ((AirPortTranslationUpdateDto)x).City)
                        .NotEmpty().WithMessage("City is required.")
                        .MaximumLength(100);

                    RuleFor(x => ((AirPortTranslationUpdateDto)x).Country)
                        .NotEmpty().WithMessage("Country is required.")
                        .MaximumLength(100);

                    RuleFor(x => ((AirPortTranslationUpdateDto)x).AirPortName)
                        .NotEmpty().WithMessage("Airport name is required.")
                        .MaximumLength(150);
                });
            });
        }
    }
}
