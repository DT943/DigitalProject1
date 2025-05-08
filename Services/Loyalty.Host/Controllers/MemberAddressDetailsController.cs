using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberAddressDetailsAppService;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace Loyalty.Host.Controllers
{
    public class MemberAddressDetailsController : BaseController<IMemberAddressDetailsAppService, Domain.Models.MemberAddressDetails, MemberAddressDetailsGetAllDto, MemberAddressDetailsGetDto, MemberAddressDetailsCreateDto, MemberAddressDetailsUpdateDto, SieveModel>
    {
        public MemberAddressDetailsController(IMemberAddressDetailsAppService appService) : base(appService, Servics.Loyalty)
        {

        }
    }
}
