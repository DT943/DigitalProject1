using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberSecurityQuestionsAppService;
using Loyalty.Application.MemberSecurityQuestionsAppService.Dto;

namespace Loyalty.Host.Controllers
{
    public class MemberSecurityQuestionsController : BaseController<IMemberSecurityQuestionsAppService, Domain.Models.MemberSecurityQuestions, MemberSecurityQuestionsGetAllDto, MemberSecurityQuestionsGetDto, MemberSecurityQuestionsCreateDto, MemberSecurityQuestionsUpdateDto, SieveModel>
    {
        public MemberSecurityQuestionsController(IMemberSecurityQuestionsAppService appService) : base(appService, Servics.Loyalty)
        {

        }
    }
}
