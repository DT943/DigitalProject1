using Infrastructure.Service.Controllers;
using Loyalty.Application.ComplaintsAppService.Dtos;
using Loyalty.Application.ComplaintsAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberTierPurchaseValidationAppService;
using Loyalty.Application.MemberTierPurchaseValidationAppService.Dto;

namespace Loyalty.Host.Controllers
{
    public class MemberTierPurchaseValidationController : BaseController<IMemberTierPurchaseValidationAppService, Domain.Models.MemberTierPurchaseValidation, MemberTierPurchaseValidationGetDto, MemberTierPurchaseValidationGetDto, MemberTierPurchaseValidationCreateDto, MemberTierPurchaseValidationUpdateDto, SieveModel>
    {
        public MemberTierPurchaseValidationController(IMemberTierPurchaseValidationAppService appService) : base(appService, Servics.Loyalty)
        {

        }
    }
}