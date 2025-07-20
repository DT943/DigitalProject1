using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.AmenitiesAppService.Dtos;
using FluentValidation;
using Infrastructure.Application.Validations;

namespace BookingEngine.Application.AmenitiesAppService.Validations
{
    public class AmenitiesValidator : AbstractValidator<IValidatableDto>
    {

        public AmenitiesValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(x => ((AmenityCreateDto)x).Name)
                    .NotEmpty().WithMessage("Name is required when creating.")
                    .MaximumLength(100).WithMessage("Name must be at most 100 characters.");


            });

            RuleSet("update", () =>
            {
                RuleFor(x => ((AmenityUpdateDto)x).Name)
                    .NotEmpty().WithMessage("Name is required when creating.")
                    .MaximumLength(100).WithMessage("Name must be at most 100 characters.");


            });
        }
    }
}
