using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.PassengerInfo.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.PassengerInfo.Validations
{
    public class TelephoneValidator : AbstractValidator<TelephoneCreateDto>
    {

        public TelephoneValidator()
        {

            RuleSet("create", () =>
            {
                When(x => x is TelephoneCreateDto, () =>
                {
                    /*
                    RuleFor(x => ((TelephoneCreateDto)x).AreaCityCode)
                        .MaximumLength(10).WithMessage("Area/City code cannot exceed 10 characters.");

                    RuleFor(x => ((TelephoneCreateDto)x).CountryAccessCode)
                        .MaximumLength(5).WithMessage("Country access code cannot exceed 5 characters.");

                    RuleFor(x => ((TelephoneCreateDto)x).PhoneNumber)
                        .MaximumLength(15).WithMessage("Phone number cannot exceed 15 characters.");
                    */
                });
            });

            RuleSet("update", () =>
            {
                When(x => x is TelephoneUpdateDto, () =>
                {

                });
            });

        }
    }
}
