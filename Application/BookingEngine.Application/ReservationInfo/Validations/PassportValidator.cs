using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PassengerInfo.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;
using Microsoft.AspNetCore.Identity;

namespace BookingEngine.Application.PassengerInfo.Validations
{
    public class PassportValidator : AbstractValidator<IValidatableDto>
    {
        public PassportValidator()
        {
            RuleSet("create", () =>
            {
                When(x => x is PassportCreateDto, () =>
                {
                });
            });

            RuleSet("update", () =>
            {
                When(x => x is PassportUpdateDto, () =>
                {
                    RuleFor(x => ((PassportUpdateDto)x).DocID)
                        .NotEmpty().WithMessage("Document ID is required.")
                        .MaximumLength(20);

                    RuleFor(x => ((PassportUpdateDto)x).ExpireDate)
                        .GreaterThan(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Passport expiry date must be in the future.");
                });
            });

        }
    }
}