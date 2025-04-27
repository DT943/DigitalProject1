using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService.Validations;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;

namespace Loyalty.Application.MemberAddressDetailsAppService
{
    public class MemberAddressDetailsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberAddressDetails, MemberAddressDetailsGetAllDto, MemberAddressDetailsGetDto, MemberAddressDetailsCreateDto, MemberAddressDetailsUpdateDto, SieveModel>, IMemberAddressDetailsAppService
    {
        public MemberAddressDetailsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberAddressDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
