using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.PaymantAppService.Dtos;

namespace BookingEngine.Application.MailModoAppService.Dtos
{
    public class MailModoResultMapperProfile : Profile
    {

        public MailModoResultMapperProfile()
        {
            //Create 
            CreateMap<MailModoCreateDto, Domain.Models.MailModoResult>();

            CreateMap<MailModoUpdateDto, Domain.Models.MailModoResult>();
          
            CreateMap<Domain.Models.MailModoResult, MailModoGetDto>();


        }
    }
}
