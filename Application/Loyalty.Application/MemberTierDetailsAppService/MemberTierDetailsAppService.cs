using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Infrastructure.Application.Exceptions;
using Loyalty.Application.MemberTierDetailsAppService.Dto;
using Loyalty.Application.MemberTierDetailsAppService.Validations;
using Loyalty.Data.DbContext;
using Loyalty.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Loyalty.Application.MemberTierDetailsAppService
{
    public class MemberTierDetailsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberTierDetails, MemberTierDetailsGetDto, MemberTierDetailsGetDto, MemberTierDetailsCreateDto, MemberTierDetailsUpdateDto, SieveModel>, IMemberTierDetailsAppService
    {
        public MemberTierDetailsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberTierDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
