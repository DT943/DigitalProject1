using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Loyalty.Application.MemberContactPersonsAppService.Validations;
using Loyalty.Application.MemberHobbiesDetailsAppService.Dto;
using Loyalty.Application.MemberHobbiesDetailsAppService;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Loyalty.Application.MemberEducationalDetailsAppService.Dto;
using Loyalty.Application.MemberEducationalDetailsAppService.Validations;

namespace Loyalty.Application.MemberEducationalDetailsAppService
{
    public class MemberEducationalDetailsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberEducationalDetails, MemberEducationalDetailsGetAllDto, MemberEducationalDetailsGetDto, MemberEducationalDetailsCreateDto, MemberEducationalDetailsUpdateDto, SieveModel>, IMemberEducationalDetailsAppService
    {
        public MemberEducationalDetailsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberEducationalDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
