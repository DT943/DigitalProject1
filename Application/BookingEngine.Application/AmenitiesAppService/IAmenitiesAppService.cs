using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingEngine.Application.AmenitiesAppService.Dtos;
using Infrastructure.Application;
using Sieve.Models;

namespace BookingEngine.Application.AmenitiesAppService
{
    public interface IAmenitiesAppService : IBaseAppService<AmenityGetDto, AmenityGetDto, AmenityCreateDto, AmenityUpdateDto, SieveModel>
    {
    }
}
