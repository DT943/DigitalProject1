using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Data.DbContext;

namespace Offer.Application.FlightOfferAppService.Validations
{
    public class FlightOfferValidator : AbstractValidator<IValidatableDto>
    {

        private static readonly string[] AllowedTypes = { "Normal", "LastMinutesOffer"};

        public FlightOfferValidator(OfferDbContext offerDbContext)
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as FlightOfferCreateDto).OfferID)
                    .NotEmpty()
                    .WithMessage("The OfferID must not be empty.");

                RuleFor(dto => (dto as FlightOfferCreateDto).Type)
                        .Must(type => AllowedTypes.Contains(type))
                        .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.")
                    .MustAsync(async (dto, type, cancellation) =>
                     {
                         var offer = await offerDbContext.Offers.FindAsync((dto as FlightOfferCreateDto).OfferID);
                         return offer != null && offer.Type.Equals("FlightOffer", StringComparison.OrdinalIgnoreCase);
                     })
                    .WithMessage("The provided OfferId must be associated with an offer of type 'FlightOffer'.");


            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as FlightOfferUpdateDto).OfferID)
                    .NotEmpty()
                    .WithMessage("The OfferID must not be empty.");


                RuleFor(dto => (dto as FlightOfferUpdateDto).Type)
                        .Must(type => AllowedTypes.Contains(type))
                        .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.");

                RuleFor(dto => (dto as FlightOfferUpdateDto).Type)
                        .Must(type => AllowedTypes.Contains(type))
                        .WithMessage($"Type must be one of the following: {string.Join(", ", AllowedTypes)}.")
                        .MustAsync(async (dto, type, cancellation) =>
                        {
                            var offer = await offerDbContext.Offers.FindAsync((dto as FlightOfferCreateDto).OfferID);
                            return offer != null && offer.Type.Equals("FlightOffer", StringComparison.OrdinalIgnoreCase);
                        })
                        .WithMessage("The provided OfferId must be associated with an offer of type 'FlightOffer'.");   

            });
        }
    }
}
