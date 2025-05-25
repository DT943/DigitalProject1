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

namespace Loyalty.Application.MemberAccrualTransactions
{
    public class MemberAccrualTransactionsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberAccrualTransactions, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsCreateDto, MemberAccrualTransactionsUpdateDto, SieveModel>, IMemberAccrualTransactionsAppService
    {
        public MemberAccrualTransactionsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberAddressDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
