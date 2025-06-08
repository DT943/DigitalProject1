using Infrastructure.Service.Controllers;
using Loyalty.Application.MemberAccrualTransactions.Dtos;
using Loyalty.Application.MemberAccrualTransactions;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;
using Loyalty.Application.ComplaintsAppService;
using Loyalty.Application.ComplaintsAppService.Dtos;

namespace Loyalty.Host.Controllers
{
    public class ComplaintsController : BaseController<IComplaintsAppService, Domain.Models.Complaints, ComplaintsGetDto, ComplaintsGetDto, ComplaintsCreateDto, ComplaintsUpdateDto, SieveModel>
    {
        public ComplaintsController(IComplaintsAppService appService) : base(appService, Servics.Loyalty)
        {

        }
    }
}