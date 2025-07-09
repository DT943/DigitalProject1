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
    public class POSTranslationValidator : AbstractValidator<IValidatableDto>
    {
        public POSTranslationValidator()
        {
            RuleSet("create", () =>
            {
                When(x => x is POSTranslationCreateDto, () =>
                {
                    RuleFor(x => ((POSTranslationCreateDto)x).LanguageCode)
                        .NotEmpty().WithMessage("Language code is required.");

                    RuleFor(x => ((POSTranslationCreateDto)x).Name)
                        .NotEmpty().WithMessage("Name is required.")
                        .MaximumLength(100);

                });
            });

            RuleSet("update", () =>
            {
                When(x => x is POSTranslationUpdateDto, () =>
                {
                    RuleFor(x => ((POSTranslationUpdateDto)x).LanguageCode)
                        .NotEmpty().WithMessage("Language code is required.");

                    RuleFor(x => ((POSTranslationUpdateDto)x).Name)
                        .NotEmpty().WithMessage("Name is required.")
                        .MaximumLength(100);

                });
            });
        }
    }
}
