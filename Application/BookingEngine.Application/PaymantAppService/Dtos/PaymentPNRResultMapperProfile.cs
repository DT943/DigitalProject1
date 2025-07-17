using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BookingEngine.Application.PaymantAppService.Dtos
{
    public class PaymentPNRResultMapperProfile : Profile
    {
        public PaymentPNRResultMapperProfile() {
            //Create 
            CreateMap<PaymentPNRResultCreateDto, Domain.Models.PaymentPNRResult>();
            CreateMap<PaymentPNRContactCreateDto, Domain.Models.PaymentPNRContact>();
            CreateMap<PaymentPNRETicketInfoCreateDto, Domain.Models.PaymentPNRETicketInfo>();
            CreateMap<PaymentPNRFeeCreateDto, Domain.Models.PaymentPNRFee>();
            CreateMap<PaymentPNRTaxCreateDto, Domain.Models.PaymentPNRTax>();
            CreateMap<PaymentPNRPassengerCreateDto, Domain.Models.PaymentPNRPassenger>();
            CreateMap<PaymentPNRFlightSegmentCreateDto, Domain.Models.PaymentPNRFlightSegment>();


            //Get
            CreateMap<Domain.Models.PaymentPNRResult, PaymentPNRResultGetDto>();
            CreateMap<Domain.Models.PaymentPNRContact, PaymentPNRContactGetDto>();
            CreateMap<Domain.Models.PaymentPNRETicketInfo, PaymentPNRETicketInfoGetDto>();
            CreateMap<Domain.Models.PaymentPNRFee, PaymentPNRFeeGetDto>();
            CreateMap<Domain.Models.PaymentPNRTax, PaymentPNRTaxGetDto>();
            CreateMap<Domain.Models.PaymentPNRPassenger, PaymentPNRPassengerGetDto>();
            CreateMap<Domain.Models.PaymentPNRFlightSegment, PaymentPNRFlightSegmentGetDto>();


        }
    }
}
