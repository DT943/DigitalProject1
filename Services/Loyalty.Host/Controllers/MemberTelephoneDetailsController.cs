using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberDemographicsAndProfileAppService.Dto;
using Loyalty.Application.MemberDemographicsAndProfileAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberTelephoneDetailsAppService;
using Loyalty.Application.MemberTelephoneDetailsAppService.Dto;

namespace Loyalty.Host.Controllers
{
    public class MemberTelephoneDetailsController : BaseController<IMemberTelephoneDetailsAppService, Domain.Models.MemberTelephoneDetails, MemberTelephoneDetailsGetAllDto, MemberTelephoneDetailsGetDto, MemberTelephoneDetailsCreateDto, MemberTelephoneDetailsUpdateDto, SieveModel>
    {
        public MemberTelephoneDetailsController(IMemberTelephoneDetailsAppService appService) : base(appService, Servics.Loyalty)
        {
        }
    }
}
