using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using Offer.Application.OfferAppService.Dtos;
namespace Offer.Application.OfferAppService.Validations
{
    public class OfferValidator : AbstractValidator<IValidatableDto>
    {
        public OfferValidator()
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as OfferCreateDto).Name)
                    .NotEmpty()
                    .WithMessage("The Name must not be empty.");
            });

            RuleSet("update", () =>
            {

                RuleFor(dto => (dto as OfferUpdateDto).Name)
                    .NotEmpty()
                    .WithMessage("The Name must not be empty.");

            });
        }
    }
}
