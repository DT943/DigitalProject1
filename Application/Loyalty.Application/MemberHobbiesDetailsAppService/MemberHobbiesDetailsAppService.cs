using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Loyalty.Application.MemberContactPersonsAppService.Dtos;
using Loyalty.Application.MemberContactPersonsAppService.Validations;
using Loyalty.Application.MemberContactPersonsAppService;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Loyalty.Application.MemberHobbiesDetailsAppService.Dto;

namespace Loyalty.Application.MemberHobbiesDetailsAppService
{
    public class MemberHobbiesDetailsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.MemberHobbiesDetails, MemberHobbiesDetailsGetAllDto, MemberHobbiesDetailsGetDto, MemberHobbiesDetailsCreateDto, MemberHobbiesDetailsUpdateDto, SieveModel>, IMemberHobbiesDetailsAppService
    {
        public MemberHobbiesDetailsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, MemberContactPersonsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }
    }
}
