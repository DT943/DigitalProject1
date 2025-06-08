using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.SegmentMilesAppService.Dto;
using Loyalty.Application.SegmentMilesRedemption.Dto;
using Sieve.Models;

namespace Loyalty.Application.SegmentMilesRedemption
{
    public interface ISegmentMilesRedemptionAppService : IBaseAppService<SegmentMilesRedemptionGetDto, SegmentMilesRedemptionGetDto, SegmentMilesRedemptionCreateDto, SegmentMilesRedemptionUpdateDto, SieveModel>
    {
    }
}