using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos;
using BookingEngine.Domain.Models;

namespace BookingEngine.Application.AuditAppService.Dtos
{
    public class InquirePNRMapperProfile : Profile
    {
        public InquirePNRMapperProfile()
        {
            CreateMap<InquirePNRCreateDto, InquirePNRResponse>()
                .ForMember(dest => dest.Errors, opt => opt.NullSubstitute(new List<string>()));

            // FROM WrappingAppService (Get DTOs) TO AuditAppService (Create DTOs)
            CreateMap<
                BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos.InquirePNRGetDto,
                BookingEngine.Application.AuditAppService.Dtos.InquirePNRCreateDto>();
            CreateMap<BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos.InquirePNRGetDto,
                      BookingEngine.Application.AuditAppService.Dtos.InquirePNRCreateDto>();

            CreateMap<BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos.BookFlightSegmentDto,
                      BookingEngine.Application.AuditAppService.Dtos.BookFlightSegmentCreateDto>();

            CreateMap<BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos.BookFareDto,
                      BookingEngine.Application.AuditAppService.Dtos.BookFareCreateDto>();

            CreateMap<BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos.BookTaxDto,
                      BookingEngine.Application.AuditAppService.Dtos.BookTaxCreateDto>();

            CreateMap<BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos.BookFeeDto,
                      BookingEngine.Application.AuditAppService.Dtos.BookFeeCreateDto>();

            CreateMap<BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos.BookPassengerDto,
                      BookingEngine.Application.AuditAppService.Dtos.BookPassengerCreateDto>();

            CreateMap<BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos.BookETicketDto,
                      BookingEngine.Application.AuditAppService.Dtos.BookETicketCreateDto>();

            CreateMap<BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos.BookContactInfoDto,
                      BookingEngine.Application.AuditAppService.Dtos.BookContactInfoCreateDto>();

            CreateMap<BookingEngine.Application.WrappingAppService.WrappingInquirePNRAppService.Dtos.BookPassengerCountDto,
                      BookingEngine.Application.AuditAppService.Dtos.BookPassengerCountCreateDto>();

            CreateMap<InquirePNRAuditCreateDto, InquirePNR>()
                    .ForMember(dest => dest.inquirePNRResponse, opt => opt.MapFrom(src => src.InquirePNRRsponseDto));


            CreateMap<InquirePNRCreateDto, InquirePNR>()
                .ForMember(dest => dest.inquirePNRResponse, opt => opt.MapFrom(src => src));
            // Maps nested InquirePNRResponse from same DTO

            CreateMap<BookFlightSegmentCreateDto, BookFlightSegment>();
            CreateMap<BookFareCreateDto, BookFare>();
            CreateMap<BookTaxCreateDto, BookTax>();
            CreateMap<BookFeeCreateDto, BookFee>();
            CreateMap<BookPassengerCreateDto, BookPassenger>();
            CreateMap<BookETicketCreateDto, BookETicket>();
            CreateMap<BookContactInfoCreateDto, BookContactInfo>();
            CreateMap<BookPassengerCountCreateDto, BookPassengerCount>();

            // ENTITIES -> GET DTOs (for responses)

            CreateMap<InquirePNR, InquirePNRAuditGetDto>();

            CreateMap<InquirePNRResponse, InquirePNRGetDto>()
                .ForMember(dest => dest.Errors, opt => opt.NullSubstitute(new List<string>()));

            CreateMap<BookFlightSegment, BookFlightSegmentDto>();
            CreateMap<BookFare, BookFareDto>();
            CreateMap<BookTax, BookTaxDto>();
            CreateMap<BookFee, BookFeeDto>();
            CreateMap<BookPassenger, BookPassengerDto>();
            CreateMap<BookETicket, BookETicketDto>();
            CreateMap<BookContactInfo, BookContactInfoDto>();
            CreateMap<BookPassengerCount, BookPassengerCountDto>();

            // ENTITIES -> AUDIT DTOs (for audit/log responses)

            CreateMap<InquirePNR, InquirePNRAuditWithIPGetDto>()
                .ForMember(dest => dest.InquirePNRRsponseDto, opt => opt.MapFrom(src => src.inquirePNRResponse));

            CreateMap<InquirePNRResponse, InquirePNRAuditGetDto>()
                .ForMember(dest => dest.Errors, opt => opt.NullSubstitute(new List<string>()));

            CreateMap<BookFlightSegment, BookFlightSegmentAuditDto>();
            CreateMap<BookFare, BookFareAuditDto>();
            CreateMap<BookTax, BookTaxAuditDto>();
            CreateMap<BookFee, BookFeeAuditDto>();
            CreateMap<BookPassenger, BookPassengerAuditDto>();
            CreateMap<BookETicket, BookETicketAuditDto>();
            CreateMap<BookContactInfo, BookContactInfoAuditDto>();
            CreateMap<BookPassengerCount, BookPassengerCountAuditDto>();



        }
    }
}
