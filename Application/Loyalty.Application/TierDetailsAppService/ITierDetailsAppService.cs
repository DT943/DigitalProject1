using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.SegmentMilesAppService.Dto;
using Loyalty.Application.TierDetailsAppService.Dto;
using Sieve.Models;

namespace Loyalty.Application.TierDetailsAppService
{
    public interface ITierDetailsAppService : IBaseAppService<TierDetailsGetDto, TierDetailsGetDto, TierDetailsCreateDto, TierDetailsUpdateDto, SieveModel>
    {
          Task<TierDetailsGetDto> GetByName(string name);
    }
}