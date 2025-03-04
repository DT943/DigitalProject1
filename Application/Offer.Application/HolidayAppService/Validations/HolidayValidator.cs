using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using Offer.Application.HolidayAppService.Dtos;
using Offer.Data.DbContext;

namespace Offer.Application.HolidayAppService.Validations
{
    public class HolidayValidator : AbstractValidator<IValidatableDto>
    {


        public HolidayValidator(OfferDbContext offerDbContext)
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as HolidayCreateDto).OfferID)
                    .NotEmpty()
                    .WithMessage("The OfferID must not be empty.");

            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as HolidayUpdateDto).OfferID)
                    .NotEmpty()
                    .WithMessage("The OfferID must not be empty.");


            });
        }
    }
}
