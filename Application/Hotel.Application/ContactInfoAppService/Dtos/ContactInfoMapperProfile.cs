using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hotel.Application.HotelAppService.Dtos;

namespace Hotel.Application.ContactInfoAppService.Dtos
{
    public class ContactInfoMapperProfile : Profile 
    {
        public ContactInfoMapperProfile() {

            CreateMap<Hotel.Domain.Models.ContactInfo, ContactInfoGetDto>();

            CreateMap<ContactInfoCreateDto, Hotel.Domain.Models.ContactInfo>();

            CreateMap<ContactInfoUpdateDto, Hotel.Domain.Models.ContactInfo>();
        }

    }
}
