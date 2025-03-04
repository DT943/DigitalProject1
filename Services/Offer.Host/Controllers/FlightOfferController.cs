using Infrastructure.Service.Controllers;
using Offer.Application.FlightOfferAppService;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Application.OfferAppService;
using Sieve.Models;

namespace Offer.Host.Controllers
{
    public class FlightOfferController: BaseController<IFlightOfferAppService, Domain.Models.FlightOffer, FlightOfferGetDto, FlightOfferCreateDto, FlightOfferUpdateDto, SieveModel>
    {
        IFlightOfferAppService _appService;
        public FlightOfferController(IFlightOfferAppService appService) : base(appService)
        {
            _appService = appService;
        }
    }
}

// Test For Lubna Git