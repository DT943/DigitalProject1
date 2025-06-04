using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace B2B.Application.ReservationAppService.Dto
{

    public class ReservationMapperProfile : Profile
    {
        public ReservationMapperProfile()
        {
            CreateMap<Domain.Models.Reservation, ReservationGetDto>();
            CreateMap<Domain.Models.Segments, SegmentsGetDto>();
            CreateMap<Domain.Models.Passengers, PassengersGetDto>();
            CreateMap<Domain.Models.ContactInfo, ContactInfoGetDto>();
            CreateMap<Domain.Models.PNRDetails, PNRDetailsGetDto>();


            CreateMap<ReservationCreateDto, Domain.Models.Reservation>();
            CreateMap<SegmentsCreateDto, Domain.Models.Segments>();
            CreateMap<PassengersCreateDto, Domain.Models.Passengers>();
            CreateMap<ContactInfoCreateDto, Domain.Models.ContactInfo>();
            CreateMap<PNRDetailsCreateDto, Domain.Models.PNRDetails>();


            CreateMap<ReservationUpdateDto, Domain.Models.Reservation>();
            CreateMap<SegmentsUpdateDto, Domain.Models.Segments>();
            CreateMap<PassengersUpdateDto, Domain.Models.Passengers>();
            CreateMap<ContactInfoUpdateDto, Domain.Models.ContactInfo>();
            CreateMap<PNRDetailsUpdateDto, Domain.Models.PNRDetails>();
        }
    }
}
