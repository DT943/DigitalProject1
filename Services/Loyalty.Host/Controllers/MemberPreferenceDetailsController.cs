using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Loyalty.Application.MemberDemographicsAndProfileAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberPreferenceDetailsAppService;
using Loyalty.Application.MemberPreferenceDetailsAppService.Dto;

namespace Loyalty.Host.Controllers
{
    public class MemberPreferenceDetailsController : BaseController<IMemberPreferenceDetailsAppService, Domain.Models.MemberPreferenceDetails, MemberPreferenceDetailsGetAllDto, MemberPreferenceDetailsGetDto, MemberPreferenceDetailsCreateDto, MemberPreferenceDetailsUpdateDto, SieveModel>
    {
        public MemberPreferenceDetailsController(IMemberPreferenceDetailsAppService appService) : base(appService, Servics.Loyalty)
        {
        }
    }
}
