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
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;
using Loyalty.Application.MemberTelephoneDetailsAppService.Validations;

namespace Loyalty.Application.MemberTelephoneDetailsAppService
{
    public class MemberTelephoneDetailsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberTelephoneDetails, MemberTelephoneDetailsGetAllDto, MemberTelephoneDetailsGetDto, MemberTelephoneDetailsCreateDto, MemberTelephoneDetailsUpdateDto, SieveModel>, IMemberTelephoneDetailsAppService
    {
        public MemberTelephoneDetailsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberTelephoneDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
