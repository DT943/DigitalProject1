using Hotel.Application.HotelAppService;
using Hotel.Application.HotelAppService.Dtos;
using Infrastructure.Service.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;

namespace Hotel.Host.Controllers
{
    [Authorize]
    public class HotelController : BaseController<IHotelAppService, Domain.Models.Hotel, HotelGetDto, HotelGetDto, HotelCreateDto, HotelUpdateDto, SieveModel>
    {
        IHotelAppService _appService;
        public HotelController(IHotelAppService appService) : base(appService)
        {
            _appService = appService;
        }

    }
}
