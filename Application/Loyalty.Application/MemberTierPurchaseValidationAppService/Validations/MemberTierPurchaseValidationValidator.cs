    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Infrastructure.Application.Validations;
using Loyalty.Application.MemberTierPurchaseValidationAppService.Dto;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Loyalty.Application.MemberTierPurchaseValidationAppService.Validations
{
    public class MemberTierPurchaseValidationValidator : AbstractValidator<IValidatableDto>
    {
        public MemberTierPurchaseValidationValidator(LoyaltyDbContext loyaltyRepository)
        {
            RuleSet("create", () =>
            {
                RuleFor(dto => (dto as MemberTierPurchaseValidationCreateDto).CIS)
                    .NotEmpty()
                    .WithMessage("CIS Cannot be empty.").
                     Must((cis) => loyaltyRepository.MemberDemographicsAndProfiles.Any(x => x.UserCode == cis))
                    .WithMessage("The User Not Found");

                RuleFor(dto => (dto as MemberTierPurchaseValidationCreateDto).NumberOfDays)
                    .NotEmpty()
                    .WithMessage("The Description cannot be empty.")
                    .Must((dto) => loyaltyRepository.TierPricingBundles.Any(x => x.NumberOfDays == dto))
                    .WithMessage("Can't Find The Related Number");


                RuleFor(dto => (dto as MemberTierPurchaseValidationCreateDto))
                    .MustAsync(async (dto, cancellationToken) =>
                    {
                        var result = await loyaltyRepository.MemberDemographicsAndProfiles
                            .Where(x => x.UserCode == dto.CIS)
                            .Include(x => x.MemberTierDetails)
                            .ThenInclude(x => x.TierDetails)
                            .FirstOrDefaultAsync(cancellationToken);

                        var tierDetails = result?.MemberTierDetails?
                            .OrderByDescending(x => x.FulfillDate)
                            .FirstOrDefault();

                        return tierDetails.EndDate != null && tierDetails.EndDate != DateTime.MaxValue;
                    })
                    .WithMessage("End Date Cannot be Empty and Cannot be Null");

                /*
                 * 
                 * 
            var numberofDate = await _serviceDbContext.TierPricingBundles.Where(x => x.NumberOfDays == create.NumberOfDays).FirstOrDefaultAsync();
            tierdetails.EndDate = tierdetails.EndDate.Value.AddDays(create.NumberOfDays);
                 * */
            });

            RuleSet("update", () =>
            {
            });
        }
    }
}
