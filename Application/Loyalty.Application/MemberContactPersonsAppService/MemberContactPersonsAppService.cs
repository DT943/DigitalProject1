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
using Loyalty.Application.MemberContactPersonsAppService.Dtos;
using Loyalty.Application.MemberContactPersonsAppService.Validations;

namespace Loyalty.Application.MemberContactPersonsAppService
{
    public class MemberContactPersonsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberContactPersons, MemberContactPersonsGetAllDto, MemberContactPersonsGetDto, MemberContactPersonsCreateDto, MemberContactPersonsUpdateDto, SieveModel>, IMemberContactPersonsAppService
    {
        public MemberContactPersonsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberContactPersonsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
