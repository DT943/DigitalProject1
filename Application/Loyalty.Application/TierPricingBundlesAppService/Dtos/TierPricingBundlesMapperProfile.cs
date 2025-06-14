using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Loyalty.Application.SegmentMilesAppService.Dto;
using Loyalty.Application.TierDetailsAppService.Dto;

namespace Loyalty.Application.TierPricingBundlesAppService.Dtos
{
    public class TierPricingBundlesMapperProfile : Profile
    {
        public TierPricingBundlesMapperProfile()
        {
            CreateMap<TierPricingBundlesCreateDto, Domain.Models.TierPricingBundles>();
            CreateMap<TierPricingBundlesUpdateDto, Domain.Models.TierPricingBundles>();
            CreateMap<Domain.Models.TierPricingBundles, TierPricingBundlesGetDto>();
            CreateMap<Domain.Models.TierPricingBundles, TierPricingBundlesGetDto>();

        }
    }
}
