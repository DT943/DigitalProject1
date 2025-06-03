using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Loyalty.Application.MemberPreferenceDetailsAppService.Dto;
using Loyalty.Application.MemberPreferenceDetailsAppService.Validations;
using Loyalty.Application.MemberPreferenceDetailsAppService;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Loyalty.Application.MemberRedemptionTransactions.Dto;
using Loyalty.Application.MemberRedemptionTransactions.Validations;

namespace Loyalty.Application.MemberRedemptionTransactions
{
    public class MemberRedemptionTransactionsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberRedemptionTransactions, MemberRedemptionTransactionsGetDto, MemberRedemptionTransactionsGetDto, MemberRedemptionTransactionsCreateDto, MemberRedemptionTransactionsUpdateDto, SieveModel>, IMemberRedemptionTransactionsAppService
    {
        public MemberRedemptionTransactionsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberRedemptionTransactionsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
