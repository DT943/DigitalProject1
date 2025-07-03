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
    public class PassengerInfoValidator : AbstractValidator<IValidatableDto>
    {
        public PassengerInfoValidator()
        {
            RuleSet("create", () =>
            {
                When(x => x is PassengerInfoCreateDto, () =>
                {

                    RuleFor(x => ((PassengerInfoCreateDto)x).Type)
                        .NotEmpty().WithMessage("Type is required.")
                        .MaximumLength(10);

                    RuleFor(x => ((PassengerInfoCreateDto)x).GivenName)
                        .NotEmpty().WithMessage("Given name is required.")
                        .MaximumLength(100);

                    RuleFor(x => ((PassengerInfoCreateDto)x).Surname)
                        .NotEmpty().WithMessage("Surname is required.")
                        .MaximumLength(100);

                    RuleFor(x => ((PassengerInfoCreateDto)x).BirthDate)
                        .LessThan(DateTime.Today).WithMessage("Birth date must be in the past.");

                    RuleFor(x => ((PassengerInfoCreateDto)x).NameTitle)
                        .NotEmpty().WithMessage("Name title is required.")
                        .MaximumLength(10);

                    RuleFor(x => ((PassengerInfoCreateDto)x).Telephone)
                        .SetValidator(new TelephoneValidator());

                    RuleFor(x => ((PassengerInfoCreateDto)x).Passport)
                        .SetValidator(new PassportValidator());
                });
            });

            RuleSet("update", () =>
            {
                When(x => x is PassengerInfoUpdateDto, () =>
                {

                    RuleFor(x => ((PassengerInfoUpdateDto)x).Type)
                        .NotEmpty().WithMessage("Type is required.")
                        .MaximumLength(10);

                    RuleFor(x => ((PassengerInfoUpdateDto)x).GivenName)
                        .NotEmpty().WithMessage("Given name is required.")
                        .MaximumLength(100);

                    RuleFor(x => ((PassengerInfoUpdateDto)x).Surname)
                        .NotEmpty().WithMessage("Surname is required.")
                        .MaximumLength(100);

                    RuleFor(x => ((PassengerInfoUpdateDto)x).BirthDate)
                        .LessThan(DateTime.Today).WithMessage("Birth date must be in the past.");

                    RuleFor(x => ((PassengerInfoUpdateDto)x).NameTitle)
                        .NotEmpty().WithMessage("Name title is required.")
                        .MaximumLength(10);

                    RuleFor(x => ((PassengerInfoUpdateDto)x).Telephone)
                        .SetValidator(new TelephoneValidator());

                    RuleFor(x => ((PassengerInfoUpdateDto)x).Passport)
                        .SetValidator(new PassportValidator());
                });
            });


        }
    }

}
