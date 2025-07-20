using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Validations
{
    public class InquirePNRValidator : AbstractValidator<IValidatableDto>
    {
        public InquirePNRValidator() {

            RuleSet("create", () =>
            {
                RuleFor(x => ((InquirePNRCreateDto)x).LastName)
                    .NotEmpty().WithMessage("LastName is required.")
                    .MaximumLength(50).WithMessage("LastName must not exceed 50 characters.");

                RuleFor(x => ((InquirePNRCreateDto)x).PNR)
                    .NotEmpty().WithMessage("PNR is required.")
                    .Length(6).WithMessage("PNR must be exactly 6 characters.");

            });

            RuleSet("update", () =>
            {
            });

        }
    }
}
