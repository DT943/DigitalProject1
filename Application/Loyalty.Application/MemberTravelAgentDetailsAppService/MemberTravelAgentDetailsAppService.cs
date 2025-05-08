using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;
using Loyalty.Application.MemberTelephoneDetailsAppService.Validations;
using Loyalty.Application.MemberTelephoneDetailsAppService;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Loyalty.Application.MemberTravelAgentDetailsAppService.Dto;
using Loyalty.Application.MemberTravelAgentDetailsAppService.Validations;

namespace Loyalty.Application.MemberTravelAgentDetailsAppService
{
    public class MemberTravelAgentDetailsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberTravelAgentDetails, MemberTravelAgentDetailsGetAllDto, MemberTravelAgentDetailsGetDto, MemberTravelAgentDetailsCreateDto, MemberTravelAgentDetailsUpdateDto, SieveModel>, IMemberTravelAgentDetailsAppService
    {
        public MemberTravelAgentDetailsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberTravelAgentDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
