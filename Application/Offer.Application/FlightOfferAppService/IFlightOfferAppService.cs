using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Offer.Application.FlightOfferAppService.Dtos;
using Offer.Application.OfferAppService.Dtos;
using Sieve.Models;

namespace Offer.Application.FlightOfferAppService
{
    public interface IFlightOfferAppService : IBaseAppService<FlightOfferGetDto, FlightOfferGetDto, FlightOfferCreateDto, FlightOfferUpdateDto, SieveModel>
    {
    }
}
