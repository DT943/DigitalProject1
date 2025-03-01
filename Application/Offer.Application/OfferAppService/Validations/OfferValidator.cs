using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Application.OfferAppService.Dtos;
namespace Offer.Application.OfferAppService.Validations
{
    public class OfferValidator : AbstractValidator<IValidatableDto>
    {
        private static readonly string[] AllowedTypes = { "FlightOffer", "HolidayOffer", "ChamMilesOffer" };

        public OfferValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as OfferCreateDto).Name)
                    .NotEmpty()
                    .WithMessage("The Name must not be empty.");

                RuleFor(dto => (dto as OfferCreateDto).Type)
                     .Must(type => AllowedTypes.Contains(type))
                     .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as OfferUpdateDto).Name)
                    .NotEmpty()
                    .WithMessage("The Name must not be empty.");

                RuleFor(dto => (dto as OfferUpdateDto).Type)
                    .Must(type => AllowedTypes.Contains(type))
                    .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.");

            });
        }
    }
}
