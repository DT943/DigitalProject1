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

namespace Loyalty.Application.MemberAccrualTransactions
{
    public class MemberAccrualTransactionsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberAccrualTransactions, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsCreateDto, MemberAccrualTransactionsUpdateDto, SieveModel>, IMemberAccrualTransactionsAppService
    {
        public MemberAccrualTransactionsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberAddressDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
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
