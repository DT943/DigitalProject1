using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService.Validations;
using Loyalty.Application.MemberAddressDetailsAppService;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Infrastructure.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Application.BasicDto;
using FluentValidation;
using Loyalty.Application.MemberDemographicsAndProfileAppService;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.Results;

namespace Loyalty.Application.MemberAccrualTransactions
{
    public class MemberAccrualTransactionsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberAccrualTransactions, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsCreateDto, MemberAccrualTransactionsUpdateDto, SieveModel>, IMemberAccrualTransactionsAppService
    {
        LoyaltyDbContext _serviceDbContext;
        IServiceProvider _serviceProvider;
        public MemberAccrualTransactionsAppService(IServiceProvider serviceProvider,LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberAddressDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _serviceDbContext = serviceDbContext;
            _serviceProvider = serviceProvider;

        }


        public override async Task<MemberAccrualTransactionsGetDto> Create(MemberAccrualTransactionsCreateDto create)
        {
            var validationResult = await _validations.ValidateAsync(create, options => options.IncludeRuleSets("create", "default"));
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }


            var result =  await _serviceDbContext.MemberDemographicsAndProfiles.Where(x => x.UserCode == create.CIS).Include(x => x.MemberTierDetails).ThenInclude(x => x.TierDetails).FirstOrDefaultAsync();

            var tierdetails = result.MemberTierDetails.OrderByDescending(x=>x.FulfillDate).FirstOrDefault();
            var tierDetails = tierdetails.TierDetails;
            create.Bonus = (int) (tierDetails.BonusAddedValue * create.Base) + create.Bonus;
            var createdTransaction = await base.Create(create);
            var memberAppService = _serviceProvider.GetRequiredService<IMemberDemographicsAndProfileAppService>();
            await memberAppService.UpgradeUserTier(create.CIS);
            return createdTransaction;
        }

        //FlightTransactionDetails

        public async Task<MemberAccrualTransactionsGetDto> CreateFlightTransactionDetails(MemberAccrualTransactionsCreateDto create)
        {
            var validationResult = await _validations.ValidateAsync(create, options => options.IncludeRuleSets("FlightCreate", "default"));
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var segmentMiles = await _serviceDbContext.SegmentMiles.Where(x=> 
            x.COS.ToLower().Equals(create.FlightClass.ToLower()) &&
            x.BookingClass.ToLower().Equals(create.BookClass.ToLower()) &&
            x.Origin.ToLower().Equals(create.Origin.ToLower()) &&
            x.Destination.ToLower().Equals(create.Destination.ToLower()))
             .FirstOrDefaultAsync();

            if(segmentMiles == null)
                throw new ValidationException(new List<ValidationFailure> { new ValidationFailure("Transaction", $"WrongInformation") });

            create.Base = segmentMiles.Miles;
            create.Bonus = 0;
        
            return await this.Create(create);
        }


        public async Task<MemberAccrualTransactionsGetDto> CreatePaymentTransactionDetails(PaymentDetails create)
        {
            var validationResult = await _validations.ValidateAsync(create, options => options.IncludeRuleSets("FlightCreate", "default"));
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
 
            return await this.Create(new MemberAccrualTransactionsCreateDto
            {
                CIS = create.CIS,
                Base = 0,
                Bonus = create.Amount * 100,
                PaidAmountInUsd = create.Amount,
                Description = "Payment Transaction",
                PartnerCode = "FlyCham"

            });
        }

        public async Task<PaginatedResult<MemberAccrualTransactionsGetDto>> MemberAccrualTransactionsDetails(SieveModel input)
        {
            var userCode = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
            var result = await QueryExcuter(input).Where(x => x.CIS.Equals(userCode)).ToListAsync();
       
            var filterdResultForCount = _processor.Apply(input, result.AsQueryable(), applyPagination: false);
            var filterdResult = _processor.Apply(input, filterdResultForCount);
            var count = filterdResultForCount.Count();

            return new PaginatedResult<MemberAccrualTransactionsGetDto>
            {
                Items = await Task.FromResult(_mapper.Map<List<MemberAccrualTransactionsGetDto>>(filterdResult)),
                TotalCount = count,
                Page = input.Page ?? 1,
                PageSize = input.PageSize ?? count
            };
        }
    }
}
