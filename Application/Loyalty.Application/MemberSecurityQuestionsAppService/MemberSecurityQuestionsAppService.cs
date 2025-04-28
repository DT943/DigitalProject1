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
using Loyalty.Application.MemberSecurityQuestionsAppService.Dto;

namespace Loyalty.Application.MemberSecurityQuestionsAppService
{
    public class MemberSecurityQuestionsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberSecurityQuestions, MemberSecurityQuestionsGetAllDto, MemberSecurityQuestionsGetDto, MemberSecurityQuestionsCreateDto, MemberSecurityQuestionsUpdateDto, SieveModel>, IMemberSecurityQuestionsAppService
    {
        public MemberSecurityQuestionsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberPreferenceDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
