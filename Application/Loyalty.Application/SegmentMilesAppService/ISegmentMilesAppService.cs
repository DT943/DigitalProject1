using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Loyalty.Application.MemberTravelAgentDetailsAppService.Dto;
using Loyalty.Application.SegmentMilesAppService.Dto;
using Sieve.Models;

namespace Loyalty.Application.SegmentMilesAppService
{
    public interface ISegmentMilesAppService : IBaseAppService<SegmentMilesGetDto, SegmentMilesGetDto, SegmentMilesCreateDto, SegmentMilesUpdateDto, SieveModel>
    {
    }
}