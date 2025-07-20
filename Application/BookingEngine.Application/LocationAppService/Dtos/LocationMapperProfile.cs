using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.AmenitiesAppService.Dtos;
using BookingEngine.Domain.Models;

namespace BookingEngine.Application.LocationAppService.Dtos
{

    public class LocationMapperProfile : Profile
    {
        public LocationMapperProfile()
        {

            CreateMap<LocationCreateDto, Location>();

            CreateMap<Location, LocationGetDto>();

            CreateMap<LocationUpdateDto, Location>();

        }
    }
}
