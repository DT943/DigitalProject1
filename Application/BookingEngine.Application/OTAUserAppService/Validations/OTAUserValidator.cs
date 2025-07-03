using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.AirPortAppService.Dtos;
using BookingEngine.Application.OTAUserAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.OTAUserAppService.Validations
{
    public class OTAUserValidator : AbstractValidator<IValidatableDto>
    {
        public OTAUserValidator()
        {
            RuleSet("create", () =>
            {
                When(x => x is OTAUserCreateDto, () =>
                {
                    RuleFor(x => ((OTAUserCreateDto)x).POS)
                        .NotEmpty().WithMessage("POS is required.");

                    RuleFor(x => ((OTAUserCreateDto)x).UserName)
                        .NotEmpty().WithMessage("UserName is required.")
                        .MaximumLength(100);

                    RuleFor(x => ((OTAUserCreateDto)x).Password)
                        .NotEmpty().WithMessage("Password is required.")
                        .MaximumLength(100);

                });
            });

            RuleSet("update", () =>
            {
                RuleFor(x => ((OTAUserUpdateDto)x).POS)
                    .NotEmpty().WithMessage("POS is required.");

                RuleFor(x => ((OTAUserUpdateDto)x).UserName)
                    .NotEmpty().WithMessage("UserName is required.")
                    .MaximumLength(100);

                RuleFor(x => ((OTAUserUpdateDto)x).Password)
                    .NotEmpty().WithMessage("Password is required.")
                    .MaximumLength(100);
            });
        }

    }
}
