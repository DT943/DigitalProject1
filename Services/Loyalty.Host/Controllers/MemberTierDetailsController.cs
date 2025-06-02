using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;
using Loyalty.Application.MemberTelephoneDetailsAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberTierDetailsAppService;
using Loyalty.Application.MemberTierDetailsAppService.Dto;

namespace Loyalty.Host.Controllers
{
    public class MemberTierDetailsController : BaseController<IMemberTierDetailsAppService, Domain.Models.MemberTierDetails, MemberTierDetailsGetDto, MemberTierDetailsGetDto, MemberTierDetailsCreateDto, MemberTierDetailsUpdateDto, SieveModel>
    {
        public MemberTierDetailsController(IMemberTierDetailsAppService appService) : base(appService, Servics.Loyalty)
        {
        }
    }
}
