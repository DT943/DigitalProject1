using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberEducationalDetailsAppService;
using Loyalty.Application.MemberEducationalDetailsAppService.Dto;

namespace Loyalty.Host.Controllers
{
    public class MemberEducationalDetailsController : BaseController<IMemberEducationalDetailsAppService, Domain.Models.MemberEducationalDetails, MemberEducationalDetailsGetAllDto, MemberEducationalDetailsGetDto, MemberEducationalDetailsCreateDto, MemberEducationalDetailsUpdateDto, SieveModel>
    {
        public MemberEducationalDetailsController(IMemberEducationalDetailsAppService appService) : base(appService, Servics.Loyalty)
        {

        }
    }
}
