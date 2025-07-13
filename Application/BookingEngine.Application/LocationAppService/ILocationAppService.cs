using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.AmenitiesAppService.Dtos;
using BookingEngine.Application.LocationAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace BookingEngine.Application.LocationAppService
{
    public interface ILocationAppService : IBaseAppService<LocationGetDto, LocationGetDto, LocationCreateDto, LocationUpdateDto, SieveModel>
    {
        Task<LocationGetDto> GetByCountryCode(string countryCode);
    }

}
