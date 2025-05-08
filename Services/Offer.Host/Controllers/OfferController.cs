using System.Linq.Dynamic.Core;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Offer.Application.OfferAppService;
using Offer.Application.OfferAppService.Dtos;
using Sieve.Models;
using static Infrastructure.Domain.Consts;

namespace Offer.Host.Controllers
{
 
        [Authorize]
        public class OfferController : BaseController<IOfferAppService, Domain.Models.Offer, OfferGetDto, OfferGetDto, OfferCreateDto, OfferUpdateDto, SieveModel>
        {
            IOfferAppService _appService;
            public OfferController(IOfferAppService appService) : base(appService, Servics.OFFER)
            {
                _appService = appService;
            }
            public override Task<ActionResult<OfferGetDto>> GetAll([FromQuery] SieveModel sieve)
            {
                return base.GetAll(sieve);
            }

        }


    
}
