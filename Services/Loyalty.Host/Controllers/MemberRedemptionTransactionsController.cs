using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Loyalty.Application.MemberAccrualTransactions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.MemberRedemptionTransactions;
using Loyalty.Application.MemberRedemptionTransactions.Dto;

namespace Loyalty.Host.Controllers
{
    public class MemberRedemptionTransactionsController : BaseController<IMemberRedemptionTransactionsAppService, Domain.Models.MemberRedemptionTransactions, MemberRedemptionTransactionsGetDto, MemberRedemptionTransactionsGetDto, MemberRedemptionTransactionsCreateDto, MemberRedemptionTransactionsUpdateDto, SieveModel>
    {
        public MemberRedemptionTransactionsController(IMemberRedemptionTransactionsAppService appService) : base(appService, Servics.Loyalty)
        {

        }

 
    }
}
