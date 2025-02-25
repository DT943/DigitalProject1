using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using Offer.Application.FlightOfferAppService.Dtos;

namespace Offer.Application.FlightOfferAppService.Validations
{
    public class FlightOfferValidator : AbstractValidator<IValidatableDto>
    {
        public FlightOfferValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as FlightOfferCreateDto).OfferID)
                    .NotEmpty()
                    .WithMessage("The OfferID must not be empty.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as FlightOfferUpdateDto).OfferID)
                    .NotEmpty()
                    .WithMessage("The OfferID must not be empty.");

            });
        }
    }
}
