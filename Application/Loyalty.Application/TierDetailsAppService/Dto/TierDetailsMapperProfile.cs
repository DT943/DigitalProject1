using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.SegmentMilesAppService.Dto;

namespace Loyalty.Application.TierDetailsAppService.Dto
{
    public class TierDetailsMapperProfile : Profile
    {
        public TierDetailsMapperProfile()
        {
            CreateMap<TierDetailsCreateDto, Domain.Models.TierDetails>();
            CreateMap<TierDetailsUpdateDto, Domain.Models.TierDetails>();
            CreateMap<Domain.Models.TierDetails, TierDetailsGetDto>();
            CreateMap<Domain.Models.TierDetails, SegmentMilesGetDto>();

        }
    }
}
