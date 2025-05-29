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

namespace Loyalty.Application.MemberAccrualTransactions
{
    public class MemberAccrualTransactionsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberAccrualTransactions, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsCreateDto, MemberAccrualTransactionsUpdateDto, SieveModel>, IMemberAccrualTransactionsAppService
    {
        LoyaltyDbContext _serviceDbContext;
        public MemberAccrualTransactionsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberAddressDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
            _serviceDbContext = serviceDbContext;
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
            return await base.Create(create);
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
