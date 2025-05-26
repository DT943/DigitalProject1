using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberAccrualTransactions;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Loyalty.Application.MemberAddressDetailsAppService.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace Loyalty.Host.Controllers
{
    public class MemberAccrualTransactionsController : BaseController<IMemberAccrualTransactionsAppService, Domain.Models.MemberAccrualTransactions, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsGetDto, MemberAccrualTransactionsCreateDto, MemberAccrualTransactionsUpdateDto, SieveModel>
    {
        public MemberAccrualTransactionsController(IMemberAccrualTransactionsAppService appService) : base(appService, Servics.Loyalty)
        {

        }


        [HttpGet("Details")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> MemberAccrualTransactionsDetails()
        {
            var user = HttpContext.User;
            return Ok(await _appService.MemberAccrualTransactionsDetails());
        }
    }
}
