using AutoMapper;
using FluentValidation;
using Infrastructure.Application;
using Loyalty.Application.MemberTierPurchaseValidationAppService.Dto;
using Loyalty.Application.MemberTierPurchaseValidationAppService.Validations;
using Loyalty.Application.TierDetailsAppService.Validations;
using Loyalty.Data.DbContext;
using Loyalty.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Loyalty.Application.MemberTierPurchaseValidationAppService
{
    public class MemberTierPurchaseValidationAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberTierPurchaseValidation, MemberTierPurchaseValidationGetDto, MemberTierPurchaseValidationGetDto, MemberTierPurchaseValidationCreateDto, MemberTierPurchaseValidationUpdateDto, SieveModel>, IMemberTierPurchaseValidationAppService
    {
        LoyaltyDbContext _serviceDbContext;
        public MemberTierPurchaseValidationAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberTierPurchaseValidationValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _serviceDbContext = serviceDbContext;
        }

        public override async Task<MemberTierPurchaseValidationGetDto> Create(MemberTierPurchaseValidationCreateDto create)
        {
            var validationResult = await _validations.ValidateAsync(create, options => options.IncludeRuleSets("create", "default"));
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var result = await _serviceDbContext.MemberDemographicsAndProfiles.Where(x => x.UserCode == create.CIS).Include(x => x.MemberTierDetails).ThenInclude(x => x.TierDetails).FirstOrDefaultAsync();
            var tierdetails = result.MemberTierDetails.OrderByDescending(x => x.FulfillDate).FirstOrDefault();

            var numberofDate = await _serviceDbContext.TierPricingBundles.Where(x => x.NumberOfDays == create.NumberOfDays).FirstOrDefaultAsync();
            tierdetails.EndDate = tierdetails.EndDate.Value.AddDays(create.NumberOfDays);

            create.ExtendedValidationDate = (DateTime)tierdetails.EndDate;
            create.AmountInUsd = numberofDate.PriceInUsd;
            create.MemberTierDetails = tierdetails.Id;
            return await base.Create(create);
        }
    }
}