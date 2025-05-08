using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Loyalty.Application.MemberDemographicsAndProfileAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberHobbiesDetailsAppService;
using Loyalty.Application.MemberHobbiesDetailsAppService.Dto;

namespace Loyalty.Host.Controllers
{
    public class MemberHobbiesDetailsController : BaseController<IMemberHobbiesDetailsAppService, Domain.Models.MemberHobbiesDetails, MemberHobbiesDetailsGetAllDto, MemberHobbiesDetailsGetDto, MemberHobbiesDetailsCreateDto, MemberHobbiesDetailsUpdateDto, SieveModel>
    {
        public MemberHobbiesDetailsController(IMemberHobbiesDetailsAppService appService) : base(appService, Servics.Loyalty)
        {
        }
    }
}
