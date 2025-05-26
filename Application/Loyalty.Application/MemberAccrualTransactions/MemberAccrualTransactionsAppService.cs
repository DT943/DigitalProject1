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

namespace Loyalty.Application.MemberAccrualTransactions
{
    public class MemberAccrualTransactionsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberAccrualTransactions, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsCreateDto, MemberAccrualTransactionsUpdateDto, SieveModel>, IMemberAccrualTransactionsAppService
    {
        public MemberAccrualTransactionsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberAddressDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }


        public async Task<ActionResult<MemberAccrualTransactionsGetDto>> MemberAccrualTransactionsDetails()
        {
            var userCode = _httpContextAccessor.HttpContext?.User.FindFirst("userCode")?.Value;
            var result = await QueryExcuter(null).FirstOrDefaultAsync(x => x.CIS.Equals(userCode)) ??
                throw new EntityNotFoundException(typeof(Domain.Models.MemberAccrualTransactions).Name, "User Code", userCode.ToString() ?? "");
            return await Task.FromResult(_mapper.Map<MemberAccrualTransactionsGetDto>(result));
        }
    }
}
