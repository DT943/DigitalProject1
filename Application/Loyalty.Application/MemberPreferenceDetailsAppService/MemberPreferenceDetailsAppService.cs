using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Validations;
using Loyalty.Application.MemberDemographicsAndProfileAppService;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Loyalty.Application.MemberPreferenceDetailsAppService.Dto;
using Loyalty.Application.MemberPreferenceDetailsAppService.Validations;

namespace Loyalty.Application.MemberPreferenceDetailsAppService
{
    public class MemberPreferenceDetailsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberPreferenceDetails, MemberPreferenceDetailsGetAllDto, MemberPreferenceDetailsGetDto, MemberPreferenceDetailsCreateDto, MemberPreferenceDetailsUpdateDto, SieveModel>, IMemberPreferenceDetailsAppService
    {
        public MemberPreferenceDetailsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberPreferenceDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
