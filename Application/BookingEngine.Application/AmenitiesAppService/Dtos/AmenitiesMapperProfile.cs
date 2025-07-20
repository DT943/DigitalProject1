using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.AuditAppService.Dtos;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos;
using BookingEngine.Domain.Models;

namespace BookingEngine.Application.AmenitiesAppService.Dtos
{
    public class AmenitiesMapperProfile : Profile
    {
        public AmenitiesMapperProfile()
        {

            CreateMap<AmenityCreateDto, Amenity>();

            CreateMap<Amenity, AmenityGetDto>();

            CreateMap<AmenityUpdateDto, Amenity>();

        }
    }
}
