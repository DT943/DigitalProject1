using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Application;
using Offer.Application.OfferAppService.Dtos;
using Sieve.Models;

namespace Offer.Application.OfferAppService
{
    public interface IOfferAppService : IBaseAppService<OfferGetDto, OfferCreateDto, OfferUpdateDto, SieveModel>
    {
    }
}
