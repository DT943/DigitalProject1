using Infrastructure.Service.Controllers;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Application.FlightOfferAppService;

using Offer.Application.HolidayAppService.Dtos;
using Offer.Application.HolidayAppService;
using Sieve.Models;
using Microsoft.AspNetCore.Authorization;

namespace Offer.Host.Controllers
{
    [Authorize]
    public class HolidayOfferController : BaseController<IHolidayAppService, Domain.Models.HolidayOffer, HolidayGetDto, HolidayGetDto, HolidayCreateDto, HolidayUpdateDto, SieveModel>
    {
        IHolidayAppService _appService;
        public HolidayOfferController(IHolidayAppService appService) : base(appService)
        {
            _appService = appService;
        }
    }
}

