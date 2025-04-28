using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberContactPersonsAppService;
using Loyalty.Application.MemberContactPersonsAppService.Dtos;

namespace Loyalty.Host.Controllers
{
    public class MemberContactPersonsController : BaseController<IMemberContactPersonsAppService, Domain.Models.MemberContactPersons, MemberContactPersonsGetAllDto, MemberContactPersonsGetDto, MemberContactPersonsCreateDto, MemberContactPersonsUpdateDto, SieveModel>
    {
        public MemberContactPersonsController(IMemberContactPersonsAppService appService) : base(appService, Servics.Loyalty)
        {

        }
    }
}
