using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;
using Loyalty.Application.MemberTelephoneDetailsAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberTravelAgentDetailsAppService;
using Loyalty.Application.MemberTravelAgentDetailsAppService.Dto;

namespace Loyalty.Host.Controllers
{
    public class MemberTravelAgentDetailsController : BaseController<IMemberTravelAgentDetailsAppService, Domain.Models.MemberTravelAgentDetails, MemberTravelAgentDetailsGetAllDto, MemberTravelAgentDetailsGetDto, MemberTravelAgentDetailsCreateDto, MemberTravelAgentDetailsUpdateDto, SieveModel>
    {
        public MemberTravelAgentDetailsController(IMemberTravelAgentDetailsAppService appService) : base(appService, Servics.Loyalty)
        {
        }
    }
}
