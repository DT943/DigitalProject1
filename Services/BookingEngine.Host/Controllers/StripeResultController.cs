using BookingEngine.Application.AirPortAppService;
using BookingEngine.Application.PaymantAppService;
using BookingEngine.Application.PaymantAppService.Dtos;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace BookingEngine.Host.Controllers
{
    public class StripeResultController: BaseController<IStripeResultAppService, Domain.Models.StripeResult, StripeResultGetDto, StripeResultGetDto, StripeResultCreateDto, StripeResultUpdateDto, SieveModel>
    {
        public StripeResultController(IStripeResultAppService appService) : base(appService, Servics.BookingEngine) 
        {
        }
    
    }
}
