using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Application;
using Loyalty.Application.SegmentMilesAppService.Dto;
using Loyalty.Application.SegmentMilesAppService.Validations;
using Loyalty.Application.SegmentMilesAppService;
using Loyalty.Data.DbContext;
using Microsoft.AspNetCore.Http;
using Sieve.Models;
using Sieve.Services;
using Loyalty.Application.TierDetailsAppService.Dto;
using Loyalty.Application.TierDetailsAppService.Validations;
using Infrastructure.Application.Exceptions;
using Loyalty.Application.MemberTierDetailsAppService.Dto;
using Loyalty.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Loyalty.Application.TierDetailsAppService
{
    public class TierDetailsAppService : BaseAppService<LoyaltyDbContext, Domain.Models.TierDetails, TierDetailsGetDto, TierDetailsGetDto, TierDetailsCreateDto, TierDetailsUpdateDto, SieveModel>, ITierDetailsAppService
    {
        public TierDetailsAppService(LoyaltyDbContext serviceDbContext, IMapper mapper, ISieveProcessor processor, TierDetailsValidator validations, IHttpContextAccessor httpContextAccessor) : base(serviceDbContext, mapper, processor, validations, httpContextAccessor)
        {
        }


        public async Task<TierDetailsGetDto> GetByName(string name)
        {
            var result = await QueryExcuter(null).FirstOrDefaultAsync(x => x.Name.Equals(name)) ??
            throw new EntityNotFoundException(typeof(MemberTierDetails).Name, name ?? "");

            return await Task.FromResult(_mapper.Map<TierDetailsGetDto>(result));
        }
    }
}