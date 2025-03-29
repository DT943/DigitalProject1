using Infrastructure.Service.Controllers;
using Offer.Application.FlightOfferAppService;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Application.OfferAppService;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace Offer.Host.Controllers
{
    public class FlightOfferController: BaseController<IFlightOfferAppService, Domain.Models.FlightOffer, FlightOfferGetDto, FlightOfferGetDto, FlightOfferCreateDto, FlightOfferUpdateDto, SieveModel>
    {
        IFlightOfferAppService _appService;
        public FlightOfferController(IFlightOfferAppService appService) : base(appService, Servics.OFFER)
        {
            _appService = appService;
        }
    }
}
