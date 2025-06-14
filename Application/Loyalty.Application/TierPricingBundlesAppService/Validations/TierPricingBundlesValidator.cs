using FluentValidation;
using Infrastructure.Application.Validations;

using Loyalty.Application.TierPricingBundlesAppService.Dtos;
using Loyalty.Data.DbContext;

namespace Loyalty.Application.TierPricingBundlesAppService.Validations
{
    public class TierPricingBundlesValidator : AbstractValidator<IValidatableDto>
    {
        public TierPricingBundlesValidator(LoyaltyDbContext loyaltyDbContext)
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as TierPricingBundlesCreateDto).PriceInUsd)
                    .NotEmpty()
                    .WithMessage("Price In Usd is required")
                    .GreaterThan(0)
                    .WithMessage("Price In Usd must be positive");

                RuleFor(dto => (dto as TierPricingBundlesCreateDto).NumberOfDays)
                    .NotEmpty()
                    .WithMessage("Number Of Days is required")
                    .GreaterThan(0)
                    .WithMessage("Price in Usd should be Greater than 0"); 
            });

            RuleSet("update", () =>
            {
                RuleFor(dto => (dto as TierPricingBundlesUpdateDto).PriceInUsd)
                    .NotEmpty()
                    .WithMessage("Price In Usd is required")
                    .GreaterThan(0)
                    .WithMessage("Price In Usd must be positive");

                RuleFor(dto => (dto as TierPricingBundlesUpdateDto).NumberOfDays)
                    .NotEmpty()
                    .WithMessage("Number Of Days is required")
                    .GreaterThan(0)
                    .WithMessage("Price in Usd should be Greater than 0");
            });
        }
    }
}
